using Framework.Domain;

namespace Notification.Domain
{
    public class Notification : AggregateRootBase<long>
    {
        public string Name { get; private set; }
        public long RelatedUser { get; private set; }
        public bool IsSeen { get; private set; }
        public dynamic Event { get; private set; }

        public Notification(long id, string name, long relatedUser, dynamic @event) : base(id)
        {
            Name = name;
            RelatedUser = relatedUser;
            IsSeen = false;
            Event = @event;
        }
    }
}