using System.Collections.Generic;
using Forum.Application.Command;
using Forum.Application.Tests.Utils;
using Forum.Domain.Models.Answers;
using Forum.Domain.Models.Questions;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Test.Utils.Builders;
using Forum.Domain.Test.Utils.Constants;
using Forum.Domin.Contracts.Services;
using Forum.Presentation.Contracts.Command;
using Framework.Core.Events;
using Framework.Identity;
using Moq;
using Xunit;

namespace Forum.Application.Tests.Unit
{
    public class AnswerCommandHandlerTests
    {
        private readonly Mock<IAnswerRepository> _answerRepository;
        private readonly Mock<IUserService> _userService;
        private readonly Mock<IQuestionRepository> _questionRepository;
        private readonly AnswerCommandHandler _answerCommandHandler;

        public AnswerCommandHandlerTests()
        {
            var eventPublisher = new Mock<IEventPublisher>();
            var eventListener = new Mock<IEventListener>();
            _userService = new Mock<IUserService>();
            _answerRepository = new Mock<IAnswerRepository>();
            _questionRepository = new Mock<IQuestionRepository>();
            var claimHelper = new Mock<IClaimHelper>();
            _answerCommandHandler =
                new AnswerCommandHandler(_answerRepository.Object, claimHelper.Object, eventPublisher.Object,
                    eventListener.Object, _questionRepository.Object, _userService.Object);
        }

        [Fact]
        public void Should_Call_Add_On_Repository_When_Command_Passed()
        {
            //Arrange

            var command = CommandFactory.BuildACommandOfType().AddAnswer;
            var question = new QuestionTestBuilder().Build();
            _userService.Setup(x => x.GetUserFullName(Names.Hossein)).Returns("hossein abbasabadi");
            _questionRepository.Setup(x => x.Get(new QuestionId(command.Question))).Returns(question);

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
            var answersOfSpecificQuestion = CreateAnswers(3);
            answersOfSpecificQuestion.Add(answer);
            _answerRepository.Setup(a => a.Get(answer.Id)).Returns(answer);
            var questionId = new QuestionId(command.QuestionId);
            _answerRepository.Setup(a => a.GetByQuestionId(questionId)).Returns(answersOfSpecificQuestion);

            //Act
            _answerCommandHandler.Handle(command);

            //Assert
            _answerRepository.Verify(a => a.Update(answer));
        }

        private static Answer CreateAnswer(ChosenAnswer command)
        {
            return new AnswerTestBuilder().WithId(command.AnswerId).Build();
        }

        private static List<Answer> CreateAnswers(int count)
        {
            return new AnswerTestBuilder().BuildList(count);
        }
    }
}