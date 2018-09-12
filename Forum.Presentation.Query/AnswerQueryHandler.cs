using System.Collections.Generic;
using Forum.Domain.Models.Answers;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Presentation.Contracts.Query;
using Forum.Presentation.Query.Mppers;
using Framework.Application.Query;
using NHibernate;
using NHibernate.Criterion;

namespace Forum.Presentation.Query
{
    public class AnswerQueryHandler : IQueryHandler<List<AnswerDto>, long>
    {
        private readonly ISession _session;

        public AnswerQueryHandler(ISession session)
        {
            _session = session;
        }

        public List<AnswerDto> Handle(long id)
        {
            var questionId = new QuestionId(id);
            var answers = _session.CreateCriteria<Answer>().Add(Restrictions.Eq("Question", questionId))
                .List<Answer>();
            return AnswerMapper.MapAnswers(answers);
        }
    }
}