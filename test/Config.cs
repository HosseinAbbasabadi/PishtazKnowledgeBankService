using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityServerDefaultTemplate
{
    public class Config
    {
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
                    }
                }
            };
        }
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("Forum_Api", "سرویس بانک دانش")
                {
                    UserClaims =
                    {
                        //Id,
                        //Role,
                        //AccessTokenHash,
                        "UserId"
                    }
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
