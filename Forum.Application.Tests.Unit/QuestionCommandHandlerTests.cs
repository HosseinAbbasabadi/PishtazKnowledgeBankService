using Forum.Application.Tests.Utils;
using Forum.Domain.Models.Questions;
using Moq;
using Xunit;

namespace Forum.Application.Tests.Unit
{
    public class QuestionCommandHandlerTests
    {
        [Fact]
        public void Should_Call_Create_On_Repository_When_Command_Passed()
        {
            //Arrange
            var repository = new Mock<IQuestionRepository>();
            var questionCommandHandler = new QuestionCommandHandler(repository.Object);
            var command = CommandFactory.Build().CreateQuestion;

            //Act
            questionCommandHandler.Handle(command);

            //Assert
            repository.Verify(x => x.Create(It.IsAny<Question>()));
        }
    }
}