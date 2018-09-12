using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Forum.Application.Command;
using Forum.Domain.Models.Answers;
using Forum.Domain.Models.Questions;
using Forum.Infrastructure.Persistance.Nh;
using Forum.Infrastructure.Persistance.Nh.Mappings;
using Forum.Presentation.Query;
using Framework.Application.Command;
using Framework.Application.Query;
using Framework.Core;
using Framework.Nhibernate;
using NHibernate;

namespace Forum.Infrastructure.Config
{
    public static class  ForumBootstrapper
    {
        public static void Wireup(WindsorContainer container, string connectionString)
        {
            const string boundedContextName = "Forum";
            //const string sessionFactoryName = boundedContextName + "_SessionFactory";
            const string sessionName = boundedContextName + "_Session";
            
            //container.Register(Component.For<IMySessionFactoryBuilder>().ImplementedBy<SessionFactoryBuilder>());

            container.Register(Classes.FromAssemblyContaining(typeof(QuestionCommandHandler))
                .BasedOn(typeof(ICommandHandler<>)).WithService.AllInterfaces().LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining(typeof(QuestionQueryHandler))
                .BasedOn(typeof(IQueryHandler<>)).WithService.AllInterfaces().LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining(typeof(QuestionQueryHandler))
                .BasedOn(typeof(IQueryHandler<,>)).WithService.AllInterfaces().LifestyleTransient());

            container.Register(Component.For<IQuestionRepository>().ImplementedBy<QuestionRepository>()
                .LifestyleBoundTo<IService>());

            container.Register(Component.For<IAnswerRepository>().ImplementedBy<AnswerRepository>()
                .LifestyleBoundTo<IService>());

            container.Register(Component.For<ISessionFactory>().UsingFactoryMethod(a => new SessionFactoryBuilder()
                    .CreateByConnectionStringName(connectionString, typeof(QuestionMapping).Assembly))
                .LifestyleSingleton());

            container.Register(Component.For<ISession>().UsingFactoryMethod(a =>
            {
                var factory = a.Resolve<ISessionFactory>();
                return factory.OpenSession();
            }).LifestyleScoped().Named(sessionName));


            //var sessionFactory = SessionFactoryBuilder
            //    .CreateByConnectionStringName(connectionString, typeof(QuestionMapping).Assembly);

            //container.Register(Component.For<ISession>()
            //    .UsingFactoryMethod(a => sessionFactory.OpenSession())
            //    .LifestyleScoped());

            container.Register(Component.For<IUnitOfWork>().ImplementedBy<NhUnitOfWork>().LifestyleBoundTo<IService>());
        }
    }
}