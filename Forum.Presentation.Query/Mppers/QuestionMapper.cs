using System.Collections.Generic;
using System.Linq;
using Forum.Domain.Models.Questions;
using Forum.Domain.Models.Tags;
using Forum.Domin.Contracts.Services;
using Forum.Presentation.Contracts.Query;
using Framework.Core;

namespace Forum.Presentation.Query.Mppers
{
    public class QuestionMapper
    {
        private readonly IUserService _userService;

        public QuestionMapper(IUserService userService)
        {
            _userService = userService;
        }

        public List<QuestionDto> MapQuestions(IEnumerable<Question> questions,
            IReadOnlyCollection<Tag> tags, long answersCount)
        {
            return questions.Select(question => MapQuestion(question, tags, answersCount)).ToList();
        }

        public QuestionDto MapQuestion(Question question, IReadOnlyCollection<Tag> tags, long answers)
        {
            return new QuestionDto
            {
                Id = question.Id.DbId,
                Title = question.Title,
                //Body = question.Body,
                Inquirer = _userService.GetUserFullName(question.Inquirer.DbId),
                //InquirerId = question.Inquirer.DbId,
                HasTrueAnswer = question.HasTrueAnswer,
                CreationDateTime = DatetimeConvertor.ConvertToPersianDate(question.CreationDateTime),
                Tags = TagMapper.MapTags(question.Tags.ToList(), tags),
                Views = question.Views.Count,
                Votes = question.CalculateVotes(),
                Answers = answers
            };
        }

        public QuestionDetailsDto MapQuestion(Question question, IReadOnlyCollection<Tag> tags)
        {
            return new QuestionDetailsDto
            {
                Id = question.Id.DbId,
                Title = question.Title,
                Body = question.Body,
                Inquirer = _userService.GetUserFullName(question.Inquirer.DbId),
                InquirerId = question.Inquirer.DbId,
                CreationDateTime = DatetimeConvertor.ConvertToPersianDate(question.CreationDateTime),
                Tags = TagMapper.MapTags(question.Tags.ToList(), tags),
                Votes = question.CalculateVotes()
            };
        }
    }
}