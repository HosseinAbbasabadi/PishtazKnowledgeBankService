using System;
using System.Collections.Generic;
using Forum.Domain.Models.Answers;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Models.Users;
using Framework.Core;

namespace Forum.Domain.Test.Utils
{
    public class AnswerTestBuilder: IBuilder<Answer>
    {
        public AnswerId Id { get; private set; }
        public string Body { get; private set; }
        public UserId Responder { get; private set; }
        public QuestionId Question { get; private set; }

        public AnswerTestBuilder()
        {
            Id = new AnswerId(2);
            Body = "Some Answer Text";
            Responder = new UserId(6);
            Question = new QuestionId(83);
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
