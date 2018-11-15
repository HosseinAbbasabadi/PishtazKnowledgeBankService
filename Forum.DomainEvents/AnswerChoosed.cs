using System;
using Framework.Core.Events;

namespace Forum.DomainEvents
{
    public class AnswerChoosed : DomainNotification
    {
        public long QuestionId { get; set; }

        public AnswerChoosed(Guid eventId, long relatedUser, long questionId) : base(eventId, relatedUser, "AnswerChoosed")
        {
            QuestionId = questionId;
        }
    }
}