using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Models;

namespace UserManagement.Presentation.RestApi
{
    public class Config
    {
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("Forum_Api", "سرویس بانک دانش")
                {
                    UserClaims =
                    {
                        JwtClaimTypes.Id,
                        JwtClaimTypes.Role,
                        JwtClaimTypes.AccessTokenHash,
                        "UserId"
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
                    AllowedScopes = {"openid", "profile", "Forum_Api"},
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AlwaysSendClientClaims = true,
                    AllowOfflineAccess = true,
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("secret".Sha256())
                    },
                    Claims = new List<Claim>()
                    {
                        new Claim(JwtClaimTypes.AccessTokenHash, "token")
                    }
                }
            };
        }

        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
    }
}