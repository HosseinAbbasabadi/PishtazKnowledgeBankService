using Forum.Application.Tests.Utils;
using Forum.Presentation.RestApi.Controllers;
using Framework.Application.Command;
using Moq;
using Xunit;

namespace Forum.Presentation.RestApi.Tests.Unit
{
    public class QuestionControllerTests
    {
        [Fact]
        public void Create_Should_Call_CommandBus_When_Api_Called()
        {
            //Arrange
            var commandBus = new Mock<ICommandBus>();
            var controller = new QuestionController(commandBus.Object);
            var command = CreateQuestionFactory.Create();

            //Act
            controller.Create(command);

            //Assert
            commandBus.Verify(x => x.Dispatch(command));
        }
    }
}