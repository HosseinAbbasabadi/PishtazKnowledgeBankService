using System.Collections.Generic;
using Forum.Presentation.Contracts;
using Forum.Presentation.Contracts.Command;
using Forum.Presentation.Contracts.Query;
using Framework.Application.Command;
using Framework.Application.Query;

namespace Forum.Presentation.Facade
{
    public class AnswerFacadeService : IAnswerFacadeService
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public AnswerFacadeService(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        public void Add(AddAnswer command)
        {
            _commandBus.Dispatch(command);
        }

        public List<AnswerDto> Answers(long questionId)
        {
            return _queryBus.Dispatch<List<AnswerDto>, long>(questionId);
        }

        public void SetAsChosenAnswer(ChosenAnswer command)
        {
            _commandBus.Dispatch(command);
        }
    }
}