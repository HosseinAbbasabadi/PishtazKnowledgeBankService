using Framework.Domain;

namespace Forum.Domain.Models.Tags
{
    public class TagId : IdBase<long>
    {
        protected TagId() { }
        public TagId(long idDbId) : base(idDbId)
        {
        }
    }
}