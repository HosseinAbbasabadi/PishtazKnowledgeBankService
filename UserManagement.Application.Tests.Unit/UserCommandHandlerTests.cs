using Moq;
using UserManagement.Domain;
using UserManagement.Domain.Models.Users;
using Xunit;

namespace UserManagement.Application.Tests.Unit
{
    public class UserCommandHandlerTests
    {
        [Fact]
        public void Handle_Should_Call_Create_On_Repository_When_Command_Passed()
        {
            //Arrange
            var repository = new Mock<IUserRepository>();
            var command = CommandFactory.BuildACommandOfType().CreateUser;
            var userCommaneHandler = new UserCommandHandler(repository.Object);

            //Act
            userCommaneHandler.Handle(command);

            //Assert
            repository.Verify(x => x.Create(It.IsAny<User>()));
        }
    }
}