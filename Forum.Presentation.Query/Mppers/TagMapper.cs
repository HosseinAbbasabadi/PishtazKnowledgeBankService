using System.Collections.Generic;
using System.Linq;
using Forum.Domain.Models.Tags;
using Forum.Presentation.Contracts.Query;

namespace Forum.Presentation.Query.Mppers
{
    public static class TagMapper
    {
        public static TagDto MapTag(TagId tagId, IEnumerable<Tag> tags)
        {
            var tag = tags.Single(t => Equals(t.Id, tagId));
            return new TagDto
            {
                Id = tag.Id.DbId,
                Name = tag.Name
            };
        }

        public static List<TagDto> MapTags(IEnumerable<TagId> tagIds, IReadOnlyCollection<Tag> tags)
        {
            return tagIds.Select(a => MapTag(a, tags)).ToList();
        }
    }
}