using System;
using System.Collections.Generic;
using System.Text;
using Forum.Domain.Models.Tags;
using Forum.Domain.Test.Utils;
using Xunit;

namespace Forum.Domain.Tests.Unit.Tags
{
    public class TagTests
    {
        [Fact]
        public void Constructor_Should_Construct_Tag_Properly()
        {
            //Arrange
            var builder = new TagTestBuilder();

            //Act
            var tag = builder.Build();

            //Assert
            Assert.Equal(builder.Id, tag.Id);
            Assert.Equal(builder.Name, tag.Name);
        }
    }
}