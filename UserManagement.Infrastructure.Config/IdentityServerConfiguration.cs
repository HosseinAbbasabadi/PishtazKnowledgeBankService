using System.Collections.Generic;
using System.Runtime.CompilerServices;
using IdentityServer4.Models;
using static IdentityModel.JwtClaimTypes;

namespace UserManagement.Infrastructure.Config
{
    public class IdentityServerConfiguration
    {
        public string ClientUrl { get; }

        public IdentityServerConfiguration(string clientUrl)
        {
            ClientUrl = clientUrl;
        }

        public IEnumerable<ApiResource> ApiResources()
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
                },
                new ApiResource("Notification_Api", "سرویس اطلاع رسانی و اعلانات")
            };
        }

        public IEnumerable<Client> Clients()
        {
            var clientUri = ClientUrl;
            return new List<Client>
            {
                new Client
                {
                    ClientId = "KnowladgeBankUi",
                    ClientName = "Knowladge Bank User Interface Application",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    IdentityTokenLifetime = 14400,
                    AuthorizationCodeLifetime = 14400,
                    AccessTokenLifetime = 14400,
                    RedirectUris = {clientUri},
                    PostLogoutRedirectUris = {clientUri},
                    AllowedCorsOrigins = {clientUri},
                    AllowedScopes =
                    {
                        "openid",
                        "profile",
                        "Forum_Api",
                        "Notification_Api"
                    },
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AlwaysSendClientClaims = true,
                    AllowOfflineAccess = true
                }
            };
        }

        public List<IdentityResource> IdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
    }
}