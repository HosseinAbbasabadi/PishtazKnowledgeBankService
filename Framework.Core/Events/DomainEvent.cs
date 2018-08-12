using System;

namespace Framework.Core.Events
{
    public abstract class DomainEvent : IEvent
    {
        public Guid EventId { get; }

        protected DomainEvent()
        {
            EventId = Guid.NewGuid();
        }
    }
}
