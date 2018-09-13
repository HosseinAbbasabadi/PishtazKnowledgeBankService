using Framework.Application.Command;
using Moq;
using UserManagement.Application.Tests.Unit;
using UserManagement.Presentation.RestApi.Controllers;
using Xunit;

namespace UserManagement.Presentation.RestApi.Tests.Unit
{
    public class UserControllerTests
    {
        [Fact]
        public void Create_Should_Call_Dispatch_On_Bus()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().CreateUser;
            var commandbus = new Mock<ICommandBus>();
            var userController = new UserController(commandbus.Object);

            //Act
            userController.Create(command);

            //Assert
            commandbus.Verify(x => x.Dispatch(command));
        }
    }
}