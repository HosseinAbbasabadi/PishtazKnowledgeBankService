using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Forum.Application.Command;
using Forum.Application.Tests.Utils;
using Forum.Domain.Models.Tags;
using Forum.Domain.Test.Utils.Builders;
using Moq;
using Xunit;

namespace Forum.Application.Tests.Unit
{
    public class TagCommandHandlerTests
    {
        private readonly Mock<ITagRepository> _tagRepository;
        private readonly TagCommandHandler _tagCommandHandler;

        public TagCommandHandlerTests()
        {
            _tagRepository = new Mock<ITagRepository>();
            _tagCommandHandler = new TagCommandHandler(_tagRepository.Object);
        }

        [Fact]
        public void Handle_Should_Call_Create_On_Repository()
        {
            //Arrange
            var command = CommandFactory.BuildACommandOfType().CreateTag;
            //var tag = new TagTestBuilder().WithName(command.Name).Build();

            //Act
            _tagCommandHandler.Handle(command);

            //Assert
            _tagRepository.Verify(x => x.Create(It.IsAny<Tag>()));
        }
    }
}