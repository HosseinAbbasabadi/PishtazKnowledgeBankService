using System;
using Framework.Core.Events;
using RestSharp;

namespace Forum.Infrastructure.ACL.NotificationSystem
{
    public class PushNotificationEventHandler<T> : IEventHandler<T> where T : IEvent
    {
        public void Handle(T @event)
        {
            try
            {
                var baseUri = new Uri("http://192.168.249.12:6060/api/PushNotification/");
                var client = new RestClient(baseUri);
                var request = new RestRequest("NotifyAnswerAdded", Method.POST, DataFormat.Json);
                request.AddBody(@event);
                client.Post(request);
            }
            catch (Exception exception)
            {
                //TODO: 100% Log Here
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}