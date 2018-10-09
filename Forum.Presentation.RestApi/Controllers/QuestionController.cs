using System;
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
    [Route("api/Question")]
    [Authorize]
    public class QuestionController : Controller, IGateway
    {
        private readonly ICommandBus _bus;
        private readonly IQueryBus _queryBus;

        public QuestionController(ICommandBus bus, IQueryBus queryBus)
        {
            _bus = bus;
            _queryBus = queryBus;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateQuestion command)
        {
            _bus.Dispatch(command);
            return NoContent();
        }

        [HttpGet]
        public IActionResult Questions()
        {
            var questions = _queryBus.Dispatch<List<QuestionDto>>();
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public QuestionDetailsDto QuestionDetails(long id)
        {
            return _queryBus.Dispatch<QuestionDetailsDto, long>(id);
        }

        [HttpPut("AddVote")]
        public IActionResult AddVote([FromBody] AddVote command)
        {
            try
            {
                _bus.Dispatch(command);
                return NoContent();
            }
            catch (Exception exception)
            {
                var error = new ErrorDetails
                {
                    Message = exception.Message,
                    StatusCode = exception.HResult
                };
                return BadRequest(error);
            }
        }

        [HttpPut("ContainsTrueAnswer")]
        public IActionResult ContainsTrueAnswer([FromBody] ContainsTrueAnswer command)
        {
            try
            {
                _bus.Dispatch(command);
                return NoContent();
            }
            catch (Exception exception)
            {
                var error = new ErrorDetails
                {
                    Message = exception.Message,
                    StatusCode = exception.HResult
                };
                return BadRequest(error);
            }
        }
    }
}