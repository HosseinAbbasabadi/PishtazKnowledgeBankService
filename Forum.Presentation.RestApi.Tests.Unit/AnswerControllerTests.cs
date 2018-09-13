using System.Collections.Generic;
using Forum.Application.Tests.Utils;
using Forum.Presentation.Contracts.Query;
using Forum.Presentation.RestApi.Controllers;
using Framework.Application.Command;
using Framework.Application.Query;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Forum.Presentation.RestApi.Tests.Unit
{
    public class AnswerControllerTests
    {
        private readonly Mock<ICommandBus> _commandBus;
        private readonly Mock<IQueryBus> _queryBus;
        private readonly AnswerController _controller;

        public AnswerControllerTests()
        {
            _commandBus = new Mock<ICommandBus>();
            _queryBus = new Mock<IQueryBus>();
            _controller = new AnswerController(_commandBus.Object, _queryBus.Object);
        }

        [Fact]
        public void Add_Should_Call_Bus_When_Api_Called()
        {
            //Arrange
            var command = CommandFactory.BuildAnInstanceOfType().AddAnswer;

            //Act
            _controller.Add(command);

            //Assert
            _commandBus.Verify(x => x.Dispatch(command));
        }

        [Fact]
        public void Add_Should_Return_NoContent_Result()
        {
            //Arrange
            var command = CommandFactory.BuildAnInstanceOfType().AddAnswer;

            //Act
            var resutl = _controller.Add(command);

            //Assert
            Assert.IsType<NoContentResult>(resutl);
        }

        [Fact]
        public void Answers_Should_Call_Bus_When_Api_Called()
        {
            //Arrange
            const long questionId = 5;

            //Act
            _controller.Answers(questionId);

            //Assert
            _queryBus.Verify(x => x.Dispatch<List<AnswerDto>, long>(questionId));
        }
    }
}