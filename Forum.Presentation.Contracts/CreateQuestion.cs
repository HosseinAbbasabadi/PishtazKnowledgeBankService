using System;
using System.Collections.Generic;
using Framework.Application.Command;

namespace Forum.Presentation.Contracts
{
    public class CreateQuestion : ICommand
    {
        public string Title { get; private set; }
        public string Body { get; private set; }
        public long Creator { get; set; }
        public List<long> Tags { get; private set; }

        public CreateQuestion(string title, string body, List<long> tags)
        {
            Title = title;
            Body = body;
            Tags = tags;
        }
    }
}