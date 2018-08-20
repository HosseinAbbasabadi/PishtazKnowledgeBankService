using Forum.Domain.Models.Answers;
using Framework.Nhibernate;
using NHibernate;

namespace Forum.Infrastructure.Persistance.Nh
{
    public class AnswerRepository : BaseRepository<AnswerId, Answer>, IAnswerRepository
    {
        public AnswerRepository(ISession session) : base(session)
        {
        }
    }
}
