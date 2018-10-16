using System.Net;
using Forum.Presentation.Contracts.Command;
using Framework.Application.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Presentation.RestApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public TagController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateTag command)
        {
            _commandBus.Dispatch(command);
            return NoContent();
        }
    }
}