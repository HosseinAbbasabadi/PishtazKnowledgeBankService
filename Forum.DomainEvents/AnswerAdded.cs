using Framework.Core.Events;

namespace Forum.DomainEvents
{
    public class AnswerAdded : DomainNotification
    {
        public long QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public string ResponderName { get; set; }

        public AnswerAdded(long relatedUser, long questionId, string questionTitle, string responderName)
            : base(relatedUser, "AnswerAdded")
        {
            QuestionId = questionId;
            QuestionTitle = questionTitle;
            ResponderName = responderName;
        }
    }
}