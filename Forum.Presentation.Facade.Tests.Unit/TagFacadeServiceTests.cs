using System.Collections.Generic;
using Forum.Application.Tests.Utils;
using Forum.Presentation.Contracts.Query;
using Framework.Application.Command;
using Framework.Application.Query;
using Moq;
using Xunit;

namespace Forum.Presentation.Facade.Tests.Unit
{
    public class TagFacadeServiceTests
    {
        private readonly Mock<ICommandBus> _commandBus;
        private readonly Mock<IQueryBus> _queryBus;
        private readonly TagFacadeService _tagFacadeService;

        public TagFacadeServiceTests()
        {
            _commandBus = new Mock<ICommandBus>();
            _queryBus = new Mock<IQueryBus>();
            _tagFacadeService = new TagFacadeService(_commandBus.Object, _queryBus.Object);
        }

        [Fact]
        public void Create_Should_Call_CommandBus_When_Api_Called()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().CreateTag;

            //Act
            _tagFacadeService.Create(command);

            //Assert
            _commandBus.Verify(x => x.Dispatch(command));
        }

        //[Fact]
        //public void Create_Should_Return_NoContent_Result_When_Api_Called()
        //{
        //    //Arrange
        //    var command = CommandFactory.BuildACommandOfType().CreateTag;

        //    //Act
        //    var result = _tagFacadeService.Create(command);

        //    //Assert
        //    Assert.IsType<NoContentResult>(result);
        //}

        [Fact]
        public void Tags_Should_Call_Dispatch_On_TagQuery_When_Api_Called()
        {
            //Act
            _tagFacadeService.Tags();

            //Assert
            _queryBus.Verify(x => x.Dispatch<List<TagDto>>());
        }
    }
}