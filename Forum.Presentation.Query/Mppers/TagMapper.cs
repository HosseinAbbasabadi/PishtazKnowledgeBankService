using System.Collections.Generic;
using System.Linq;
using Forum.Domain.Models.Tags;
using Forum.Presentation.Contracts.Query;

namespace Forum.Presentation.Query.Mppers
{
    public static class TagMapper
    {
        public static List<TagDto> MapTagsBy(IEnumerable<TagId> tagIds, IReadOnlyCollection<Tag> tags)
        {
            return tagIds.Select(a => MapTagBy(a, tags)).ToList();
        }

        public static TagDto MapTagBy(TagId tagId, IEnumerable<Tag> tags)
        {
            var tag = tags.Single(t => Equals(t.Id, tagId));
            return new TagDto
            {
                Id = tag.Id.DbId,
                Name = tag.Name
            };
        }

        public static List<TagDto> MapTags(IEnumerable<Tag> tags)
        {
            return tags.Select(MapTag).ToList();
        }

        public static TagDto MapTag(Tag tag)
        {
            return new TagDto
            {
                Id = tag.Id.DbId,
                Name = tag.Name
            };
        }
    }
}