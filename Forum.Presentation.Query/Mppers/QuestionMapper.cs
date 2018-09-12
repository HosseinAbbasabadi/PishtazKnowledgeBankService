using System.Collections.Generic;
using System.Linq;
using Forum.Domain.Models.Answers;
using Forum.Domain.Models.Questions;
using Forum.Domain.Models.Tags;
using Forum.Presentation.Contracts.Query;
using Framework.Core;

namespace Forum.Presentation.Query.Mppers
{
    public static class QuestionMapper
    {
        public static List<QuestionDto> MapQuestions(IEnumerable<Question> questions,
            IReadOnlyCollection<Tag> tags, long answers)
        {
            return questions.Select(question => MapQuestion(question, tags, answers)).ToList();
        }

        public static QuestionDto MapQuestion(Question question, IReadOnlyCollection<Tag> tags, long answers)
        {
            return new QuestionDto
            {
                Id = question.Id.DbId,
                Title = question.Title,
                Body = question.Body,
                Inquirer = "حسین عباس آبادی",
                HasTrueAnswer = question.HasTrueAnswer,
                CreationDateTime = DatetimeConvertor.ConvertToPersianDate(question.CreationDateTime),
                Tags = TagMapper.MapTags(question.Tags.ToList(), tags),
                Views = question.Views.Count,
                Votes = question.CalculateVotes(),
                Answers = answers
            };
        }

        public static QuestionDetailsDto MapQuestion(Question question, IReadOnlyCollection<Tag> tags)
        {
            return new QuestionDetailsDto
            {
                Id = question.Id.DbId,
                Title = question.Title,
                Body = question.Body,
                Inquirer = "حسین عباس آبادی",
                CreationDateTime = DatetimeConvertor.ConvertToPersianDate(question.CreationDateTime),
                Tags = TagMapper.MapTags(question.Tags.ToList(), tags),
                Votes = question.CalculateVotes()
                //Answers = AnswerMapper.MapAnswers(answers)
            };
        }
    }
}
