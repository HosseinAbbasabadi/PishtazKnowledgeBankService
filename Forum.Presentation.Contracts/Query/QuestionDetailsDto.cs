using System;
using System.Collections.Generic;

namespace Forum.Presentation.Contracts.Query
{
    public class QuestionDetailsDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Inquirer { get; set; }
        public DateTime CreationDateTime { get; set; }
        public long Votes { get; set; }
        public List<TagDto> Tags { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
