using Framework.Core.Events;

namespace Forum.Domain.Test.Utils
{
    public class FakePublisher : IEventPublisher
    {
        public void Publish<T>(T @event) where T : IEvent
        {
        }
    }
}