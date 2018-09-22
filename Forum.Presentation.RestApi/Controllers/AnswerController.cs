using System.Collections.Generic;
using Forum.Presentation.Contracts.Command;
using Forum.Presentation.Contracts.Query;
using Framework.Application.Command;
using Framework.Application.Query;
using Framework.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Presentation.RestApi.Controllers
{
    [Route("api/Answer")]
    [Produces("application/json")]
    [Authorize]
    public class AnswerController : Controller, IGateway
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public AnswerController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddAnswer command)
        {
            _commandBus.Dispatch(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public List<AnswerDto> Answers(long id)
        {
            return _queryBus.Dispatch<List<AnswerDto>, long>(id);
        }
    }
}