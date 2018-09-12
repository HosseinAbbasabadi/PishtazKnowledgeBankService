using System.Collections.Generic;
using System.Linq;
using Forum.Domain.Models.Answers;
using Forum.Domain.Models.Questions;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Models.Tags;
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

        public QuestionQueryHandler(ISession session)
        {
            _session = session;
        }

        public List<QuestionDto> Handle()
        {
            var tags = _session.Query<Tag>().ToList();
            var questions = _session.CreateCriteria<Question>().AddOrder(Order.Asc("CreationDateTime"))
                .List<Question>();

            return (from question in questions
                let answersCount = _session.CreateCriteria<Answer>()
                    .Add(Restrictions.Eq("Question", question.Id))
                    .SetProjection(Projections.Count(Projections.Id()))
                    .UniqueResult<int>()
                select QuestionMapper.MapQuestion(question, tags, answersCount)).ToList();
        }

        public QuestionDetailsDto Handle(long id)
        {
            var questionId = new QuestionId(id);
            var question = _session.CreateCriteria<Question>().Add(Restrictions.Eq("Id", questionId))
                .UniqueResult<Question>();
            var tags = _session.Query<Tag>().ToList();
            return QuestionMapper.MapQuestion(question, tags);
        }
    }
}