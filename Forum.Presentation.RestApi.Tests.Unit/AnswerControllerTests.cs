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
    public class AnswerControllerTests
    {
        private readonly Mock<IAnswerFacadeService> _answerFacadeService;
        private readonly AnswerController _answerController;

        public AnswerControllerTests()
        {
            _answerFacadeService = new Mock<IAnswerFacadeService>();
            _answerController = new AnswerController(_answerFacadeService.Object);
        }

        [Fact]
        public void Post_Should_Call_Add_On_Facade()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().AddAnswer;

            //Act
            _answerController.Post(command);

            //Assert
            _answerFacadeService.Verify(x => x.Add(command));
        }

        [Fact]
        public void Get_Should_Call_Answers_On_Facade()
        {
            //Arrange
            const long questionId = 5;

            //Act
            _answerController.Get(questionId);

            //Assert
            _answerFacadeService.Verify(x => x.Answers(questionId));
        }

        [Fact]
        public void Post_Should_Call_SetAsChosenAnswer_On_Facade()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().ChosenAnswer;

            //Act
            _answerController.Post(command);

            //Assert
            _answerFacadeService.Verify(x => x.SetAsChosenAnswer(command));
        }
    }
}