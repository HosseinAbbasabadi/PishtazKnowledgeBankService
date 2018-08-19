using System.Collections.Generic;
using Framework.Application.Command;

namespace Forum.Presentation.Contracts.Command
{
    public class CreateQuestion : ICommand
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public List<long> Tags { get; set; }
    }
}