using System.Collections.Generic;
using Forum.Presentation.Contracts;
using Forum.Presentation.Contracts.Command;
using Forum.Presentation.Contracts.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Presentation.RestApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ITagFacadeService _tagFacadeService;
        public TagController(ITagFacadeService tagFacadeService)
        {
            _tagFacadeService = tagFacadeService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateTag command)
        {
            _tagFacadeService.Create(command);
            return NoContent();
        }

        [HttpGet]
        public List<TagDto> Get()
        {
            return _tagFacadeService.Tags();
        }
    }
}