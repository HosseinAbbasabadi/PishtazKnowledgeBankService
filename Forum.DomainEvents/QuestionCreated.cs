using System;
using Framework.Core.Events;

namespace Forum.DomainEvents
{
    public class QuestionCreated : DomainNotification
    {
        public long QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public string Inquirer { get; set; }

        public QuestionCreated(Guid eventId, long relatedUser, long questionId, string questionTitle, string inquirer) :
            base(eventId, relatedUser, "QuestionCreated")
        {
            QuestionId = questionId;
            QuestionTitle = questionTitle;
            Inquirer = inquirer;
        }
    }
}