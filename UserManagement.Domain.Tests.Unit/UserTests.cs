using System;
using System.Collections.Generic;
using FluentAssertions;
using UserManagement.Domain.Utils;
using Xunit;

namespace UserManagement.Domain.Tests.Unit
{
    public class UserTests
    {
        [Fact]
        public void Constructor_Should_Construct_User_Properly()
        {
            //Arrange
            var userBuilder = new UserTestBuilder();

            //Act
            var user = userBuilder.Build();

            //Assert
            user.Id.Should().Be(userBuilder.UserId);
            user.UserName.Should().Be(userBuilder.Username);
            user.Password.Should().Be(userBuilder.Password);
            user.Firstname.Should().Be(userBuilder.Firstname);
            user.Lastname.Should().Be(userBuilder.Lastname);
        }

        [Fact]
        public void UserId_Constructor_Should_Construct_UserId_By_Proper_Id()
        {
            //Arrange
            const long id = 5;

            //Act
            var userId = new UserId(5);

            //Assert
            userId.DbId.Should().Be(id);
        }

        [Fact]
        public void Constructor_Should_Throw_Exception_When_User_Dosnt_Have_Minimum_Number_Of_Roles()
        {
            //Arrange
            var empty = new List<long>();
            var builder = new UserTestBuilder();

            //Act
            Action user = () => builder.WithRoles(empty).Build();

            //Assert
            user.Should().Throw<UserShouldHaveARoleException>();
        }
    }
}