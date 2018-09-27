using System;
using Forum.Domain.Models.Answers.Exceptions;
using Forum.Domain.Test.Utils.Builders;
using Xunit;

namespace Forum.Domain.Tests.Unit.Answers
{
    public class AnswerTests
    {
        private readonly AnswerTestBuilder _builder;

        public AnswerTests()
        {
            _builder = new AnswerTestBuilder();
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
            answer.SetAsChosenAnswer(_builder.QuestionInquirer, _builder.PersonWhoIsSettingTheAnswerAsChosen);

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
                answer.SetAsChosenAnswer(_builder.QuestionInquirer, _builder.PersonWhoIsSettingTheAnswerAsChosen));
        }

        [Fact]
        public void
            SetAsChosenAnswer_Should_Throw_Exception_When_Question_Inquirer_Is_Not_The_Same_Person_Who_Is_Setting_The_Answer_As_Chosen()
        {
            //Arrange
            var answer = _builder.WithDifferentQuestionInquirerAndPersonWhoIsSettingTheAnswerAsChosen().Build();

            //Assert
            Assert.Throws<QuestionInquirerIsNotSameAsTheManInChanrgeException>(() =>
                answer.SetAsChosenAnswer(_builder.QuestionInquirer, _builder.PersonWhoIsSettingTheAnswerAsChosen));
        }
    }
}