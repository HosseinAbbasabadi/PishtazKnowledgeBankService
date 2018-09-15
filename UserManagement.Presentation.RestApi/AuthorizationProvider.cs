using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace UserManagement.Presentation.RestApi
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (context.UserName == "admin" && context.Password == "123456")
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Role, "SalePerson"));
                context.Validated(identity);
            }
            else
            {
                context.Rejected();
            }

            //return base.GrantResourceOwnerCredentials(context);
        }
    }
}