using Forum.Application.Tests.Utils;
using Forum.Presentation.RestApi.Controllers;
using Framework.Application.Command;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Forum.Presentation.RestApi.Tests.Unit
{
    public class TagControllerTests
    {
        private readonly Mock<ICommandBus> _commandBus;
        private readonly TagController _tagController;

        public TagControllerTests()
        {
            _commandBus = new Mock<ICommandBus>();
            _tagController = new TagController(_commandBus.Object);
        }

        [Fact]
        public void Create_Should_Call_CommandBus_When_Api_Called()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().CreateTag;

            //Act
            _tagController.Create(command);

            //Assert
            _commandBus.Verify(x => x.Dispatch(command));
        }

        [Fact]
        public void Create_Should_Return_NoContent_Result_When_Api_Called()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().CreateTag;

            //Act
            var result = _tagController.Create(command);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}