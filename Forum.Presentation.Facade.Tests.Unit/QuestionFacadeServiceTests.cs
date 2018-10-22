using System.Collections.Generic;
using Forum.Application.Tests.Utils;
using Forum.Presentation.Contracts.Query;
using Framework.Application.Command;
using Framework.Application.Query;
using Moq;
using Xunit;

namespace Forum.Presentation.Facade.Tests.Unit
{
    public class QuestionFacadeServiceTests
    {
        private readonly Mock<ICommandBus> _commandBus;
        private readonly Mock<IQueryBus> _queryBus;
        private readonly QuestionFacadeService _questionFacadeService;

        public QuestionFacadeServiceTests()
        {
            _commandBus = new Mock<ICommandBus>();
            _queryBus = new Mock<IQueryBus>();
            _questionFacadeService = new QuestionFacadeService(_commandBus.Object, _queryBus.Object);
        }

        [Fact]
        public void Create_Should_Call_Dispatch_On_CommandBus()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().CreateQuestion;

            //Act
            _questionFacadeService.Create(command);

            //Assert
            _commandBus.Verify(x => x.Dispatch(command));
        }

        //[Fact]
        //public void Create_Should_Return_NoContent_Result()
        //{
        //    //Arrange
        //    var command = CommandFactory.BuildACommandOfType().CreateQuestion;

        //    //Act
        //    var result = _controller.Create(command);

        //    //Assert
        //    Assert.IsType<NoContentResult>(result);
        //}

        //[Fact]
        //public void Createa_Should_Return_BadRequest_Result_When_Dispatch_Throws_Exception()
        //{
        //    //Arrange
        //    var command = CommandFactory.BuildACommandOfType().CreateQuestion;
        //    _commandBus.Setup(x => x.Dispatch(command)).Throws<Exception>();

        //    //Act
        //    var result = _controller.Create(command);

        //    //Assert
        //    Assert.IsType<BadRequestObjectResult>(result);
        //}

        [Fact]
        public void Questions_Should_Call_Dispatch_On_QuestionQuery()
        {
            //Act
            _questionFacadeService.Questions();

            //Assert
            _queryBus.Verify(x => x.Dispatch<List<QuestionDto>>());
        }

        [Fact]
        public void QuestionDetails_Should_Call_Dispatch_On_QuestionQuery()
        {
            //Act
            _questionFacadeService.QuestionDetails(5);

            //Assert
            _queryBus.Verify(x => x.Dispatch<QuestionDetailsDto, long>(5));
        }

        [Fact]
        public void AddVote_Should_Call_Dispatch_On_Command_Bus()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().AddVote;

            //Act
            _questionFacadeService.AddVote(command);

            //Assert
            _commandBus.Verify(x => x.Dispatch(command));
        }

        //[Fact]
        //public void AddVote_Should_Return_NoContent_Result()
        //{
        //    //Arrange
        //    var command = CommandFactory.BuildACommandOfType().AddVote;

        //    //Act
        //    var result = _questionFacadeService.AddVote(command);

        //    //Assert
        //    Assert.IsType<NoContentResult>(result);
        //}

        [Fact]
        public void ContainsTrueAnswer_Should_Call_Dispatch_On_CommandBus()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().ContainsTrueAnswer;

            //Act
            _questionFacadeService.ContainsTrueAnswer(command);

            //Assert
            _commandBus.Verify(x => x.Dispatch(command));
        }

        [Fact]
        public void VerifyQuestion_Should_Call_Dispatch_On_CommandBus()
        {
            var command = CommandFactory.BuildACommandOfType().VerifyQuestion;

            _questionFacadeService.VerifyQuestion(command);

            _commandBus.Verify(x => x.Dispatch(command));
        }
    }
}