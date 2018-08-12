using System.Collections.Generic;
using Forum.Domain.Models.Questions;
using Forum.Presentation.Contracts;
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
            var command = new CreateQuestion("some question titlte", "some question body", new List<long> {1, 2, 3});

            //Act
            questionCommandHandler.Handle(command);

            //Assert
            repository.Verify(x => x.Create(It.IsAny<Question>()));
        }
    }
}