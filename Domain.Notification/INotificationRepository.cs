using Framework.Domain;

namespace Notification.Domain
{
    public interface INotificationRepository : IRepository<long, Notification>
    {
    }
}