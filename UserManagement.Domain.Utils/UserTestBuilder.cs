using System.Collections.Generic;
using Framework.Core;
using UserManagement.Domain.Models.Users;

namespace UserManagement.Domain.Utils
{
    public class UserTestBuilder : IBuilder<User>
    {
        public UserId UserId;
        public string Username;
        public string Firstname;
        public string Lastname;
        public List<long> Roles;

        public UserTestBuilder()
        {
            UserId = new UserId(1);
            Username = "sharkProgrammer";
            Firstname = "hossein";
            Lastname = "abbasabadi";
            Roles = new List<long>
            {
                1
            };
        }

        public UserTestBuilder WithUserId(long id)
        {
            var userId = new UserId(id);
            UserId = userId;
            return this;
        }

        public UserTestBuilder WithRoles(List<long> roles)
        {
            Roles = roles;
            return this;
        }

        public User Build()
        {
            return new User(UserId, Username, Firstname, Lastname, Roles);
        }

        public List<User> BuildList(int count)
        {
            var users = new List<User>();
            for (var i = 1; i <= count; i++)
            {
                users.Add(WithUserId(i).Build());
            }

            return users;
        }
    }
}