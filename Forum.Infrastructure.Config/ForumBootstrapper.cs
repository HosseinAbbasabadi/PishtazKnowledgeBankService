using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Forum.Application;
using Forum.Domain.Models.Questions;
using Forum.Infrastructure.Persistance.Nh;
using Forum.Infrastructure.Persistance.Nh.Mappings;
using Forum.Presentation.Query;
using Framework.Application.Command;
using Framework.Core;
using Framework.Nhibernate;
using NHibernate;

namespace Forum.Infrastructure.Config
{
    public static class ForumBootstrapper
    {
        public static void Wireup(WindsorContainer container)
        {
            const string boundedContextName = "Forum";
            //const string sessionFactoryName = boundedContextName + "_SessionFactory";
            const string sessionName = boundedContextName + "_Session";
            const string connectionString = "Data Source=.;Initial Catalog=KnowladgeBank;User ID=sa;Password=123456";

            container.Register(Component.For<IMySessionFactoryBuilder>().ImplementedBy<SessionFactoryBuilder>());

            container.Register(Classes.FromAssemblyContaining(typeof(QuestionCommandHandler))
                .BasedOn(typeof(ICommandHandler<>)).WithService.AllInterfaces().LifestyleTransient());

            container.Register(Component.For<IQuestionRepository>().ImplementedBy<QuestionRepository>()
                .LifestyleBoundTo<IService>());

            container.Register(Component.For<ISessionFactory>().UsingFactoryMethod(a => new SessionFactoryBuilder()
                    .CreateByConnectionStringName(connectionString, typeof(QuestionMapping).Assembly))
                .LifestyleSingleton());

            container.Register(Component.For<ISession>().UsingFactoryMethod(a =>
            {
                var factory = a.Resolve<ISessionFactory>();
                return factory.OpenSession();
            }).LifestylePerThread().Named(sessionName));

            container.Register(Component.For<IQuestionQuery>().ImplementedBy<QuestionQuery>());

            container.Register(Component.For<IUnitOfWork>().ImplementedBy<NhUnitOfWork>().LifestyleBoundTo<IService>().DependsOn(Dependency.OnComponent(typeof(ISession), sessionName)));
        }
    }
}