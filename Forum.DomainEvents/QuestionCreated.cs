using Framework.Core.Events;

namespace Forum.DomainEvents
{
    public class QuestionCreated : DomainNotification
    {
        public long QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public string Inquirer { get; set; }

        public QuestionCreated(long relatedUser, long questionId, string questionTitle, string inquirer) :
            base(relatedUser)
        {
            QuestionId = questionId;
            QuestionTitle = questionTitle;
            Inquirer = inquirer;
        }
    }
}