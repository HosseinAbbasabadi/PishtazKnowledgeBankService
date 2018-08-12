using System;
using Forum.Domain.Models.Users;
using Forum.Domain.Test.Utils;
using Xunit;

namespace Forum.Domain.Tests.Unit.Users
{
    public class UserTests
    {
        private readonly UserTestBuilder _builder;

        public UserTests()
        {
            _builder = new UserTestBuilder();
        }

        [Fact]
        public void Constructor_Should_Construct_User_Properly()
        {
            //Act
            var user = _builder.Build();

            //Assert
            Assert.Equal(_builder.Id, user.Id.DbId);
            Assert.Equal(_builder.Firstname, user.Firstname);
            Assert.Equal(_builder.Lastname, user.Lastname);
        }


        [Fact]
        public void Constructor_Should_Throw_Exception_When_User_Is_Invalid()
        {
            //Arrange
            _builder.WithId(0);

            //Assert
            Assert.Throws<InvalidUserException>(() => _builder.Build());
        }
    }
}