using Forum.Application.Command;
using Forum.Application.Tests.Utils;
using Forum.Domain.Models.Questions;
using Forum.Domain.Models.Questions.Services;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Test.Utils.Builders;
using Forum.Domin.Contracts.Services;
using Framework.Core.Events;
using Framework.Identity;
using Moq;
using Xunit;

namespace Forum.Application.Tests.Unit
{
    public class QuestionCommandHandlerTests
    {
        private readonly QuestionTestBuilder _builder;
        private readonly Mock<IQuestionRepository> _repository;
        private readonly QuestionCommandHandler _questionCommandHandler;
        private readonly Mock<IEventPublisher> _eventPublisher;
        private readonly Mock<IUserService> _userService;
        private readonly Mock<IQuestionNotificationService> _questionNotificationService;
        public QuestionCommandHandlerTests()
        {
            _builder = new QuestionTestBuilder();
            _repository = new Mock<IQuestionRepository>();
            var claimHelper = new Mock<IClaimHelper>();
            _eventPublisher = new Mock<IEventPublisher>();
            _userService = new Mock<IUserService>();
            _questionNotificationService = new Mock<IQuestionNotificationService>();
            _questionCommandHandler = new QuestionCommandHandler(_repository.Object, claimHelper.Object, _eventPublisher.Object, _userService.Object, _questionNotificationService.Object);
        }

        [Fact]
        public void Should_Call_Create_On_Repository_When_Command_Passed()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().CreateQuestion;

            //Act
            _questionCommandHandler.Handle(command);

            //Assert
            _repository.Verify(x => x.Create(It.IsAny<Question>()));
        }


        [Fact]
        public void Should_Call_Get_Then_Update_On_Repository_When_AddVote_Command_Passed()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().AddVote;
            var question = _builder.Build();
            _repository.Setup(x => x.Get(It.IsAny<QuestionId>())).Returns(question);

            //Act
            _questionCommandHandler.Handle(command);

            //Assert
            _repository.Verify(x => x.Get(question.Id));
            _repository.Verify(x => x.Update(question));
        }

        [Fact]
        public void Should_Call_Get_Then_Update_On_Repository_When_ContainsTrueAnswser_Command_Passed()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().ContainsTrueAnswer;
            var question = _builder.WithId(command.QuestionId).Build();
            _repository.Setup(x => x.Get(It.IsAny<QuestionId>())).Returns(question);

            //Act
            _questionCommandHandler.Handle(command);

            //Assert
            _repository.Verify(x => x.Get(question.Id));
            _repository.Verify(x => x.Update(question));
        }

        [Fact]
        public void Should_Call_Update_On_Repository_When_VerifyQuestion_Command_Passed()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().VerifyQuestion;
            var question = _builder.WithId(command.QuestionId).Build();
            _repository.Setup(z => z.Get(question.Id)).Returns(question);

            //Act
            _questionCommandHandler.Handle(command);

            //Assert
            _repository.Verify(x => x.Update(question));
        }
    }
}