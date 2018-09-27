using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using static IdentityModel.JwtClaimTypes;

namespace UserManagement.Infrastructure.Config
{
    public class IdentityServerConfiguration
    {
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("Forum_Api", "سرویس بانک دانش")
                {
                    UserClaims =
                    {
                        Id,
                        Role,
                        Name
                    }
                }
            };
        }

        public static IEnumerable<Client> Clients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "KnowladgeBankUi",
                    ClientName = "Knowladge Bank User Interface Application",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    IdentityTokenLifetime = 28800,
                    RedirectUris = {"http://localhost:4200"},
                    PostLogoutRedirectUris = {"http://localhost:4200"},
                    AllowedCorsOrigins = {"http://localhost:4200/"},
                    AllowedScopes =
                    {
                        "openid",
                        "profile",
                        "Forum_Api"
                    },
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AlwaysSendClientClaims = true,
                    AllowOfflineAccess = true
                }
            };
        }

        public static List<IdentityResource> IdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId
                {
                    //Name = "سیستم مرکزی احراز هویت",
                    //DisplayName = "دسترسی به سیستم مرکزی احراز هویت"
                },
                new IdentityResources.Profile
                {
                    //Name = "سیستم اطلاعات کاربر",
                    //DisplayName = "دسترسی به سیستم اطلاعات کاربر"
                },
            };
        }
    }
}