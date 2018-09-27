using Framework.Domain;

namespace UserManagement.Domain.Models.Users
{
    public class UserId : IdBase<long>
    {
        protected UserId()
        {
        }

        public UserId(long id) : base(id)
        {
        }
    }
}