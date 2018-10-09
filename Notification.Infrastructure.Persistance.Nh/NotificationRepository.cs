using Framework.Nhibernate;
using NHibernate;
using Notification.Domain;

namespace Notification.Infrastructure.Persistance.Nh
{
    public class NotificationRepository : BaseRepository<long, Domain.Notification>, INotificationRepository
    {
        public NotificationRepository(ISession session) : base(session)
        {
        }
    }
}