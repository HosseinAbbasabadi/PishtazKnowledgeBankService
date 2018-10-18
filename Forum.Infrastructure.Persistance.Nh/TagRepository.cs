using Forum.Domain.Models.Tags;
using Framework.Nhibernate;
using NHibernate;

namespace Forum.Infrastructure.Persistance.Nh
{
    public class TagRepository : BaseRepository<TagId, Tag>, ITagRepository
    {
        public TagRepository(ISession session) : base(session)
        {
        }
    }
}
