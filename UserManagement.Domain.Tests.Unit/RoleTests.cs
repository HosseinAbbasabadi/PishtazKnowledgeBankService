using FluentAssertions;
using UserManagement.Domain.Models.Roles;
using Xunit;

namespace UserManagement.Domain.Tests.Unit
{
    public class RoleTests
    {
        [Fact]
        public void Constructor_Should_Construct_Role_Properly()
        {
            //Arrange
            var id = new RoleId(5);
            const string name = "administartor";

            //Act
            var role = new Role(id, name);

            //Assert
            role.Id.Should().Be(id);
            role.Name.Should().Be(name);
        }

        [Fact]
        public void RoleId_Constructor_Should_Construct_RoleId_By_Proper_Id()
        {
            //Arrange
            const long id = 3;

            //Act
            var roleId = new RoleId(id);

            //Assert
            roleId.DbId.Should().Be(id);
        }
    }
}