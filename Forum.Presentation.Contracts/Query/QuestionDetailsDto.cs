using System;
using System.Collections.Generic;
using Framework.Application.Query;

namespace Forum.Presentation.Contracts.Query
{
    public class QuestionDetailsDto : IQuery
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Inquirer { get; set; }
        public DateTime CreationDateTime { get; set; }
        public long Votes { get; set; }
        public List<TagDto> Tags { get; set; }
        //public List<AnswerDto> Answers { get; set; }
    }
}