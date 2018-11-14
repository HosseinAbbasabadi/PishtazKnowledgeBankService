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
    public class QuestionFacadeServiceTests
    {
        private readonly Mock<ICommandBus> _commandBus;
        private readonly Mock<IQueryBus> _queryBus;
        private readonly Mock<IEventListener> _eventListener;
        private readonly Mock<IFrameworkConfiguration> _frameworkConfiguration;
        private readonly QuestionFacadeService _questionFacadeService;

        public QuestionFacadeServiceTests()
        {
            _commandBus = new Mock<ICommandBus>();
            _queryBus = new Mock<IQueryBus>();
            _eventListener = new Mock<IEventListener>();
            _frameworkConfiguration = new Mock<IFrameworkConfiguration>();
            _questionFacadeService = new QuestionFacadeService(_commandBus.Object, _queryBus.Object,
                _eventListener.Object, _frameworkConfiguration.Object);
        }

        [Fact]
        public void Create_Should_Call_Dispatch_On_CommandBus()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().CreateQuestion;

            //Act
            _questionFacadeService.Create(command);

            //Assert
            _commandBus.Verify(x => x.Dispatch(command));
        }

        //[Fact]
        //public void Create_Should_Call_SetNotificationUrl_And_Listen_To_QuestionCreated_Event()
        //{
        //    //Arrange
        //    var eventHandler = new PushNotificationEventHandler<QuestionCreated>();
        //    var command = CommandFactory.BuildACommandOfType().CreateQuestion;

        //    //Act
        //    _questionFacadeService.Create(command);

        //    //Assert
        //    _eventListener.Verify(x => x.Listen(eventHandler));
        //}

        [Fact]
        public void Questions_Should_Call_Dispatch_On_QuestionQuery()
        {
            //Act
            _questionFacadeService.Questions();

            //Assert
            _queryBus.Verify(x => x.Dispatch<List<QuestionDto>>());
        }

        [Fact]
        public void QuestionDetails_Should_Call_Dispatch_On_QuestionQuery()
        {
            //Act
            _questionFacadeService.QuestionDetails(5);

            //Assert
            _queryBus.Verify(x => x.Dispatch<QuestionDetailsDto, long>(5));
        }

        [Fact]
        public void AddVote_Should_Call_Dispatch_On_Command_Bus()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().AddVote;

            //Act
            _questionFacadeService.AddVote(command);

            //Assert
            _commandBus.Verify(x => x.Dispatch(command));
        }

        [Fact]
        public void ContainsTrueAnswer_Should_Call_Dispatch_On_CommandBus()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().ContainsTrueAnswer;

            //Act
            _questionFacadeService.ContainsTrueAnswer(command);

            //Assert
            _commandBus.Verify(x => x.Dispatch(command));
        }

        [Fact]
        public void VerifyQuestion_Should_Call_Dispatch_On_CommandBus()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().VerifyQuestion;

            //Act
            _questionFacadeService.VerifyQuestion(command);

            //Assert
            _commandBus.Verify(x => x.Dispatch(command));
        }

        [Fact]
        public void ModifyQuestion_Should_Call_Dispatch_On_CommandBus()
        {
            //Arrage
            var command = CommandFactory.BuildACommandOfType().ModifyQuestion;

            //Act
            _questionFacadeService.ModifyQuestion(command);

            //Assert
            _commandBus.Verify(x => x.Dispatch(command));
        }

        [Fact]
        public void AddView_Should_Call_Dispatch_On_CommandBus()
        {
            //Arrage
            var command = CommandFactory.BuildACommandOfType().AddView;

            //Act
            _questionFacadeService.AddView(command);

            //Assert
            _commandBus.Verify(x => x.Dispatch(command));
        }
    }
}