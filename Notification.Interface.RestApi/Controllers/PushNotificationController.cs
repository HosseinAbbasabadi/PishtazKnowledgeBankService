using Forum.Infrastructure.ACL.NotificationSystem.Contracts;
using Microsoft.AspNetCore.Mvc;
using Notification.Application;

namespace Notification.Interface.RestApi.Controllers
{
    public class PushNotificationController : ControllerBase
    {
        private readonly INotificationApplication _notificationApplication;

        public PushNotificationController(INotificationApplication notificationApplication)
        {
            _notificationApplication = notificationApplication;
        }

        public void Push(AnswerAddedNotify notify)
        {

        }
    }
}