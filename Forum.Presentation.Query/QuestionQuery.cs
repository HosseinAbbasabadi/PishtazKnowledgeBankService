using System.Collections.Generic;
using System.Linq;
using Forum.Domain.Models.Answers;
using Forum.Domain.Models.Questions;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Models.Tags;
using Forum.Presentation.Contracts.Query;
using Forum.Presentation.Query.Mppers;
using NHibernate;
using NHibernate.Criterion;

namespace Forum.Presentation.Query
{
    public class QuestionQuery : IQuestionQuery
    {
        private readonly ISession _session;

        public QuestionQuery(ISession session)
        {
            _session = session;
        }

        public List<QuestionDto> GetQuestions()
        {
            var tags = _session.Query<Tag>().ToList();
            var questions = _session.CreateCriteria<Question>().AddOrder(Order.Desc("CreationDateTime"))
                .List<Question>();
            return QuestionMapper.MapQuestions(questions, tags);
        }

        public QuestionDetailsDto GetQuestionDetails(long id)
        {
            var questionId = new QuestionId(id);
            var question = _session.CreateCriteria<Question>().Add(Restrictions.Eq("Id", questionId))
                .UniqueResult<Question>();
            var tags = _session.Query<Tag>().ToList();
            var answers = _session.CreateCriteria<Answer>().Add(Restrictions.Eq("Question", questionId))
                .List<Answer>();
            return QuestionMapper.MapQuestion(question, tags, answers);
        }
    }
}