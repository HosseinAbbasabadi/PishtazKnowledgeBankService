using Forum.Domain.Models.Questions;
using Forum.Domain.Models.Questions.ValueObjects;
using Framework.Nhibernate;
using NHibernate;

namespace Forum.Infrastructure.Persistance.Nh
{
    public class QuestionRepository : BaseRepository<QuestionId, Question>, IQuestionRepository
    {
        public QuestionRepository(ISession session) : base(session)
        {
        }
    }
}