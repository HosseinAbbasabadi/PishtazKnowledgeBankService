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

        public Answer(AnswerId id, string body, QuestionId question, UserId responder) : base(id)
        {
            Body = body;
            Question = question;
            Responder = responder;
            IsChosen = false;
        }
    }
}