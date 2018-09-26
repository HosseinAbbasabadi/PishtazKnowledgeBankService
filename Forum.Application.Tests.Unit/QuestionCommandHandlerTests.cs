using Forum.Application.Command;
using Forum.Application.Tests.Utils;
using Forum.Domain.Models.Questions;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Test.Utils.Builders;
using Framework.Identity;
using Moq;
using Xunit;

namespace Forum.Application.Tests.Unit
{
    public class QuestionCommandHandlerTests
    {
        private readonly Mock<IQuestionRepository> _repository;
        private readonly QuestionCommandHandler _questionCommandHandler;

        public QuestionCommandHandlerTests()
        {
            _repository = new Mock<IQuestionRepository>();
            var claimHelper = new Mock<IClaimHelper>();
            _questionCommandHandler = new QuestionCommandHandler(_repository.Object, claimHelper.Object);
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
        public void Should_Call_Get_Then_Update_On_Repository_When_Command_Passed()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().AddVote;
            var question = new QuestionTestBuilder().Build();
            _repository.Setup(x => x.Get(It.IsAny<QuestionId>())).Returns(question);

            //Act
            _questionCommandHandler.Handle(command);

            //Assert
            _repository.Verify(x=>x.Get(question.Id));
            _repository.Verify(x => x.Update(question));
        }
    }
}