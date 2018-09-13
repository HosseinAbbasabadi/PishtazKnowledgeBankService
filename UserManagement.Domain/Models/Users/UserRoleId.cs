using Framework.Domain;

namespace UserManagement.Domain.Models.Users
{
    public class UserRoleId : ValueObjectBase
    {
        public long Value { get; private set; }

        public UserRoleId(long userRole)
        {
            this.Value = userRole;
        }
    }
}