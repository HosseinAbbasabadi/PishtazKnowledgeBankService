using System;
using Framework.Core;

namespace Framework.Application.Query
{
    public class QueryBus : IQueryBus
    {
        public T Dispatch<T>()
        {
            var handler = ServiceLocator.Current.Resolve<IQueryHandler<T>>();

            try
            {
                return handler.Handle();
            }
            finally
            {
                ServiceLocator.Current.Release(handler);
            }
        }

        public T Dispatch<T, TU>(TU condition)
        {
            var handler = ServiceLocator.Current.Resolve<IQueryHandler<T, TU>>();

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