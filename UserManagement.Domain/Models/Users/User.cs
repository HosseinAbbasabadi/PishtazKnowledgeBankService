using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Framework.Domain;
using UserManagement.Domain.Models.Roles;
using UserManagement.Domain.Models.Users.Exceptions;

namespace UserManagement.Domain.Models.Users
{
    public class User : AggregateRootBase<UserId>, IAggregateRoot
    {
        private readonly IList<RoleId> _roles;

        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public IReadOnlyCollection<RoleId> Roles => new ReadOnlyCollection<RoleId>(_roles);

        public User(UserId id, string username, string password, string firstName, string lastName, List<long> roles) : base(id)
        {
            GuardAgainstConstructingUserWithAnyRole(roles);

            Username = username;
            Password = password;
            Firstname = firstName;
            Lastname = lastName;
            CreationDateTime = DateTime.Now;
            _roles = MapRoles(roles);
        }
        protected User() { }
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