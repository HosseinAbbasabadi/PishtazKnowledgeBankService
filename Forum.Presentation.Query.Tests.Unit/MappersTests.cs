using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Forum.Domain.Models.Tags;
using Forum.Domain.Test.Utils.Builders;
using Forum.Domin.Contracts.Services;
using Forum.Presentation.Query.Mppers;
using Moq;
using Xunit;

namespace Forum.Presentation.Query.Tests.Unit
{
    public class MappersTests
    {
        private readonly QuestionMapper _questionMapper;
        private readonly AnswerMapper _answerMapper;

        public MappersTests()
        {
            var userService = new Mock<IUserService>();
            _questionMapper = new QuestionMapper(userService.Object);
            _answerMapper = new AnswerMapper(userService.Object);
        }

        [Fact]
        public void MapAnswer_Should_Convert_Answer_To_AnswerDto()
        {
            //Arrange
            var answer = new AnswerTestBuilder().Build();

            //Act
            var answerDto = _answerMapper.MapAnswer(answer);

            //Assert
            answerDto.Id.Should().Be(answer.Id.DbId);
            answerDto.Body.Should().Be(answer.Body);
            answerDto.IsChosen.Should().Be(answer.IsChosen);
        }

        [Fact]
        public void MapAnswers_Should_Convert_List_Of_Answers_To_List_Of_AnswerDtos()
        {
            //Arrange
            var answers = new AnswerTestBuilder().BuildList(3);

            //Act
            var answerDtos = _answerMapper.MapAnswers(answers);

            //Assert
            answerDtos.Count.Should().Be(answers.Count);
        }

        [Fact]
        public void MapQuestion_Should_Convert_Question_To_QuestionDetailsDto()
        {
            //Arrange
            var tagIds = CreateSomeTagId();
            var tags = new TagTestBuilder().BuildList(tagIds.Count);
            var question = new QuestionTestBuilder().WithTags(tagIds).Build();

            //Act
            var questionDto = _questionMapper.MapQuestion(question, tags);

            //Assert
            questionDto.Id.Should().Be(question.Id.DbId);
            questionDto.Body.Should().Be(question.Body);
            questionDto.Title.Should().Be(question.Title);
            questionDto.InquirerId.Should().Be(question.Inquirer.DbId);
            questionDto.Tags.Count.Should().Be(tagIds.Count);
        }

        [Fact]
        public void MapQuestions_Should_Convert_List_Of_Questions_To_List_Of_QuestionDetailsDtos()
        {
            //Arrange
            var tagIds = CreateSomeTagId();
            var tags = new TagTestBuilder().BuildList(tagIds.Count);
            var questions = new QuestionTestBuilder().BuildList(3);

            //Act
            var questionDetailsDtos = _questionMapper.MapQuestions(questions, tags, 2);

            //Assert
            questionDetailsDtos.Count.Should().Be(questions.Count);
        }

        private static List<long> CreateSomeTagId()
        {
            return new List<long>
            {
                1,
                2,
                3,
                4
            };
        }

        [Fact]
        public void MapTags_Should_Convert_List_Of_Tags_To_List_Of_TagDtos()
        {
            //Arrange
            var tagIds = CreateSomeTagId(3);
            var tags = new TagTestBuilder().BuildList(tagIds.Count);

            //Act
            var tagDtos = TagMapper.MapTags(tagIds, tags);

            //Assert
            tagDtos.Count.Should().Be(tags.Count);
        }

        public static List<TagId> CreateSomeTagId(int count)
        {
            var tagIds = new List<TagId>();
            for (var i = 1; i <= count; i++)
            {
                tagIds.Add(new TagId(i));
            }

            return tagIds;
        }

        [Fact]
        public void MapTag_Should_Convert_Tag_To_TagDto()
        {
            //Arrange
            var tags = new TagTestBuilder().BuildList(3);

            //Act
            var tagDto = TagMapper.MapTag(tags.First().Id, tags);

            //Assert
            tagDto.Id.Should().Be(tagDto.Id);
            tagDto.Name.Should().Be(tagDto.Name);
        }
    }
}