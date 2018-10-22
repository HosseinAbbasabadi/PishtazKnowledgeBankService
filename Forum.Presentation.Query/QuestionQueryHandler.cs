using System.Collections.Generic;
using System.Linq;
using Forum.Domain.Models.Answers;
using Forum.Domain.Models.Questions;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Models.Tags;
using Forum.Domin.Contracts.Services;
using Forum.Presentation.Contracts.Query;
using Forum.Presentation.Query.Mppers;
using Framework.Application.Query;
using NHibernate;
using NHibernate.Criterion;

namespace Forum.Presentation.Query
{
    public class QuestionQueryHandler : IQueryHandler<List<QuestionDto>>, IQueryHandler<QuestionDetailsDto, long>
    {
        private readonly ISession _session;
        private readonly QuestionMapper _questionMapper;

        public QuestionQueryHandler(ISession session, IUserService userService)
        {
            _session = session;
            _questionMapper = new QuestionMapper(userService);
        }

        public List<QuestionDto> Handle()
        {
            var tags = _session.Query<Tag>().ToList();
            var questions = _session.CreateCriteria<Question>().Add(Restrictions.Eq("IsVerified", true))
                .AddOrder(Order.Desc("CreationDateTime"))
                .List<Question>();

            return (from question in questions
                let answersCount = _session.CreateCriteria<Answer>()
                    .Add(Restrictions.Eq("Question", question.Id))
                    .SetProjection(Projections.Count(Projections.Id()))
                    .UniqueResult<int>()
                select _questionMapper.MapQuestion(question, tags, answersCount)).ToList();
        }

        public QuestionDetailsDto Handle(long id)
        {
            var questionId = new QuestionId(id);
            var question = _session.CreateCriteria<Question>().Add(Restrictions.Eq("Id", questionId))
                .Add(Restrictions.Eq("IsVerified", true))
                .UniqueResult<Question>();
            var tags = _session.Query<Tag>().ToList();
            return _questionMapper.MapQuestion(question, tags);
        }
    }
}