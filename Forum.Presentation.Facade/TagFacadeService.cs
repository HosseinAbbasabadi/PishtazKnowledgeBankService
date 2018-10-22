using System.Collections.Generic;
using Forum.Presentation.Contracts;
using Forum.Presentation.Contracts.Command;
using Forum.Presentation.Contracts.Query;
using Framework.Application.Command;
using Framework.Application.Query;

namespace Forum.Presentation.Facade
{
    public class TagFacadeService : ITagFacadeService
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public TagFacadeService(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        public void Create(CreateTag command)
        {
            _commandBus.Dispatch(command);
        }

        public List<TagDto> Tags()
        {
            return _queryBus.Dispatch<List<TagDto>>();
        }
    }
}