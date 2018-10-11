using System;

namespace Framework.Core.Events
{
    public class DomainNotification : IEvent
    {
        public Guid EventId { get; }
        public string Name { get; set; }
        public long RelatedUser { get; set; }

        public DomainNotification(long relatedUser)
        {
            EventId = Guid.NewGuid();
            RelatedUser = relatedUser;
        }
    }
}