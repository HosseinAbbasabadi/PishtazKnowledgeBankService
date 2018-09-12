using System;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Models.Users;
using Framework.Domain;

namespace Forum.Domain.Models.Answers
{
    public class Answer : AggregateRootBase<AnswerId>
    {
        public string Body { get; private set; }
        public QuestionId Question { get; private set; }
        public UserId Responder { get; private set; }
        public bool IsChosen { get; private set; }

        protected Answer()
        {
        }

        public Answer(AnswerId id, string body, long question, long responder) : base(id)
        {
            Body = body;
            Question = new QuestionId(question);
            Responder = new UserId(responder);
            IsChosen = false;
            CreationDateTime = DateTime.Now;
        }
    }
}