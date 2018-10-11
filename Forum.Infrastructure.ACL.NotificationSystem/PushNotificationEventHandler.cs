using System;
using Framework.Core.Events;
using RestSharp;

namespace Forum.Infrastructure.ACL.NotificationSystem
{
    public class PushNotificationEventHandler<T> : IEventHandler<T> where T : IEvent
    {
        public void Handle(T @event)
        {
            var baseUri = new Uri("http://localhost:6060/api/PushNotification/");
            var client = new RestClient(baseUri);
            var request = new RestRequest("NotifyAnswerAdded", Method.POST, DataFormat.Json);
            request.AddBody(@event);
            client.Post(request);
        }
    }
}