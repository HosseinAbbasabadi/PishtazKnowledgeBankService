using System;
using System.Collections.Generic;
using System.Text;
using Framework.Domain;

namespace Forum.Domain.Models.Tags
{
    public class Tag : AggregateRootBase<TagId>
    {
        public string Name { get; private set; }

        protected Tag(string name)
        {
            Name = name;
        }
    }

    public class TagId : IdBase<long>
    {
        public TagId(long idDbId) : base(idDbId)
        {
        }
    }
}