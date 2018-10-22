using System;
using System.Collections.Generic;
using System.Text;
using Forum.Application.Tests.Utils;
using Forum.Presentation.Contracts;
using Forum.Presentation.RestApi.Controllers;
using Moq;
using Xunit;

namespace Forum.Presentation.Facade.Tests.Unit
{
    public class TagControllerTests
    {
        private readonly Mock<ITagFacadeService> _tagFacadeService;
        private readonly TagController _tagController;

        public TagControllerTests()
        {
            _tagFacadeService = new Mock<ITagFacadeService>();
            _tagController = new TagController(_tagFacadeService.Object);
        }

        [Fact]
        public void Post_Should_Call_Create_On_Facade()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().CreateTag;

            //Act
            _tagController.Post(command);

            //Assert
            _tagFacadeService.Verify(x => x.Create(command));
        }

        [Fact]
        public void Get_Should_Call_Tags_On_Facade()
        {
            //Act
            _tagController.Get();

            //Assert
            _tagFacadeService.Verify(x => x.Tags());
        }
    }
}