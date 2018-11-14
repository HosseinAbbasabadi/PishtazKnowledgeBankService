using System;
using Framework.Domain;

namespace Forum.Domain.Models.Tags
{
    public class Tag : AggregateRootBase<TagId>
    {
        public string Name { get; private set; }

        protected Tag()
        {
        }

        public Tag(TagId id, string name) : base(id)
        {
            Guard.AgainsNullOrEmptyString(name);

            Name = name;
            CreationDateTime = DateTime.Now;
        }
    }
}