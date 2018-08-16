using System.Collections.Generic;
using System.Linq;
using Forum.Domain.Models.Questions;
using Forum.Domain.Models.Tags;
using Forum.Presentation.Contracts.Query;
using NHibernate;

namespace Forum.Presentation.Query
{
    public class QuestionQuery : IQuestionQuery
    {
        private readonly ISession _session;

        public QuestionQuery(ISession session)
        {
            _session = session;
        }

        public List<QuestionDto> GetQuestions()
        {
            var tags = _session.Query<Tag>().ToList();
            var questions = _session.Query<Question>().OrderBy(x => x.HasTrueAnswer).ThenBy(x => x.CreationDateTime).ToList();
            return MapQuestions(questions, tags);
        }
        
        private static List<QuestionDto> MapQuestions(IEnumerable<Question> questions,
            IReadOnlyCollection<Tag> tags)
        {
            return questions.Select(question => MapQuestion(question, tags)).ToList();
        }

        private static QuestionDto MapQuestion(Question question, IReadOnlyCollection<Tag> tags)
        {
            return new QuestionDto
            {
                Id = question.Id.DbId,
                Title = question.Title,
                Body = question.Body,
                Inquirer = "حسین عباس آبادی",
                HasTrueAnswer = question.HasTrueAnswer,
                Tags = MapTags(question.Tags.ToList(), tags),
                Views = question.Views.Count,
                Votes = question.CalculateVotes()
            };
        }

        private static TagDto MapTag(TagId tagId, IEnumerable<Tag> tags)
        {
            var tag = tags.Single(t => Equals(t.Id, tagId));
            return new TagDto
            {
                Id = tag.Id.DbId,
                Name = tag.Name
            };
        }

        private static List<TagDto> MapTags(IEnumerable<TagId> tagIds, IReadOnlyCollection<Tag> tags)
        {
            return tagIds.Select(a => MapTag(a, tags)).ToList();
        }
    }
}