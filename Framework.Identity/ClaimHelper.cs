using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Framework.Identity
{
    public class ClaimHelper : IClaimHelper
    {
        public long GetUserId()
        {
            var context = new HttpContextAccessor();
            return long.Parse(context.HttpContext.User.Claims.First(a => a.Type == "sub").Value);
        }
    }
}