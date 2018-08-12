namespace Framework.Core.Events
{
    public class EventStream
    {
        public string Id { get; set; }
        public int Version { get; set; }

        private EventStream()
        {
        }

        public EventStream(string id)
        {
            Id = id;
            Version = 0;
        }

        public EventWrapper RegisterEvent(DomainEvent @event)
        {
            Version++;
            return new EventWrapper(@event, Id, Version);
        }
    }

    public class EventWrapper
    {
        public string Id { get; set; }
        public DomainEvent Event { get; set; }
        public string EventSteamName { get; set; }
        public int EventNumber { get; set; }

        public EventWrapper(DomainEvent @event, string eventSteamName, int eventNumber)
        {
            Id = $"{eventSteamName}-{eventNumber}";
            Event = @event;
            EventSteamName = eventSteamName;
            EventNumber = eventNumber;
        }
    }
}