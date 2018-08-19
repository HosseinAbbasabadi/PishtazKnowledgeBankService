using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Models.Users;
using Forum.Domain.Test.Utils;
using Forum.Domain.Test.Utils.Constants;
using Xunit;

namespace Forum.Domain.Tests.Unit.Questions
{
    public class VoteTests
    {

        [Fact]
        public void Constructor_Should_Construct_Vote_Properly()
        {
            //Arrange            
            var voter = Names.Harry;
            const bool opinion = true;
             
            //Act
            var vote = new Vote(voter, opinion);

            //Assert
            Assert.Equal(voter, vote.Voter);
            Assert.Equal(opinion, vote.Opinion);
        }

    }
}
