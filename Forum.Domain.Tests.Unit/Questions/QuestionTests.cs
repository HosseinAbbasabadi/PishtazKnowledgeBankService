using System.Collections.Generic;
using Forum.Domain.Models.Questions.Exceptions;
using Forum.Domain.Test.Utils;
using Xunit;

namespace Forum.Domain.Tests.Unit.Questions
{
    public class QuestionTests
    {
        private readonly QuestionTestBuilder _builder;

        public QuestionTests()
        {
            _builder = new QuestionTestBuilder();
        }

        [Fact]
        public void Constructor_Should_Construct_Question_Properly()
        {
            //Act
            var question = _builder.Build();

            //Assert
            Assert.Equal(_builder.Id, question.Id);
            Assert.Equal(_builder.Title, question.Title);
            Assert.Equal(_builder.Body, question.Body);
            Assert.Equal(_builder.Tags.Count, question.Tags.Count);
            Assert.Equal(_builder.Inquirer, question.Inquirer);
        }

        [Fact]
        public void Constructor_Should_Provide_UnAnswered_Question()
        {
            //Act
            var question = _builder.Build();

            //Assert
            Assert.False(question.HasTrueAnswer);
        }

        [Fact]
        public void Constructor_Should_Throw_Exception_When_Tags_Are_Less_Than_3()
        {
            //Arrange
            var tags = new List<long>() {1, 2};
            _builder.WithTags(tags);

            //Assert
            Assert.Throws<TagsAreLessThan3Exception>(() => { _builder.Build(); });
        }

        [Fact]
        public void Constructor_Should_Construct_Question_With_Zero_Views()
        {
            //Arrange

            //Act
            var question = _builder.Build();

            //Assert
            Assert.Empty(question.Views);
        }

        [Fact]
        public void Constructor_Should_Construct_Question_With_Zero_Votes()
        {
            //Arrange


            //Act
            var question = _builder.Build();

            //Assert
            Assert.Empty(question.Votes);
        }

        [Fact]
        public void Constructor_Should_Map_Ids_To_TagId_When_List_Of_Tags_Passed()
        {
            //Arrange
            _builder.WithTags(new List<long> {1, 2, 3});

            //Act
            var question = _builder.Build();

            //Assert
            Assert.Equal(_builder.Tags.Count, question.Tags.Count);
        }
    }
}