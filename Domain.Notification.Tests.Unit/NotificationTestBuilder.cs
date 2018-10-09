using System.Collections.Generic;
using Framework.Core;

namespace Notification.Domain.Tests.Unit
{
    public class NotificationTestBuilder : IBuilder<Notification>
    {
        public long Id;
        public string Name;
        public long RelatedUser;
        public bool IsSeen;
        public dynamic Event;

        public NotificationTestBuilder()
        {
            Id = 10;
            Name = "AnswerAdded";
            RelatedUser = 5;
            IsSeen = false;
            Event = new
            {
                questionId = 12,
                AnswerId = 65,
                ResponderId = 17
            };
        }

        public Notification Build()
        {
            return new Notification(Id, Name, RelatedUser, IsSeen, Event);
        }

        public List<Notification> BuildList(int count)
        {
            var notifications = new List<Notification>();
            for (var i = 0; i <= count; i++)
            {
                notifications.Add(Build());
            }

            return notifications;
        }
    }
}