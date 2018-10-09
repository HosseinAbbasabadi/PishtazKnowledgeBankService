using Xunit;

namespace Notification.Domain.Tests.Unit
{
    public class NotificationTests
    {
        [Fact]
        public void Constructor_Should_Construct_Notification_Properly()
        {
            //Arrange
            var builder = new NotificationTestBuilder();

            //Act
            var notification = builder.Build();

            //Assert
            Assert.Equal(builder.Id, notification.Id);
            Assert.Equal(builder.Name, notification.Name);
            Assert.Equal(builder.RelatedUser, notification.RelatedUser);
            Assert.Equal(builder.IsSeen, notification.IsSeen);
            Assert.Equal(builder.Event, notification.Event);
        }
    }
}