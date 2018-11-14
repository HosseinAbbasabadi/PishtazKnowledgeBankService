using System;
using Framework.Core.Events;
using RestSharp;

namespace Forum.Infrastructure.ACL.NotificationSystem
{
    public class PushNotificationEventHandler<T> : IEventHandler<T> where T : IEvent
    {
        private string _notificationUrl;

        public PushNotificationEventHandler<T> SetNotificationUrl(string url)
        {
            _notificationUrl = url;
            return this;
        }

        public void Handle(T @event)
        {
            //if(string.IsNullOrEmpty(_notificationUrl))
            //    throw new NullReferenceException();
            try
            {
                var baseUri = new Uri(_notificationUrl);
                var client = new RestClient(baseUri);
                var request = new RestRequest(@event.Name, Method.POST, DataFormat.Json);
                request.AddBody(@event);
                var result = client.Post(request);
                if (!result.IsSuccessful)
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