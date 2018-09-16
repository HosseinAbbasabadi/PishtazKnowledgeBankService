using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Test;

namespace UserManagement.Infrastructure.Config
{
    public class Users
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "hossein",
                    Password = "123456",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "1"),
                        new Claim(JwtClaimTypes.Role, "SysAdmin"),
                        new Claim("UserId", "10")
                    },
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "Rohollah",
                    Password = "12369",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "2"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim("UserId", "11")
                    }
                },
                new TestUser
                {
                    SubjectId = "3",
                    Username = "sepehr",
                    Password = "159",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "6"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim("UserId", "12")
                    }
                }
            };
        }
    }
}
