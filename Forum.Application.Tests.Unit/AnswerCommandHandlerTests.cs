using Forum.Application.Tests.Utils;
using Forum.Domain.Models.Answers;
using Framework.Identity;
using Moq;
using Xunit;

namespace Forum.Application.Tests.Unit
{
    public class AnswerCommandHandlerTests
    {
        [Fact]
        public void Should_Call_Add_On_Repository_When_Command_Passed()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().AddAnswer;
            var repository = new Mock<IAnswerRepository>();
            var cliamHelper = new Mock<IClaimHelper>();
            var answerCommandHandler = new AnswerCommandHandler(repository.Object, cliamHelper.Object);

            //Act
            answerCommandHandler.Handle(command);

            //Assert
            repository.Verify(x => x.Create(It.IsAny<Answer>()));
        }
    }
}