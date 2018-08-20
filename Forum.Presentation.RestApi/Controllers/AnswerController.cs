using Forum.Presentation.Contracts.Command;
using Forum.Presentation.Contracts.Query;
using Framework.Application.Command;
using Framework.Core;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Presentation.RestApi.Controllers
{
    public class AnswerController : Controller, IGateway
    {
        private readonly ICommandBus _commandBus;

        public AnswerController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPost]
        public void Add([FromBody] AddAnswer command)
        {
            _commandBus.Dispatch(command);
        }
    }
}