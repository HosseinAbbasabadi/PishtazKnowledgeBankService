using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Presentation.Contracts.Query
{
    public class AnswerDto
    {
        public long Id { get; set; }
        public string Body { get; set; }
        public string Responder { get; set; }
        public bool IsChosen { get; set; }
    }
}
