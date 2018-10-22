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
        public bool IsVerified { get; set; }
        public IReadOnlyCollection<TagId> Tags => new ReadOnlyCollection<TagId>(_tags);
        public IReadOnlyCollection<View> Views => new ReadOnlyCollection<View>(_views);
        public IReadOnlyCollection<Vote> Votes => new ReadOnlyCollection<Vote>(_votes);

        protected Question()
        {
        }

        public Question(QuestionId id, string title, string body, List<long> tags, UserId inquirer) : base(id)
        {
            GaurdAgainsLessThanOneTags(tags);

            Title = title;
            Body = body;
            Inquirer = inquirer;
            CreationDateTime = DateTime.Now;
            HasTrueAnswer = false;
            IsVerified = false;
            _tags = MapToTagId(tags);
            _views = new List<View>();
            _votes = new List<Vote>();
        }

        private static void GaurdAgainsLessThanOneTags(List<long> tags)
        {
            if (tags.Count < 1)
                throw new AtLeastOneTagIsRequiredException();
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
            GuardAgainstDuplicateVote(vote);

            _votes.Add(vote);
        }

        private void GuardAgainstDuplicateVote(Vote vote)
        {
            if (Votes.Any(a => Equals(a.Voter, vote.Voter)))
                throw new DuplicateVoteException();
        }

        public long CalculateVotes()
        {
            var likes = _votes.Count(v => v.Opinion);
            var disLikes = _votes.Count(v => v.Opinion == false);
            return likes - disLikes;
        }

        public void ContainsTrueAnswser()
        {
            HasTrueAnswer = true;
        }

        public void Verify()
        {
            IsVerified = true;
        }
    }
}