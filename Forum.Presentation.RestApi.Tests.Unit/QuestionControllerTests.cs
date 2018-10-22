using Forum.Application.Tests.Utils;
using Forum.Presentation.Contracts;
using Forum.Presentation.RestApi.Controllers;
using Moq;
using Xunit;

namespace Forum.Presentation.Facade.Tests.Unit
{
    public class QuestionControllerTests
    {
        private readonly Mock<IQuestionFacadeService> _questionFacadeService;
        private readonly QuestionController _questionController;

        public QuestionControllerTests()
        {
            _questionFacadeService = new Mock<IQuestionFacadeService>();
            this._questionController = new QuestionController(_questionFacadeService.Object);
        }

        [Fact]
        public void Post_Should_Call_Create_On_Facade()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().CreateQuestion;

            //Act
            _questionController.Post(command);

            //Assert
            _questionFacadeService.Verify(x => x.Create(command));
        }

        [Fact]
        public void Get_Should_Call_Questions_On_Facade()
        {
            //Act
            _questionController.Get();

            //Assert
            _questionFacadeService.Verify(x => x.Questions());
        }

        [Fact]
        public void Get_Should_Call_QuestionDetails_On_Facade_When_Question_Id_Passed()
        {
            //Arrange
            const long questionId = 6;

            //Act
            _questionController.Get(questionId);

            //Assert
            _questionFacadeService.Verify(x => x.QuestionDetails(questionId));
        }

        [Fact]
        public void Put_Should_Call_AddVote_On_Facade()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().AddVote;

            //Act
            _questionController.Put(command);

            //Assert
            _questionFacadeService.Verify(x => x.AddVote(command));
        }

        [Fact]
        public void Put_Should_Call_ContainsTrueAnswer_On_Facade()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().ContainsTrueAnswer;

            //Act
            _questionController.Put(command);

            //Assert
            _questionFacadeService.Verify(x => x.ContainsTrueAnswer(command));
        }

        [Fact]
        public void Post_Should_Call_VerifyQuestion_On_Facade()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().VerifyQuestion;

            //Act
            _questionController.Post(command);

            //Assert
            _questionFacadeService.Verify(x => x.VerifyQuestion(command));
        }
    }
}