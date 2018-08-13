using Framework.Domain;

namespace Forum.Domain.Models.Tags
{
    public class TagId : IdBase<long>
    {
        public TagId(long idDbId) : base(idDbId)
        {
        }
    }
}