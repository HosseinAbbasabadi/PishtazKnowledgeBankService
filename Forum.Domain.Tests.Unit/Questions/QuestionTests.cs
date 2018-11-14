using System;
using System.Collections.Generic;
using Forum.Domain.Models.Questions.Exceptions;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Models.Users;
using Forum.Domain.Test.Utils.Builders;
using Forum.Domain.Test.Utils.Constants;
using Forum.DomainEvents;
using Framework.Core.Events;
using Framework.Core.Exceptions;
using Moq;
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
            var tags = new List<long>();
            _builder.WithTags(tags);

            //Assert
            Assert.Throws<AtLeastOneTagIsRequiredException>(() => { _builder.Build(); });
        }

        [Fact]
        public void Constructor_Should_Throw_Exception_When_Title_Or_Body_Is_Null()
        {
            //Arrange
            _builder.WithTitle(null);
            _builder.WithBody(null);

            //Assert
            Assert.Throws<RequiredDataIsNullOrEmptyException>(() => _builder.Build());
        }

        [Fact]
        public void Constructor_Should_Throw_Exception_When_Title_Or_Body_Is_EmptyString()
        {
            //Arrange
            _builder.WithTitle("");
            _builder.WithBody("");

            //Assert
            Assert.Throws<RequiredDataIsNullOrEmptyException>(() => _builder.Build());
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
        public void Vote_Should_Remove_Vote_From_Question_Votes_When_User_Already_Voted_And_Now_Has_Diffrente_Opinion()
        {
            //Arrange
            var votes = VoteFactory(1);
            var question = _builder.BuildWithVotes(votes);
            const bool differentOpinion = true;
            var sameVoter = new UserId(1);
            var vote = new Vote(sameVoter, differentOpinion);

            //Act
            question.Vote(vote);

            //Assert
            Assert.Equal(0, question.Votes.Count);
        }

        [Fact]
        public void Vote_Should_Throw_Exception_When_The_Vote_Is_Duplicated()
        {
            //Arrange
            var votes = VoteFactory(1);
            var question = _builder.BuildWithVotes(votes);
            var duplicateVoter = new UserId(1);
            var duplicateVote = new Vote(duplicateVoter, false);

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
                var opinion = i % 2 == 0;
                var voter = new UserId(i);
                var vote = new Vote(voter, opinion);
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

        [Fact]
        public void ContainsTrueAnswser_Should_Set_HasTrueAnswer_Property_True()
        {
            //Arrange
            var question = _builder.Build();

            //Act
            question.ContainsTrueAnswser();

            //Assert
            Assert.True(question.HasTrueAnswer);
        }

        //[Fact]
        //public void Constructor_Should_Provid_Question_In_Draft_Mode_When_Constructing()
        //{
        //    //Act
        //    var question = _builder.Build();

        //    //Assert
        //    Assert.False(question.IsVerified);
        //}

        [Fact]
        public void Verify_Should_Take_Question_To_Verifieded_Mode()
        {
            //Arrange
            var question = _builder.Build();

            //Act
            question.Verify();

            //Assert
            Assert.True(question.IsVerified);
        }

        [Fact]
        public void RaseQuestionCreated_Should_Call_Publish_On_EventPublisher_To_Raise_QuestionCreated_Event()
        {
            //Arrange
            var publisher = new Mock<IEventPublisher>();
            var answer = new QuestionTestBuilder().WithEventPublisher(publisher.Object).Build();
            var eventId = Guid.NewGuid();
            const long relatedUser = 5;
            const string inquirer = "hossein";

            //Act
            answer.RaseQuestionCreated(eventId, relatedUser, inquirer);

            //Assert
            publisher.Verify(x => x.Publish(It.IsAny<QuestionCreated>()));
        }

        [Fact]
        public void Modify_Should_Edit_Question_Properties_When_New_Properties_Passed()
        {
            //Arrange
            var question = _builder.Build();
            const string title = "new title";
            const string body = "new body";
            var tags = new List<long>
            {
                1,
                4,
                8
            };

            //Act
            question.Modify(title, body, tags);

            //Assert
            Assert.Equal(title, question.Title);
            Assert.Equal(body, question.Body);
            Assert.Equal(tags.Count, question.Tags.Count);
        }

        [Fact]
        public void Visit_Should_Add_A_View_To_Views_Of_Question_When_View_Passed()
        {
            //Arrange
            var harry = Names.Harry;
            var view = new View(harry);
            var question = _builder.Build();

            //Act
            question.Visit(view);

            //Assert
            Assert.Equal(1, question.Views.Count);
        }

        [Fact]
        public void Visit_Should_Do_Nothing_When_Viewer_Already_Visited_Question()
        {
            //Arrange
            var harry = Names.Harry;
            var views = new List<View>()
            {
                new View(harry)
            };
            var view = new View(harry);
            var question = _builder.BuildWithViews(views);

            //Act
            question.Visit(view);

            //Assert
            Assert.Equal(1, question.Views.Count);
        }
    }
}