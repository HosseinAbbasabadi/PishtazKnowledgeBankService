using Forum.Application.Tests.Utils;
using Forum.Presentation.RestApi.Controllers;
using Framework.Application.Command;
using Moq;
using Xunit;

namespace Forum.Presentation.RestApi.Tests.Unit
{
    public class AnswerControllerTests
    {
        [Fact]
        public void Add_Should_Call_Bus_When_Api_Called()
        {
            //Arrange
            var commandBus = new Mock<ICommandBus>();
            var command = CommandFactory.Build().AddAnswer;
            var controller = new AnswerController(commandBus.Object);

            //Act
            controller.Add(command);

            //Assert
            commandBus.Verify(x => x.Dispatch(command));
        }
    }
}