using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Presentation.Contracts.Query
{
    public class QuestionDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Inquirer { get; set; }
        public bool HasTrueAnswer { get; set; }
        public DateTime CreationDateTime { get; set; }
        public List<TagDto> Tags { get; set; }
        public long Views { get; set; }
        public long Votes { get; set; }
    }
}
