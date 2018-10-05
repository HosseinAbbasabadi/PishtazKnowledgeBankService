using System;
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
        public void Add_Should_Call_Dispatch_On_Bus_When_Api_Called()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().AddAnswer;

            //Act
            _controller.Add(command);

            //Assert
            _commandBus.Verify(x => x.Dispatch(command));
        }

        [Fact]
        public void Add_Should_Call_Dispatch_On_Bus_When_Api_Called_And_Return_NoContent_Result()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().AddAnswer;

            //Act
            var result = _controller.Add(command);

            //Assert
            _commandBus.Verify(a=>a.Dispatch(command));
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Answers_Should_Call_Dispatch_On_Bus_When_Api_Called()
        {
            //Arrange
            const long questionId = 5;

            //Act
            _controller.Answers(questionId);

            //Assert
            _queryBus.Verify(x => x.Dispatch<List<AnswerDto>, long>(questionId));
        }

        [Fact]
        public void SetAsChosenAnswer_Should_Call_Dispatch_On_Bus_When_Api_Called_And_Return_NoContent_Result()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().ChosenAnswer;

            //Act
            var result = _controller.SetAsChosenAnswer(command);

            //Assert
            _commandBus.Verify(a=>a.Dispatch(command));
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void SetAsChosenAnswer_Should_Return_BadRequest_Result_When_Dispatch_Throws_An_Exception()
        {
            ////Arrange
            //var command = CommandFactory.BuildACommandOfType().ChosenAnswer;
            //_commandBus.Setup(z => z.Dispatch(command)).Throws<Exception>();

            ////Act
            //var result = _controller.SetAsChosenAnswer(command);

            ////Assert
            //Assert.IsType<>()
        }
    }
}