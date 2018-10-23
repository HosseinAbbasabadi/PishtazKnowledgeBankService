using System.Collections.Generic;
using Forum.DomainEvents;
using Forum.Infrastructure.ACL.NotificationSystem;
using Forum.Presentation.Contracts;
using Forum.Presentation.Contracts.Command;
using Forum.Presentation.Contracts.Query;
using Framework.Application.Command;
using Framework.Application.Query;
using Framework.Core.Events;

namespace Forum.Presentation.Facade
{
    public class QuestionFacadeService : IQuestionFacadeService
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        private readonly IEventListener _eventListener;

        public QuestionFacadeService(ICommandBus commandBus, IQueryBus queryBus, IEventListener eventListener)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _eventListener = eventListener;
        }

        public void Create(CreateQuestion command)
        {
            var eventHandler = new PushNotificationEventHandler<QuestionCreated>();
            _eventListener.Listen(eventHandler);
            _commandBus.Dispatch(command);
            _eventListener.Clear(eventHandler);
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

        public void VerifyQuestion(VerifyQuestion command)
        {
            _commandBus.Dispatch(command);
        }
    }
}