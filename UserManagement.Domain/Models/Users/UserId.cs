using Framework.Domain;

namespace UserManagement.Domain
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