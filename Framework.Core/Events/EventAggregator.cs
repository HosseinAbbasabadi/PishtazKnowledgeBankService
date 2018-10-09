using System.Collections.Generic;
using System.Linq;

namespace Framework.Core.Events
{
    public class EventAggregator : IEventPublisher, IEventListener
    {
        //TODO: Unit test it
        private readonly List<object> _listeners = new List<object>();

        public void Publish<T>(T @event) where T : IEvent
        {
            var handlers = _listeners.OfType<IEventHandler<T>>().ToList();
            handlers.ForEach(handler => { handler.Handle(@event); });
        }

        public void Listen<T>(IEventHandler<T> eventHandler) where T : IEvent
        {
            _listeners.Add(eventHandler);
        }
    }
}