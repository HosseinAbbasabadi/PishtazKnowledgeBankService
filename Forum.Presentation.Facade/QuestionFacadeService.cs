using System.Collections.Generic;
using Forum.Presentation.Contracts;
using Forum.Presentation.Contracts.Command;
using Forum.Presentation.Contracts.Query;
using Framework.Application.Command;
using Framework.Application.Query;

namespace Forum.Presentation.Facade
{
    public class QuestionFacadeService : IQuestionFacadeService
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public QuestionFacadeService(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        public void Create(CreateQuestion command)
        {
            _commandBus.Dispatch(command);
        }

        public List<QuestionDto> Questions()
        {
            var questions = _queryBus.Dispatch<List<QuestionDto>>();
            return questions;
        }

        public QuestionDetailsDto QuestionDetails(long id)
        {
            return _queryBus.Dispatch<QuestionDetailsDto, long>(id);
        }

        public void AddVote(AddVote command)
        {
            _commandBus.Dispatch(command);
        }

        public void ContainsTrueAnswer(ContainsTrueAnswer command)
        {
           _commandBus.Dispatch(command);
        }
    }
}