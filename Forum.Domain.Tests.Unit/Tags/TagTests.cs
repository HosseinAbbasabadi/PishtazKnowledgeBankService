using System;
using System.Collections.Generic;
using System.Text;
using Forum.Domain.Models.Tags;
using Forum.Domain.Test.Utils;
using Forum.Domain.Test.Utils.Builders;
using Framework.Core.Exceptions;
using Xunit;

namespace Forum.Domain.Tests.Unit.Tags
{
    public class TagTests
    {
        private readonly TagTestBuilder _builder;

        public TagTests()
        {
            _builder = new TagTestBuilder();
        }
        [Fact]
        public void Constructor_Should_Construct_Tag_Properly()
        {
            //Act
            var tag = _builder.Build();

            //Assert
            Assert.Equal(_builder.Id, tag.Id);
            Assert.Equal(_builder.Name, tag.Name);
        }


        [Fact]
        public void Consatructor_Should_Throw_Exception_When_Name_Is_Null_Or_EmptyString()
        {
            //Arrange
            _builder.WithName(null);

            //Assert
            Assert.Throws<RequiredDataIsNullOrEmptyException>(() => _builder.Build());
        }
    }
}