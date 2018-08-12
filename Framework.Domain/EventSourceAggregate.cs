using Framework.Core.Events;
using System.Collections.Generic;

namespace Framework.Domain
{
    public abstract class EventSourceAggregate<T> : EntityBase<T>
    {
        public List<DomainEvent> Changes { get; set; }
        public int Version { get; set; }

        protected EventSourceAggregate()
        {
            Changes = new List<DomainEvent>();
        }

        protected abstract void Apply(DomainEvent @event);
    }
}
