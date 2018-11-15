﻿using Forum.Domain.Models.Answers.Exceptions;
using Forum.Domain.Test.Utils.Builders;
using Forum.DomainEvents;
using Framework.Core.Events;
using Framework.Core.Exceptions;
using Moq;
using Xunit;

namespace Forum.Domain.Tests.Unit.Answers
{
    public class AnswerTests
    {
        private readonly AnswerTestBuilder _builder;
        private readonly Mock<IEventPublisher> _eventPublisher;

        public AnswerTests()
        {
            _builder = new AnswerTestBuilder();
            _eventPublisher = new Mock<IEventPublisher>();
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
        public void Consatructor_Should_Throw_Exception_When_Body_Is_Null_Or_EmptyString()
        {
            //Arrange
            _builder.WithBody(null);

            //Assert
            Assert.Throws<RequiredDataIsNullOrEmptyException>(() => _builder.Build());
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
            answer.SetAsChosenAnswer();

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
                answer.SetAsChosenAnswer());
        }

        [Fact]
        public void SetAsChosenAnswer_Should_Rase_AnswerChoosed_Event()
        {
            //Arrange
            var answer = _builder.WithEventPublisher(_eventPublisher.Object).Build();

            //Act
            answer.SetAsChosenAnswer();

            //Assert
            _eventPublisher.Verify(x => x.Publish(It.IsAny<AnswerChoosed>()));
        }

        //[Fact]
        //public void SetAsChosenAnswer_Should_Throw_Exception_When_Question_Already_Has_Chosen_Answer()
        //{
        //    //Arrange
        //    var chosingAnswer = _builder.Build();
        //    var chosenAnswer = _builder.BuildChosenAnswer();
        //    _answersOfSpecificQuestion.Add(chosenAnswer);
        //    _answersOfSpecificQuestion.Add(chosingAnswer);

        //    //Assert
        //    Assert.Throws<QuestionAlreadyHasAChosenAnswerException>(() =>
        //        chosingAnswer.SetAsChosenAnswer(_builder.QuestionInquirer, _answersOfSpecificQuestion));
        //}

        [Fact]
        public void RaseAnswerAdded_Should_Call_Publish_On_EventPublisher_To_Raise_AnswerAdded_Event()
        {
            //Arrange
            var answer = new AnswerTestBuilder().WithEventPublisher(_eventPublisher.Object).Build();
            const long relatedUser = 5;
            const string questionTitle = "some question title";
            const string responderName = "some responder name";

            //Act
            answer.RaseAnswerAdded(relatedUser, questionTitle, responderName);

            //Assert
            _eventPublisher.Verify(x => x.Publish(It.IsAny<AnswerAdded>()));
        }
    }
}