using System;
using System.Collections.Generic;
using System.Text;
using Framework.Domain;

namespace Forum.Domain.Models.Tags
{
    public class Tag : AggregateRootBase<TagId>
    {
        public string Name { get; private set; }

        public Tag(TagId id, string name) : base(id)
        {
            Name = name;
        }
    }
}