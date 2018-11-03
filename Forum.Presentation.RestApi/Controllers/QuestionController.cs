using System;
using System.Collections.Generic;
using Forum.Presentation.Contracts;
using Forum.Presentation.Contracts.Command;
using Forum.Presentation.Contracts.Query;
using Framework.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Presentation.RestApi.Controllers
{
    [Route("api/Question")]
    [Authorize]
    public class QuestionController : Controller, IGateway
    {
        private readonly IQuestionFacadeService _questionFacadeService;

        public QuestionController(IQuestionFacadeService questionFacadeService)
        {
            _questionFacadeService = questionFacadeService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateQuestion command)
        {
            _questionFacadeService.Create(command);
            return NoContent();
        }

        [HttpGet]
        public List<QuestionDto> Get()
        {
            return _questionFacadeService.Questions();
        }

        [HttpGet("{id}")]
        public QuestionDetailsDto Get(long id)
        {
            return _questionFacadeService.QuestionDetails(id);
        }

        [HttpPut("AddVote")]
        public IActionResult Put([FromBody] AddVote command)
        {
            _questionFacadeService.AddVote(command);
            return NoContent();
        }

        [HttpPut("ContainsTrueAnswer")]
        public IActionResult Put([FromBody] ContainsTrueAnswer command)
        {
            _questionFacadeService.ContainsTrueAnswer(command);
            return NoContent();
        }

        [HttpPost("VerifyQuestion")]
        public IActionResult Post([FromBody] VerifyQuestion command)
        {
            _questionFacadeService.VerifyQuestion(command);
            return NoContent();
        }

        [HttpPost("ModifyQuestion")]
        public IActionResult Post([FromBody] ModifyQuestion command)
        {
            _questionFacadeService.ModifyQuestion(command);
            return NoContent();
        }

        [HttpPut("AddView")]
        public IActionResult Put([FromBody] AddView command)
        {
            _questionFacadeService.AddView(command);
            return NoContent();
        }
    }
}