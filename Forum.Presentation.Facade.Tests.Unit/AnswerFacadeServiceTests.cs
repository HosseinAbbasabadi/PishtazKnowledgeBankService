using System.Collections.Generic;
using Forum.Application.Tests.Utils;
using Forum.DomainEvents;
using Forum.Infrastructure.ACL.NotificationSystem;
using Forum.Presentation.Contracts.Query;
using Framework.Application.Command;
using Framework.Application.Query;
using Framework.Configuration;
using Framework.Core.Events;
using Moq;
using Xunit;

namespace Forum.Presentation.Facade.Tests.Unit
{
    public class AnswerFacadeServiceTests
    {
        private readonly Mock<ICommandBus> _commandBus;
        private readonly Mock<IQueryBus> _queryBus;
        private readonly Mock<IEventListener> _eventListener;
        private readonly Mock<IFrameworkConfiguration> _frameworkConfiguration;
        private readonly AnswerFacadeService _answerFacadeService;

        public AnswerFacadeServiceTests()
        {
            _commandBus = new Mock<ICommandBus>();
            _queryBus = new Mock<IQueryBus>();
            _eventListener = new Mock<IEventListener>();
            _frameworkConfiguration = new Mock<IFrameworkConfiguration>();
            _answerFacadeService = new AnswerFacadeService(_commandBus.Object, _queryBus.Object, _eventListener.Object, _frameworkConfiguration.Object);
        }

        [Fact]
        public void Add_Should_Call_Dispatch_On_Bus_When_Api_Called()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().AddAnswer;

            //Act
            _answerFacadeService.Add(command);

            //Assert
            _commandBus.Verify(x => x.Dispatch(command));
        }

        [Fact]
        public void Answers_Should_Call_Dispatch_On_Bus_When_Api_Called()
        {
            //Arrange
            const long questionId = 5;

            //Act
            _answerFacadeService.Answers(questionId);

            //Assert
            _queryBus.Verify(x => x.Dispatch<List<AnswerDto>, long>(questionId));
        }

        [Fact]
        public void SetAsChosenAnswer_Should_Call_Dispatch_On_Bus_When_Api_Called_And_Return_NoContent_Result()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().ChosenAnswer;

            //Act
            _answerFacadeService.SetAsChosenAnswer(command);

            //Assert
            _commandBus.Verify(a => a.Dispatch(command));
        }

        [Fact]
        public void SetAsChosenAnswer_Should_Listen_To_PushNotificationEventHandler_With_AnswerChoosed_Event()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().ChosenAnswer;

            //Act
            _answerFacadeService.SetAsChosenAnswer(command);

            //Assert
            _eventListener.Verify(x=>x.Listen(It.IsAny<PushNotificationEventHandler<AnswerChoosed>>()));
        }
    }
}