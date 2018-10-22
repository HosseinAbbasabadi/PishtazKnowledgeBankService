using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Framework.Identity
{
    public class ClaimHelper : IClaimHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimHelper()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }

        public long GetCurrentUserId()
        {
            return long.Parse(_httpContextAccessor.HttpContext.User.Claims.First(a => a.Type == "sub").Value);
        }

        public List<string> GetCurrentUserRoles()
        {
            var roles = new List<string>();
            var cliams = _httpContextAccessor.HttpContext.User.Claims.Where(a => a.Type == "role").ToList();
            cliams.ForEach(a => { roles.Add(a.Value); });
            return roles;
        }
    }
}