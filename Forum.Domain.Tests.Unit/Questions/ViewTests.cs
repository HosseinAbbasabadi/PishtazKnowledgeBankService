using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Models.Users;
using Forum.Domain.Test.Utils;
using Forum.Domain.Test.Utils.Constants;
using Xunit;

namespace Forum.Domain.Tests.Unit.Questions
{
    public class ViewTests
    {
        [Fact]
        public void Constructor_Should_Construct_View_Properly()
        {
            //Arrange
            var viewer = Names.Harry;

            //Act
            var view = new View(viewer);

            //Assert
            Assert.Equal(viewer, view.Viewer);
        }
    }
}