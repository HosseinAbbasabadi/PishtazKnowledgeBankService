using System.Collections.Generic;
using System.Linq;
using Framework.Domain;
using UserManagement.Domain.Models.Roles;
using UserManagement.Domain.Models.Users;

namespace UserManagement.Domain
{
    public class User : AggregateRootBase<UserId>, IAggregateRoot
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public List<RoleId> Roles { get; private set; }

        public User(UserId id, string userName, string password, string firstName, string lastName, List<long> roles) : base(id)
        {
            GuardAgainstConstructingUserWithAnyRole(roles);

            UserName = userName;
            Password = password;
            Firstname = firstName;
            Lastname = lastName;
            Roles = MapRoles(roles);
        }

        private static void GuardAgainstConstructingUserWithAnyRole(List<long> roles)
        {
            if (roles.Count < 1)
                throw new UserShouldHaveARoleException();
        }

        public List<RoleId> MapRoles(List<long> roles)
        {
            return roles.Select(a => MapOneRole(a)).ToList();
        }

        public RoleId MapOneRole(long role)
        {
            return new RoleId(role);    
        }
    }
}