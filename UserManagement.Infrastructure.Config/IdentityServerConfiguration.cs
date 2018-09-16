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
                new ApiResource("Forum_Api", "ForumManagement")
                {
                    UserClaims =
                    {
                        Id,
                        Role
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
                    ClientId = "knowladgeBank",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {"Forum_Api"}
                }
            };
        }
    }
}