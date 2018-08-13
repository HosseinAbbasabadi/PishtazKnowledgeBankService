using Forum.Presentation.Contracts;
using Framework.Application.Command;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Presentation.RestApi.Controllers
{
    [Route("api/Question")]
    public class QuestionController : Controller
    {
        public readonly ICommandBus Bus;

        public QuestionController(ICommandBus bus)
        {
            Bus = bus;
        }

        [HttpPost]
        public void Create([FromBody]CreateQuestion command)
        {
            Bus.Dispatch(command);
        }
    }
}