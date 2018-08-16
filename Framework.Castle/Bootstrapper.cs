using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Framework.Application;
using Framework.Application.Command;
using Framework.Application.Query;
using Framework.Core;
using Framework.Nhibernate;

//using Framework.RavenDb;

namespace Framework.Castle
{
    public static class Bootstrapper
    {
        public static void WireUp(IWindsorContainer container)
        {
            ServiceLocator.SetCurrent(new WindsorServiceLocator(container));

            container.Register(Component.For(typeof(TransactionalCommandHandlerDecorator<>)).LifestyleSingleton());

            //container.Register(Component.For(typeof(ExceptionQueryHandlerDecorator<,>)).LifestyleTransient());

            container.Register(Component.For<ICommandBus>().ImplementedBy<CommandBus>().LifestyleSingleton());

            //container.Register(Component.For<IQueryBus>().ImplementedBy<QueryBus>().LifestyleSingleton());
        }
    }
}