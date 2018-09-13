using Framework.Domain;

namespace UserManagement.Domain.Models.Roles
{
    public class Role : AggregateRootBase<RoleId>, IAggregateRoot
    {
        public string Name { get; private set; }

        public Role(RoleId id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
