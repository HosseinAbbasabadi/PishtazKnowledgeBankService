using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Forum.Domain.Models.Questions.Exceptions;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Models.Tags;
using Forum.Domain.Models.Users;
using Framework.Domain;

namespace Forum.Domain.Models.Questions
{
    public class Question : AggregateRootBase<QuestionId>
    {
        private readonly IList<TagId> _tags;
        private readonly IList<View> _views;
        private readonly IList<Vote> _votes;

        public string Title { get; private set; }
        public string Body { get; private set; }
        public UserId Inquirer { get; private set; }
        public bool HasTrueAnswer { get; private set; }
        public IReadOnlyCollection<TagId> Tags => new ReadOnlyCollection<TagId>(_tags);
        public IReadOnlyCollection<View> Views => new ReadOnlyCollection<View>(_views);
        public IReadOnlyCollection<Vote> Votes => new ReadOnlyCollection<Vote>(_votes);

        protected Question()
        {
        }

        public Question(QuestionId id, string title, string body, List<long> tags, UserId inquirer) : base(id)
        {
            GaurdAgainsLessThan3Tags(tags);

            Title = title;
            Body = body;
            Inquirer = inquirer;
            CreationDateTime = DateTime.Now;
            HasTrueAnswer = false;
            _tags = MapToTagId(tags);
            _views = new List<View>();
            _votes = new List<Vote>();
        }

        private static void GaurdAgainsLessThan3Tags(List<long> tags)
        {
            if (tags.Count < 3)
                throw new TagsAreLessThan3Exception();
        }

        private static List<TagId> MapToTagId(IEnumerable<long> tags)
        {
            return tags.Select(MapSingleTagId).ToList();
        }

        private static TagId MapSingleTagId(long tag)
        {
            return new TagId(tag);
        }

        public void Vote(Vote vote)
        {
            //guard agains Duplicate voter
            _votes.Add(vote);
        }

        public long CalculateVotes()
        {
            var likes = _votes.Count(v => v.Opinion);
            var disLikes = _votes.Count(v => v.Opinion == false);
            return likes - disLikes;
        }
    }
}