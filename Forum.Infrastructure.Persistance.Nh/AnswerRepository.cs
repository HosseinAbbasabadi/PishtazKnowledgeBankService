using System.Collections.Generic;
using System.Linq;
using Forum.Domain.Models.Answers;
using Forum.Domain.Models.Questions.ValueObjects;
using Framework.Nhibernate;
using NHibernate;

namespace Forum.Infrastructure.Persistance.Nh
{
    public class AnswerRepository : BaseRepository<AnswerId, Answer>, IAnswerRepository
    {
        public AnswerRepository(ISession session) : base(session)
        {
        }

        public List<Answer> GetByQuestionId(QuestionId questionId)
        {
            return Session.Query<Answer>().Where(x => x.Question == questionId).ToList();
        }
    }
}