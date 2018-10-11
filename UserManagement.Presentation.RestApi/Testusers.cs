using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;

namespace UserManagement.Presentation.RestApi
{
    public static class TestUsers
    {
        public static List<IdentityServer4.Test.TestUser> GetUsers()
        {
            return new List<IdentityServer4.Test.TestUser>
            {
                new IdentityServer4.Test.TestUser
                {
                    SubjectId = "1",
                    Username = "hossein",
                    Password = "123456",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "1"),
                        new Claim(JwtClaimTypes.Role, "SysAdmin"),
                        new Claim(JwtClaimTypes.Name, "حسین عباس آبادی")
                    },
                },
                new IdentityServer4.Test.TestUser
                {
                    SubjectId = "2",
                    Username = "Rohollah",
                    Password = "12369",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "2"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Name, "روح الله خوشدل")
                    }
                },
                new IdentityServer4.Test.TestUser
                {
                    SubjectId = "3",
                    Username = "sepehr",
                    Password = "159",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "3"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Name, "سپهر پاکپور")
                    }
                },
                new IdentityServer4.Test.TestUser
                {
                    SubjectId = "4",
                    Username = "kasra",
                    Password = "123456",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "4"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Name, "کسری چوبینه")
                    }
                },
                new IdentityServer4.Test.TestUser
                {
                    SubjectId = "5",
                    Username = "Mohammadi",
                    Password = "123456",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "5"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Name, "آقای اصغر محمدی")
                    }
                },new IdentityServer4.Test.TestUser
                {
                    SubjectId = "6",
                    Username = "Mortazavi",
                    Password = "123456",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "6"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Name, "فاطمه مرتضوی")
                    }
                },
            };
        }
    }
}