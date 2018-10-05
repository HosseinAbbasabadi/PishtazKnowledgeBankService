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
        private readonly ISession _session;

        public AnswerRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public List<Answer> GetByQuestionId(QuestionId questionId)
        {
            return _session.Query<Answer>().Where(x => x.Question == questionId).ToList();
        }
    }
}