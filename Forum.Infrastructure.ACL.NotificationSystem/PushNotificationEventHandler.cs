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
                var baseUri = new Uri("http://localhost:6060/api/PushNotification");
                var client = new RestClient(baseUri);
                var request = new RestRequest(@event.Name, Method.POST, DataFormat.Json);
                request.AddBody(@event);
                var result = client.Post(request);
                if(!result.IsSuccessful)
                    throw new Exception(result.ErrorMessage);
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