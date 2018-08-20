﻿using Forum.Domain.Test.Utils.Builders;
using Xunit;

namespace Forum.Domain.Tests.Unit.Answers
{
    public class AnswerTests
    {
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
            Assert.False(answer.IsChosen);
        }
    }
}