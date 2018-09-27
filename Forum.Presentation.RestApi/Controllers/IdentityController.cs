using System.Linq;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Presentation.RestApi.Controllers
{
    [Route("api/Identity")]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        public string GetFullName()
        {
            return User.Claims.First(a => a.Type == JwtClaimTypes.Name).Value;
        }
    }
}