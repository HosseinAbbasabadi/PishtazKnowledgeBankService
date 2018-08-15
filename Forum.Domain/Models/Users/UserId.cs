using Framework.Domain;

namespace Forum.Domain.Models.Users
{
    public class UserId : IdBase<long>
    {
        protected UserId() { }
        public UserId(long idDbId) : base(idDbId)
        {
        }
    }
}