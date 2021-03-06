﻿using System;
using System.Collections.Generic;
using Forum.Domain.Models.Tags;
using Framework.Core;

namespace Forum.Domain.Test.Utils.Builders
{
    public class TagTestBuilder : IBuilder<Tag>
    {
        public TagId Id { get; private set; }
        public string Name { get; private set; }

        public TagTestBuilder()
        {
            Id = new TagId(1);
            Name = "C#";
        }

        public TagTestBuilder WithId(long id)
        {
            var tagId = new TagId(id);
            Id = tagId;
            return this;
        }

        public TagTestBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public Tag Build()
        {
            return new Tag(Id, Name);
        }

        public List<Tag> BuildList(int count)
        {
            var tags = new List<Tag>();
            for (var i = 1; i <= count; i++)
            {
                tags.Add(WithId(i).Build());
            }

            return tags;
        }
    }
}