using System.Collections.Generic;
using Forum.Application.Tests.Utils;
using Forum.Presentation.Contracts.Query;
using Forum.Presentation.Query;
using Forum.Presentation.RestApi.Controllers;
using Framework.Application.Command;
using Framework.Application.Query;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Forum.Presentation.RestApi.Tests.Unit
{
    public class QuestionControllerTests
    {
        private readonly Mock<ICommandBus> _commandBus;
        private readonly Mock<IQueryBus> _queryBus;
        private readonly QuestionController _controller;

        public QuestionControllerTests()
        {
            _commandBus = new Mock<ICommandBus>();
            _queryBus = new Mock<IQueryBus>();
            _controller = new QuestionController(_commandBus.Object, _queryBus.Object);
        }

        [Fact]
        public void Create_Should_Call_CommandBus_When_Api_Called()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().CreateQuestion;

            //Act
            _controller.Create(command);

            //Assert
            _commandBus.Verify(x => x.Dispatch(command));
        }

        [Fact]
        public void Create_Should_Return_NoContent_Result()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().CreateQuestion;

            //Act
            var result = _controller.Create(command);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Questions_Should_Call_QuestionQuery_When_Api_Called()
        {
            //Act
            _controller.Questions();

            //Assert
            _queryBus.Verify(x => x.Dispatch<List<QuestionDto>>());
        }

        [Fact]
        public void QuestionDetails_Should_Call_QuestionQuery_When_Api_Called()
        {
            //Act
            _controller.QuestionDetails(5);

            //Assert
            _queryBus.Verify(x => x.Dispatch<QuestionDetailsDto, long>(5));
        }

        [Fact]
        public void AddVote_Should_Call_Command_Bus_When_Api_Called()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().AddVote;

            //Act
            _controller.AddVote(command);

            //Assert
            _commandBus.Verify(x=>x.Dispatch(command));
        }

        [Fact]
        public void AddVote_Should_Return_NoContent_Result()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().AddVote;

            //Act
            var result = _controller.AddVote(command);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void ContainsTrueAnswer_Should_Return_NoContent_Result()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().ContainsTrueAnswer;

            //Act
            var result = _controller.ContainsTrueAnswer(command);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}