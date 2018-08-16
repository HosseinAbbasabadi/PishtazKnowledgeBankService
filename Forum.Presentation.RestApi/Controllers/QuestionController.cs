using System.Collections.Generic;
using Forum.Presentation.Contracts;
using Forum.Presentation.Contracts.Query;
using Forum.Presentation.Query;
using Framework.Application.Command;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Presentation.RestApi.Controllers
{
    [Route("api/Question")]
    public class QuestionController : Controller
    {
        private readonly ICommandBus _bus;
        private readonly IQuestionQuery _questionQuery;

        public QuestionController(ICommandBus bus, IQuestionQuery questionQuery)
        {
            _bus = bus;
            _questionQuery = questionQuery;
        }

        [HttpPost]
        public void Create([FromBody]CreateQuestion command)
        {
            _bus.Dispatch(command);
        }

        [HttpGet]
        public List<QuestionDto> Questions()
        {
            return _questionQuery.GetQuestions();
        }
    }
}