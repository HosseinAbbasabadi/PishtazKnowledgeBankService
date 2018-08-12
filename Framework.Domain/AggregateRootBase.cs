using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.Events;

namespace Framework.Domain
{
    public class AggregateRootBase<TKey> : EntityBase<TKey>, IAggregateRoot
    {
        private readonly IEventPublisher _publisher;
        private readonly List<DomainEvent> _publishedEvents = new List<DomainEvent>();

        protected AggregateRootBase()
        {
        }

        protected AggregateRootBase(TKey id)
        {
            Id = id;
        }

        protected AggregateRootBase(TKey id, IEventPublisher publisher) : base(id)
        {
            Id = id;
            _publisher = publisher;
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            _publishedEvents.Add(@event);
            _publisher.Publish(@event);
        }

        public List<DomainEvent> GetPublishedEvents()
        {
            return _publishedEvents;
        }

        public void ClearEvents()
        {
            _publishedEvents.Clear();
        }
    }
}