using System.Collections.Generic;
using System.Net;
using Forum.Presentation.Contracts.Command;
using Forum.Presentation.Contracts.Query;
using Framework.Application.Command;
using Framework.Application.Query;
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
        private readonly IQueryBus _queryBus;

        public TagController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateTag command)
        {
            _commandBus.Dispatch(command);
            return NoContent();
        }

        [HttpGet]
        public List<TagDto> Tags()
        {
            return _queryBus.Dispatch<List<TagDto>>();
        }
    }
}