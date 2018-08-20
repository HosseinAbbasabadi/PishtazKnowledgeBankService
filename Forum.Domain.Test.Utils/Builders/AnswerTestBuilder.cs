using System;
using System.Collections.Generic;
using Forum.Domain.Models.Answers;
using Framework.Core;

namespace Forum.Domain.Test.Utils.Builders
{
    public class AnswerTestBuilder: IBuilder<Answer>
    {
        public AnswerId Id { get; private set; }
        public string Body { get; private set; }
        public long Responder { get; private set; }
        public long Question { get; private set; }

        public AnswerTestBuilder()
        {
            Id = new AnswerId(2);
            Body = "Some Answer Text";
            Responder = 6;
            Question = 83;
        }

        public Answer Build()
        {
            return new Answer(Id, Body, Question, Responder);
        }

        public List<Answer> BuildList(int count)
        {
            throw new NotImplementedException();
        }
    }
}
