﻿using System.Collections.Generic;
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
                    Password = "Hossein1",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "1"),
                        new Claim(JwtClaimTypes.Role, "SysAdmin"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Role, "VerifierExpert"),
                        new Claim(JwtClaimTypes.Name, "حسین عباس آبادی")
                    },
                },
                new IdentityServer4.Test.TestUser
                {
                    SubjectId = "2",
                    Username = "Khoshdel",
                    Password = "Khoshdel2",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "2"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Role, "VerifierExpert"),
                        new Claim(JwtClaimTypes.Name, "روح الله خوشدل")
                    }
                },
                new IdentityServer4.Test.TestUser
                {
                    SubjectId = "3",
                    Username = "Pakpoor",
                    Password = "Pakpoor3",
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
                    Username = "Choobineh",
                    Password = "Choobineh4",
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
                    Password = "Mohammadi5",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "5"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Name, "اصغر محمدی")
                    }
                },new IdentityServer4.Test.TestUser
                {
                    SubjectId = "6",
                    Username = "Mortazavi",
                    Password = "Mortazavi6",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "6"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Role, "VerifierExpert"),
                        new Claim(JwtClaimTypes.Name, "فاطمه مرتضوی")
                    }
                },new IdentityServer4.Test.TestUser
                {
                    SubjectId = "7",
                    Username = "Rozbeh",
                    Password = "Rozbeh7",
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
                    Password = "Farid8",
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
                    Password = "Foad9",
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
                    Password = "Mahabadi10",
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
                    Password = "Rezaali11",
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
                    Password = "Taherkhani12",
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
                    Password = "Safari13",
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
                    Password = "Sedaghati14",
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
                    Password = "Modanlo15",
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
                    Password = "Kahaki16",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "16"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Name, "فرشته کهکی")
                    }
                },new IdentityServer4.Test.TestUser
                {
                    SubjectId = "17",
                    Username = "Mahdavi",
                    Password = "Mahdavi17",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "17"),
                        new Claim(JwtClaimTypes.Role, "Expert"),
                        new Claim(JwtClaimTypes.Name, "رضا مهدوی")
                    }
                }
            };
        }
    }
}