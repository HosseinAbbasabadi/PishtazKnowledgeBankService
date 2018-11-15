using System.Collections.Generic;
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

        protected AggregateRootBase(TKey id, IEventPublisher eventPublisher) : base(id, eventPublisher)
        {
            Id = id;
            _publisher = eventPublisher;
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

        public void SetEventPublisher(IEventPublisher eventPublisher)
        {
            EventPublisher = eventPublisher;
        }

        public void ClearEvents()
        {
            _publishedEvents.Clear();
        }
    }
}