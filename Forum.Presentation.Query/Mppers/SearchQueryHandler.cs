using System;
using System.Collections.Generic;
using System.Linq;
using Forum.Domain.Models.Answers;
using Forum.Domain.Models.Questions;
using Forum.Domain.Models.Tags;
using Forum.Domin.Contracts.Services;
using Forum.Presentation.Contracts.Query;
using Framework.Application.Query;
using NHibernate;
using NHibernate.Criterion;

namespace Forum.Presentation.Query.Mppers
{
    public class SearchQueryHandler : IQueryHandler<List<QuestionDto>, string>
    {
        private readonly ISession _session;
        private readonly QuestionMapper _questionMapper;

        public SearchQueryHandler(ISession session, IUserService userService)
        {
            _session = session;
            _questionMapper = new QuestionMapper(userService);
        }

        public List<QuestionDto> Handle(string condition)
        {
            var tags = _session.Query<Tag>().ToList();

            var questions = _session.CreateCriteria<Question>()
                .Add(Restrictions.Or(
                    new LikeExpression("Body", condition, MatchMode.Anywhere),
                    new LikeExpression("Title", condition, MatchMode.Anywhere)))
                .AddOrder(Order.Desc("CreationDateTime")).List<Question>();

            return (from question in questions
                let answersCount = _session.CreateCriteria<Answer>()
                    .Add(Restrictions.Eq("Question", question.Id))
                    .SetProjection(Projections.Count(Projections.Id()))
                    .UniqueResult<int>()
                select _questionMapper.MapQuestion(question, tags, answersCount)).ToList();
        }
    }
}