namespace Framework.Core.Events
{
    public interface IEventListener
    {
        void Listen<T>(IEventHandler<T> eventHandler) where T : IEvent;
        void Clear<T>(IEventHandler<T> eventHandler) where T : IEvent;
    }
}