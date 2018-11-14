using System.Collections.Generic;
using Forum.DomainEvents;
using Forum.Infrastructure.ACL.NotificationSystem;
using Forum.Presentation.Contracts;
using Forum.Presentation.Contracts.Command;
using Forum.Presentation.Contracts.Query;
using Framework.Application.Command;
using Framework.Application.Query;
using Framework.Configuration;
using Framework.Core.Events;

namespace Forum.Presentation.Facade
{
    public class AnswerFacadeService : IAnswerFacadeService
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        private readonly IEventListener _eventListener;
        private readonly IFrameworkConfiguration _frameworkConfiguration;
        private readonly AnswerFacadeService _answerFacadeService;
        
        public AnswerFacadeService(ICommandBus commandBus, IQueryBus queryBus, IEventListener eventListener,
            IFrameworkConfiguration frameworkConfiguration)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _eventListener = eventListener;
            _frameworkConfiguration = frameworkConfiguration;
        }

        public void Add(AddAnswer command)
        {
            var eventHandler = new PushNotificationEventHandler<AnswerAdded>();
            eventHandler.SetNotificationUrl(_frameworkConfiguration.GetNotificationUrl());
            try
            {
                _eventListener.Listen(eventHandler);
                _commandBus.Dispatch(command);
            }
            finally
            {
                _eventListener.Clear(eventHandler);
            }

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