using Forum.Domin.Contracts.Services;
using Framework.Core.Events;
using RestSharp;

namespace Forum.Infrastructure.ACL.NotificationSystem
{
    public class NotificationService : INotificationService
    {
        public void Push(DomainEvent @event)
        {
            var client = new RestClient();
        }
    }
}