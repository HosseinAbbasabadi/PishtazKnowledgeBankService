using System.Collections.Generic;

namespace Framework.Core.Events
{
    public interface IEventStore
    {
        void CreateNewStream(string streamName, IEnumerable<DomainEvent> events);
        void AppendEventsToStream(string streamName, IEnumerable<DomainEvent> events, int? expectedVersion);
        IEnumerable<DomainEvent> GetStream(string streamName, int fromVersion, int toVersion);
        void AddSnapshot<T>(string streamName, T snapshot);
        T GetLatestSnapshot<T>(string steamName) where T : class;
    }
}
