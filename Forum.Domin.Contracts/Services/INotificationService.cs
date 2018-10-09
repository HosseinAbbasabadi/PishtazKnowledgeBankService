using Framework.Core.Events;

namespace Forum.Domin.Contracts.Services
{
    public interface INotificationService
    {
        void Push(IEvent @event);
    }
}
