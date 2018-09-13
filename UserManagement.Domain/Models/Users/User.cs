﻿using System.Collections.Generic;
using System.Linq;
using Framework.Domain;
using UserManagement.Domain.Models.Users;

namespace UserManagement.Domain
{
    public class User : AggregateRootBase<UserId>, IAggregateRoot
    {
        public string UserName { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public List<UserRoleId> Roles { get; set; }

        public User(UserId id, string userName, string firstName, string lastName, List<long> roles) : base(id)
        {
            GuardAgainstConstructingUserWithAnyRole(roles);

            UserName = userName;
            Firstname = firstName;
            Lastname = lastName;
            Roles = MapRoles(roles);
        }

        private static void GuardAgainstConstructingUserWithAnyRole(List<long> roles)
        {
            if (roles.Count < 1)
                throw new UserShouldHaveARoleException();
        }

        public List<UserRoleId> MapRoles(List<long> roles)
        {
            return roles.Select(a => MapOneRole(a)).ToList();
        }

        public UserRoleId MapOneRole(long role)
        {
            return new UserRoleId(role);    
        }
    }
}