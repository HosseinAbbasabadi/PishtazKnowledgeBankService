using System;
using System.Collections.Generic;
using System.Text;
using Framework.Domain;

namespace Forum.Domain.Models.Answers
{
    public class Answer : AggregateRootBase<AnswerId>
    {
        public bool IsChosen { get; private set; }
    }
}