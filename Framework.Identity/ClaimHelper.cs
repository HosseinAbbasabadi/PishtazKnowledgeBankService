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

        public string GetUserFullName()
        {
            return _httpContextAccessor.HttpContext.User.Claims.First(a => a.Type == "Name").Value;
        }
    }
}