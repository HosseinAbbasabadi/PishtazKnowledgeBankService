using System;
using Framework.Core.Events;

namespace Framework.Nhibernate
{
    public class RepositoryEventHandler<T> : IEventHandler<T> where T : IEvent
    {
        public void Handle(T @event)
        {
            throw new NotImplementedException();
        }
    }
}
