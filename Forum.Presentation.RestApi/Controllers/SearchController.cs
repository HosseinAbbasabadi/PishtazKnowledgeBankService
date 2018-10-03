using System.Collections.Generic;
using Forum.Presentation.Contracts.Query;
using Framework.Application.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Presentation.RestApi.Controllers
{
    [Route("api/Search")]
    [Produces("application/json")]
    [Authorize]
    public class SearchController : ControllerBase
    {
        private readonly IQueryBus _queryBus;

        public SearchController(IQueryBus queryBus)
        {
            _queryBus = queryBus;
        }

        [HttpGet]
        public List<QuestionDto> Search(string expression)
        {
            return _queryBus.Dispatch<List<QuestionDto>, string>(expression);
        }
    }
}