using System;
using System.Collections.Generic;
using Forum.Presentation.Contracts;
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
    public class AnswerController : ControllerBase, IGateway
    {
        private readonly IAnswerFacadeService _answerFacadeService;

        public AnswerController(IAnswerFacadeService answerFacadeService)
        {
            _answerFacadeService = answerFacadeService;
        }

        [HttpPost]
        public void Post([FromBody] AddAnswer command)
        {
            _answerFacadeService.Add(command);
        }

        [HttpGet("{id}")]
        public List<AnswerDto> Get(long id)
        {
            return _answerFacadeService.Answers(id);
        }

        [HttpPost("SetAsChosenAnswer")]
        public void Post([FromBody] ChosenAnswer command)
        {
            _answerFacadeService.SetAsChosenAnswer(command);
        }
    }
}