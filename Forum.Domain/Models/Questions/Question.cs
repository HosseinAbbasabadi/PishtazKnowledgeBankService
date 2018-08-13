using System;
using System.Collections.Generic;
using System.Linq;
using Forum.Domain.Models.Questions.Exceptions;
using Forum.Domain.Models.Tags;
using Framework.Domain;

namespace Forum.Domain.Models.Questions
{
    public class Question : AggregateRootBase<QuestionId>
    {
        public string Title { get; private set; }
        public string Body { get; private set; }
        public long Creator { get; private set; }
        public bool HasTrueAnswer { get; private set; }
        public List<TagId> Tags { get; private set; }
        public List<View> Views { get; private set; }
        public List<Vote> Votes { get; private set; }
        public CurrectAnswer CurrectAnswer { get; private set; }

        protected Question()
        {
        }

        public Question(QuestionId id, string title, string body, List<long> tags, long creator) : base(id)
        {
            GaurdAgainsLessThan3Tags(tags);

            Title = title;
            Body = body;
            Tags = MapToTagId(tags);
            Creator = creator;
            CreationDateTime = DateTime.Now;
            CurrectAnswer = null;
            HasTrueAnswer = false;
            Views = new List<View>();
            Votes = new List<Vote>();
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
    }
}