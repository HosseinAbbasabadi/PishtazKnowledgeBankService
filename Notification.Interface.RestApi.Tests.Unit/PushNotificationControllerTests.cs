using System;
using Moq;
using Notification.Application;
using Notification.Interface.RestApi.Controllers;
using Xunit;

namespace Notification.Interface.RestApi.Tests.Unit
{
    public class PushNotificationControllerTests
    {
        [Fact]
        public void AnswerAdded_Should_Call_Push_On_NotificationCommandHandler()
        {
            //Arrange
            var notificationApplication = new Mock<INotificationApplication>();
            var controller = new PushNotificationController(notificationApplication.Object);
            //var notify = new AnswerAdded(1, 5, 3, 7);

            //Act
            //controller.NotifyAnswerAdded(notify);

            //Assert
        }
    }
}