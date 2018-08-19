using System;
using System.Collections.Generic;
using Forum.Domain.Models.Questions.Exceptions;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Models.Users;
using Forum.Domain.Test.Utils;
using Forum.Domain.Test.Utils.Builders;
using Forum.Domain.Test.Utils.Constants;
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
            //Act
            var question = _builder.Build();

            //Assert
            Assert.Empty(question.Views);
        }

        [Fact]
        public void Constructor_Should_Construct_Question_With_Zero_Votes()
        {
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

        [Fact]
        public void Vote_Should_Add_A_Vote_To_Votes_Of_Question_When_Vote_Passed()
        {
            //Arrange
            var harry = Names.Harry;
            var vote = new Vote(harry, false);
            var question = _builder.Build();

            //Act
            question.Vote(vote);

            //Assert
            Assert.Equal(1, question.Votes.Count);
        }

        [Fact]
        public void Vote_Should_Throw_Exception_When_The_Voter_Is_Duplicated()
        {
            //Arrange
            var votes = VoteFactory(3);
            var duplicateVoter = new UserId(1);
            var duplicateVote = new Vote(duplicateVoter, false);
            var question = _builder.BuildWithVotes(votes);

            //Assert
            Assert.Throws<DuplicateVoteException>(() => question.Vote(duplicateVote));
        }

        [Fact]
        public void CalculateVotes_Should_Calculate_The_Result_Of_Votes()
        {
            //Arrange
            var votes = VoteFactory(5);
            var question = _builder.BuildWithVotes(votes);

            //Act
            var voteResult = question.CalculateVotes();

            //Assert
            Assert.Equal(-1, voteResult);
        }

        private static List<Vote> VoteFactory(int count)
        {
            var votes = new List<Vote>();
            for (var i = 1; i <= count; i++)
            {
                var like = i % 2 == 0;
                var voter = new UserId(i);
                var vote = new Vote(voter, like);
                votes.Add(vote);
            }

            return votes;
        }

        [Fact]
        public void CalculateVotes_Should_Return_Zero_When_Votes_Is_Empty()
        {
            //Arrange
            var question = _builder.Build();

            //Act
            var voteResult = question.CalculateVotes();

            //Assert
            Assert.Equal(0, voteResult);
        }
    }
}