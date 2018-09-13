using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Framework.Application.Command;
using Framework.Core;
using Framework.Nhibernate;
using NHibernate;
using UserManagement.Application;
using UserManagement.Domain.Models.Users;
using UserManagement.Infrastructure.Persistance.Nh;
using UserManagement.Infrastructure.Persistance.Nh.Mappings;

namespace UserManagement.Infrastructure.Config
{
    public static class UserManagementBootstrapper
    {
        public static void Wireup(WindsorContainer container, string connectionString)
        {
            const string boundedContextName = "UserManagement";
            const string sessionFactoryName = boundedContextName + "_SessionFactory";
            const string unitOfWorkName = boundedContextName + "_UOW";
            const string sessionName = boundedContextName + "_Session";

            container.Register(Classes.FromAssemblyContaining(typeof(UserCommandHandler))
                .BasedOn(typeof(ICommandHandler<>)).WithService.AllInterfaces().LifestyleTransient());

            container.Register(Component.For<IUserRepository>().ImplementedBy<UserRepository>()
                .LifestyleBoundTo<IService>());

            container.Register(Component.For<ISessionFactory>().UsingFactoryMethod(a => new SessionFactoryBuilder()
                    .CreateByConnectionStringName(connectionString, typeof(UserMapping).Assembly))
                .Named(sessionFactoryName).LifestyleSingleton());

            container.Register(Component.For<ISession>().UsingFactoryMethod(a =>
            {
                var factory = a.Resolve<ISessionFactory>();
                return factory.OpenSession();
            }).LifestyleScoped().Named(sessionName));

            container.Register(Component.For<IUnitOfWork>().ImplementedBy<NhUnitOfWork>().LifestyleBoundTo<IService>()
                .Named(unitOfWorkName));
        }
    }
}