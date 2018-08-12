using System;
using Framework.Core;

namespace Framework.Application.Query
{
    public class QueryBus : IQueryBus
    {
        public T Dispatch<T>()
        {
            throw new NotImplementedException();
        }

        public T Dispatch<T, TU>(TU condition)
        {
            var handler = ServiceLocator.Current.Resolve<ExceptionQueryHandlerDecorator<T, TU>>();
            try
            {
                return handler.Handle(condition);
            }
            finally
            {
                ServiceLocator.Current.Release(handler);
            }
        }
    }
}