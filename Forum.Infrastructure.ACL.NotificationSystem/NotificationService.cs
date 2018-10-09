using Forum.Domin.Contracts.Services;
using Framework.Core.Events;
using Notification.Application;

namespace Forum.Infrastructure.ACL.NotificationSystem
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationCommandHandler _commandHandler;

        public NotificationService(INotificationCommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public void Push(IEvent @event)
        {
        }
    }
}
