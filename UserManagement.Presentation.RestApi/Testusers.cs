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
                    Username = "Hossein",
                    Password = "Hossein",
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
                    Password = "Rohollah",
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
                    Username = "Sepehr",
                    Password = "Sepehr",
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
                    Password = "kasra",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "4"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Role, "VerifierExpert"),
                        new Claim(JwtClaimTypes.Name, "کسری چوبینه")
                    }
                },
                new IdentityServer4.Test.TestUser
                {
                    SubjectId = "5",
                    Username = "Mohammadi",
                    Password = "Mohammadi",
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
                    Password = "Mortazavi",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "6"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Name, "فاطمه مرتضوی")
                    }
                },new IdentityServer4.Test.TestUser
                {
                    SubjectId = "7",
                    Username = "Rozbeh",
                    Password = "Rozbeh",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "7"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Name, "محمد روزبه")
                    }
                },new IdentityServer4.Test.TestUser
                {
                    SubjectId = "8",
                    Username = "Farid",
                    Password = "Farid",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "8"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Name, "فرید مقدسی")
                    }
                },new IdentityServer4.Test.TestUser
                {
                    SubjectId = "9",
                    Username = "Foad",
                    Password = "Foad",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "9"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Name, "فواد مقدسی")
                    }
                },new IdentityServer4.Test.TestUser
                {
                    SubjectId = "10",
                    Username = "Mahabadi",
                    Password = "Mahabadi",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "10"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Name, "مرتضی مهابادی")
                    }
                },new IdentityServer4.Test.TestUser
                {
                    SubjectId = "11",
                    Username = "Rezaali",
                    Password = "Rezaali",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "11"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Name, "مهدی رضاعلی")
                    }
                },new IdentityServer4.Test.TestUser
                {
                    SubjectId = "12",
                    Username = "Taherkhani",
                    Password = "Taherkhani",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "12"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Name, "هادی طاهرخانی")
                    }
                },new IdentityServer4.Test.TestUser
                {
                    SubjectId = "13",
                    Username = "Safari",
                    Password = "Safari",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "13"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Name, "زهرا صفری")
                    }
                },new IdentityServer4.Test.TestUser
                {
                    SubjectId = "14",
                    Username = "Sedaghati",
                    Password = "Sedaghati",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "14"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Name, "زینب صداقتی")
                    }
                },new IdentityServer4.Test.TestUser
                {
                    SubjectId = "15",
                    Username = "Modanlo",
                    Password = "Modanlo",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "15"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Name, "زینب مدانلو")
                    }
                },new IdentityServer4.Test.TestUser
                {
                    SubjectId = "16",
                    Username = "Kahaki",
                    Password = "Kahaki",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "16"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Name, "فرشته کهکی")
                    }
                },
            };
        }
    }
}