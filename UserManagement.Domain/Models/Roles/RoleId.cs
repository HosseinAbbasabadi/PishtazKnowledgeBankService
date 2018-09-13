using Framework.Domain;

namespace UserManagement.Domain.Models.Roles
{
    public class RoleId : IdBase<long>
    {
        protected RoleId()
        {
        }

        public RoleId(long id) : base(id)
        {
        }
    }
}