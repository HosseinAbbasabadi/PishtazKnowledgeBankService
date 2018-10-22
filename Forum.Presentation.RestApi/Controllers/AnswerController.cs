using System.Collections.Generic;
using Forum.Presentation.Contracts;
using Forum.Presentation.Contracts.Command;
using Forum.Presentation.Contracts.Query;
using Framework.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Presentation.RestApi.Controllers
{
    [Route("api/Answer")]
    [Produces("application/json")]
    [Authorize]
    public class AnswerController : ControllerBase, IGateway
    {
        private readonly IAnswerFacadeService _answerFacadeService;

        public AnswerController(IAnswerFacadeService answerFacadeService)
        {
            _answerFacadeService = answerFacadeService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddAnswer command)
        {
            _answerFacadeService.Add(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public List<AnswerDto> Get(long id)
        {
            return _answerFacadeService.Answers(id);
        }

        [HttpPost("SetAsChosenAnswer")]
        public IActionResult Post([FromBody] ChosenAnswer command)
        {
            _answerFacadeService.SetAsChosenAnswer(command);
            return NoContent();
        }
    }
}