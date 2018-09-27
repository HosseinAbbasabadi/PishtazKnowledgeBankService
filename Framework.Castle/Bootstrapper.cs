using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Framework.Application.Command;
using Framework.Application.Query;
using Framework.Core;
using Framework.Identity;
using Microsoft.AspNetCore.Http;

namespace Framework.Castle
{
    public static class Bootstrapper
    {
        public static void WireUp(IWindsorContainer container)
        {
            ServiceLocator.SetCurrent(new WindsorServiceLocator(container));

            container.Register(Component.For(typeof(TransactionalCommandHandlerDecorator<>)).LifestyleScoped());

            container.Register(
                Component.For<ICommandBus>().ImplementedBy<ScoppedCommandBusDecorator>().LifestyleSingleton(),
                Component.For<ICommandBus>().ImplementedBy<CommandBus>().LifestyleSingleton());

            container.Register(
                Component.For<IQueryBus>().ImplementedBy<ScoppedQuerydBusDecorator>().LifestyleSingleton(),
                Component.For<IQueryBus>().ImplementedBy<QueryBus>().LifestyleSingleton());

            container.Register(Component.For<IHttpContextAccessor>().ImplementedBy<HttpContextAccessor>().LifestyleSingleton());
            container.Register(Component.For<IClaimHelper>().ImplementedBy<ClaimHelper>().LifestyleSingleton());
            //container.Register(Component.For<IQueryBus>().ImplementedBy<QueryBus>().LifestyleSingleton());
        }
    }
}