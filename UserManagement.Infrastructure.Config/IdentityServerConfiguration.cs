using System.Collections.Generic;
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
            const string clientUri = "http://localhost:4200";
            return new List<Client>
            {
                new Client
                {
                    ClientId = "KnowladgeBankUi",
                    ClientName = "Knowladge Bank User Interface Application",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    IdentityTokenLifetime = 28800,
                    RedirectUris = {clientUri},
                    PostLogoutRedirectUris = {clientUri},
                    AllowedCorsOrigins = {clientUri},
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
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
    }
}