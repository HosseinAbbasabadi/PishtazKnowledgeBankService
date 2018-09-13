using FluentAssertions;
using UserManagement.Domain.Models.Users;
using Xunit;

namespace UserManagement.Domain.Tests.Unit
{
    public class UserRoleIdTests
    {
        [Fact]
        public void Constructor_Should_Construct_UserRoleId_By_Proper_Id()
        {
            //Arrange
            const long value = 5;

            //Act
            var userRoleId = new UserRoleId(value);

            //Assert
            userRoleId.Value.Should().Be(value);
        }
    }
}