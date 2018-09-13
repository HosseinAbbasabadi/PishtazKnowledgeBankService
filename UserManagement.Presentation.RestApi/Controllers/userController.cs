using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Application.Command;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Interface.Facade.Contract;

namespace UserManagement.Presentation.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ICommandBus _commandBus;

        public UserController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPost]
        public void Create([FromBody] CreateUser command)
        {
            _commandBus.Dispatch(command);
        }
    }
}