using System;
using System.Linq;
using Forum.Domin.Contracts.Services;
using IdentityModel;
using UserManagement.Presentation.RestApi;

namespace Forum.Infrastructure.ACL.UserManagement
{
    public class UserService : IUserService
    {
        public bool IsUserValid(long userId)
        {
            throw new NotImplementedException();
        }

        public string GetUserFullName(long userId)
        {
            var user = TestUsers.GetUsers().First(a => a.SubjectId == userId.ToString());
            return user.Claims.First(a => a.Type == JwtClaimTypes.Name).Value;
        }
    }
}
