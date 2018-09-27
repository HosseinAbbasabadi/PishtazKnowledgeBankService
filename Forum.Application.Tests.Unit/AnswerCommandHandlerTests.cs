using Forum.Application.Command;
using Forum.Application.Tests.Utils;
using Forum.Domain.Models.Answers;
using Forum.Domain.Test.Utils.Builders;
using Forum.Presentation.Contracts.Command;
using Framework.Identity;
using Moq;
using Xunit;

namespace Forum.Application.Tests.Unit
{
    public class AnswerCommandHandlerTests
    {
        private readonly Mock<IAnswerRepository> _answerRepository;
        private readonly AnswerCommandHandler _answerCommandHandler;

        public AnswerCommandHandlerTests()
        {
            _answerRepository = new Mock<IAnswerRepository>();
            var claimHelper = new Mock<IClaimHelper>();
            _answerCommandHandler = new AnswerCommandHandler(_answerRepository.Object, claimHelper.Object);
        }

        [Fact]
        public void Should_Call_Add_On_Repository_When_Command_Passed()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().AddAnswer;

            //Act
            _answerCommandHandler.Handle(command);

            //Assert
            _answerRepository.Verify(x => x.Create(It.IsAny<Answer>()));
        }

        [Fact]
        public void Should_Call_Update_On_Repository_And_Set_This_As_Chosen_Answer_When_Command_Passed()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().ChosenAnswer;
            var answer = CreateAnswer(command);
            _answerRepository.Setup(a => a.Get(answer.Id)).Returns(answer);
            
            //Act
            _answerCommandHandler.Handle(command);

            //Assert
            _answerRepository.Verify(a => a.Update(answer));
        }

        private static Answer CreateAnswer(ChosenAnswer command)
        {
            return new AnswerTestBuilder().WithId(command.AnswerId).Build();
        }
    }
}