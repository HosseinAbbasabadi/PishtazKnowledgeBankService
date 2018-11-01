using System.Collections.Generic;
using Forum.Domain.Models.Answers;
using Forum.Domain.Models.Answers.Exceptions;
using Forum.Domain.Test.Utils.Builders;
using Forum.DomainEvents;
using Framework.Core.Events;
using Moq;
using Xunit;

namespace Forum.Domain.Tests.Unit.Answers
{
    public class AnswerTests
    {
        private readonly AnswerTestBuilder _builder;
        private readonly List<Answer> _answersOfSpecificQuestion;

        public AnswerTests()
        {
            _builder = new AnswerTestBuilder();
            _answersOfSpecificQuestion = _builder.BuildList(3);
        }

        [Fact]
        public void Constructor_Should_Construct_Answer_Properly()
        {
            //Arrange
            var builder = new AnswerTestBuilder();

            //Act
            var answer = builder.Build();

            //Assert
            Assert.Equal(builder.Id, answer.Id);
            Assert.Equal(builder.Body, answer.Body);
            Assert.Equal(builder.Question, answer.Question.DbId);
            Assert.Equal(builder.Responder, answer.Responder.DbId);
        }

        [Fact]
        public void Constructor_Should_Construct_Answer_With_False_IsChosen_State()
        {
            //Arrange
            var builder = new AnswerTestBuilder();

            //Act
            var answer = builder.Build();

            //Assert
            Assert.False(answer.IsChosen);
        }

        [Fact]
        public void SetAsChosenAnswer_Should_Update_Answer_IsChosen_State_To_True()
        {
            //Arrange
            var answer = _builder.Build();

            //Act
            answer.SetAsChosenAnswer(_builder.QuestionInquirer, _builder.PersonWhoIsSettingTheAnswerAsChosen,
                _answersOfSpecificQuestion);

            //Assert
            Assert.True(answer.IsChosen);
        }

        [Fact]
        public void SetAsChosenAnswer_Should_Throw_Exception_When_Answer_Is_Already_Chosen()
        {
            //Arrange
            var answer = _builder.BuildChosenAnswer();

            //Assert
            Assert.Throws<AnswerIsAlreadySetAsChosenException>(() =>
                answer.SetAsChosenAnswer(_builder.QuestionInquirer, _builder.PersonWhoIsSettingTheAnswerAsChosen,
                    _answersOfSpecificQuestion));
        }

        [Fact]
        public void
            SetAsChosenAnswer_Should_Throw_Exception_When_Question_Inquirer_Is_Not_The_Same_Person_Who_Is_Setting_The_Answer_As_Chosen()
        {
            //Arrange
            var answer = _builder.WithDifferentQuestionInquirerAndPersonWhoIsSettingTheAnswerAsChosen().Build();

            //Assert
            Assert.Throws<QuestionInquirerIsNotSameAsTheManInChanrgeException>(() =>
                answer.SetAsChosenAnswer(_builder.QuestionInquirer, _builder.PersonWhoIsSettingTheAnswerAsChosen,
                    _answersOfSpecificQuestion));
        }

        [Fact]
        public void SetAsChosenAnswer_Should_Throw_Exception_When_Question_Already_Has_Chosen_Answer()
        {
            //Arrange
            var chosingAnswer = _builder.Build();
            var chosenAnswer = _builder.BuildChosenAnswer();
            _answersOfSpecificQuestion.Add(chosenAnswer);
            _answersOfSpecificQuestion.Add(chosingAnswer);

            //Assert
            Assert.Throws<QuestionAlreadyHasAChosenAnswerException>(() => chosingAnswer.SetAsChosenAnswer(
                _builder.QuestionInquirer,
                _builder.PersonWhoIsSettingTheAnswerAsChosen,
                _answersOfSpecificQuestion));
        }

        [Fact]
        public void RaseAnswerAdded_Should_Call_Publish_On_EventPublisher_To_Raise_AnswerAdded_Event()
        {
            //Arrange
            var publisher = new Mock<IEventPublisher>();
            var answer = new AnswerTestBuilder().WithEventPublisher(publisher.Object).Build();
            const long relatedUser = 5;
            const string questionTitle = "some question title";
            const string responderName = "some responder name";

            //Act
            answer.RaseAnswerAdded(relatedUser, questionTitle, responderName);

            //Assert
            publisher.Verify(x => x.Publish(It.IsAny<AnswerAdded>()));
        }
    }
}