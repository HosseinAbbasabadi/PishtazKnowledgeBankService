using System;
using Castle.Windsor;
using Framework.Core;

namespace Framework.Castle
{
    public class WindsorServiceLocator : IServiceLocator
    {
        private readonly IWindsorContainer _container;

        public WindsorServiceLocator(IWindsorContainer container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public void Release(object obj)
        {
            _container.Release(obj);
        }

        public void Release(Type type)
        {
            _container.Release(type);
        }

        public void ReleaseAll()
        {
            _container.Dispose();
        }
    }
}