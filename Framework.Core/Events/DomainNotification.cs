using System;

namespace Framework.Core.Events
{
    public class DomainNotification : IEvent
    {
        public Guid EventId { get; }
        public string Name { get; }
        public string Type { get; set; }
        public long RelatedUser { get; set; }

        public DomainNotification(Guid eventId, long relatedUser, string name)
        {
            EventId = eventId;
            RelatedUser = relatedUser;
            Name = name;
            Type = GetType().Name;
        }
    }
}