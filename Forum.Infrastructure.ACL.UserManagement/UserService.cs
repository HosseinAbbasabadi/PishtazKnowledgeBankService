using System;
using System.Collections.Generic;
using System.Linq;
using Forum.Domin.Contracts.Services;
using IdentityModel;
using IdentityServer4.Test;
using UserManagement.Presentation.RestApi;

namespace Forum.Infrastructure.ACL.UserManagement
{
    public class UserService : IUserService
    {
        private readonly List<TestUser> _users;

        public UserService()
        {
            _users = TestUsers.GetUsers();
        }

        public bool IsUserValid(long userId)
        {
            throw new NotImplementedException();
        }

        public string GetUserFullName(long userId)
        {
            var user = _users.First(a => a.SubjectId == userId.ToString());
            return user.Claims.First(a => a.Type == JwtClaimTypes.Name).Value;
        }

        public List<long> GetVerifireExperts()
        {
            var users = new List<long>();
            foreach (var user in _users)
            {
                if (user.Claims.All(x => x.Value != "VerifierExpert")) continue;
                    users.Add(int.Parse(user.SubjectId));
            }

            return users;
        }
    }
}