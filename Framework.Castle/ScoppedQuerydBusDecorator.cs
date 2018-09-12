using System;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using Framework.Application.Query;

namespace Framework.Castle
{
    public class ScoppedQuerydBusDecorator : IQueryBus
    {
        private readonly IQueryBus _queryBus;
        private readonly IWindsorContainer _container;

        public ScoppedQuerydBusDecorator(IQueryBus queryBus, IWindsorContainer container)
        {
            _queryBus = queryBus;
            _container = container;
        }

        public T Dispatch<T>()
        {
            using (_container.BeginScope())
            {
                return _queryBus.Dispatch<T>();
            }
        }

        public T Dispatch<T, TU>(TU condition)
        {
            try
            {
                using (_container.BeginScope())
                {
                    return _queryBus.Dispatch<T, TU>(condition);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}