using Forum.Application.Tests.Utils;
using Forum.Presentation.Query;
using Forum.Presentation.RestApi.Controllers;
using Framework.Application.Command;
using Moq;
using Xunit;

namespace Forum.Presentation.RestApi.Tests.Unit
{
    public class QuestionControllerTests
    {
        private readonly Mock<ICommandBus> _commandBus;
        private readonly Mock<IQuestionQuery> _questionQuery;

        public QuestionControllerTests()
        {
            _commandBus = new Mock<ICommandBus>();
            _questionQuery = new Mock<IQuestionQuery>();
        }

        [Fact]
        public void Create_Should_Call_CommandBus_When_Api_Called()
        {
            //Arrange
            var controller = new QuestionController(_commandBus.Object, _questionQuery.Object);
            var command = CreateQuestionFactory.Create();

            //Act
            controller.Create(command);

            //Assert
            _commandBus.Verify(x => x.Dispatch(command));
        }


        [Fact]
        public void Question_Should_Call_QuestionQuery_When_Api_Called()
        {
            //Arrange
            var controller = new QuestionController(_commandBus.Object, _questionQuery.Object);

            //Act
            controller.Questions();

            //Assert
            _questionQuery.Verify(x => x.GetQuestions());
        }


        [Fact]
        public void QuestionDetails_Should_Call_QuestionQuery_When_Api_Called()
        {
            //Arrange
            var controller = new QuestionController(_commandBus.Object, _questionQuery.Object);

            //Act
            controller.QuestionDetails(5);

            //Assert
            _questionQuery.Verify(x => x.GetQuestionDetails(5));
        }
    }
}