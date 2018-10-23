using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Forum.Application.Command;
using Forum.Domain.Models.Answers;
using Forum.Domain.Models.Questions;
using Forum.Domain.Models.Questions.Services;
using Forum.Domain.Models.Tags;
using Forum.Domin.Contracts.Services;
using Forum.Infrastructure.ACL.UserManagement;
using Forum.Infrastructure.Persistance.Nh;
using Forum.Infrastructure.Persistance.Nh.Mappings;
using Forum.Presentation.Contracts;
using Forum.Presentation.Facade;
using Forum.Presentation.Query;
using Framework.Application.Command;
using Framework.Application.Query;
using Framework.Castle;
using Framework.Core;
using Framework.Core.Events;
using Framework.Nhibernate;
using NHibernate;

namespace Forum.Infrastructure.Config
{
    public static class ForumBootstrapper
    {
        public static void Wireup(WindsorContainer container, string connectionString)
        {
            const string boundedContextName = "Forum";
            const string sessionFactoryName = boundedContextName + "_SessionFactory";
            const string unitOfWorkName = boundedContextName + "_UOW";
            const string sessionName = boundedContextName + "_Session";

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

            container.Register(Component.For<ITagRepository>().ImplementedBy<TagRepository>()
                .LifestyleBoundTo<IService>());

            container.Register(Component.For<ISessionFactory>().UsingFactoryMethod(a => new SessionFactoryBuilder()
                    .CreateByConnectionStringName(connectionString, typeof(QuestionMapping).Assembly))
                .Named(sessionFactoryName).LifestyleSingleton());

            container.Register(Component.For<ISession>().UsingFactoryMethod(a =>
            {
                var factory = a.Resolve<ISessionFactory>();
                return factory.OpenSession();
            }).LifestyleScoped().Named(sessionName));

            container.Register(Component.For<IUnitOfWork>().ImplementedBy<NhUnitOfWork>().LifestyleBoundTo<IService>()
                .Named(unitOfWorkName));

            container.Register(Component.For<IEventListener>().Forward<IEventPublisher>()
                .ImplementedBy<EventAggregator>().LifestyleSingleton());

            container.Register(Component.For<IUserService>().ImplementedBy<UserService>().LifestyleSingleton());

            container.Register(Component.For<IQuestionFacadeService>().ImplementedBy<QuestionFacadeService>()
                .Interceptors<SecurityInterceptor>());
            container.Register(Component.For<IAnswerFacadeService>().ImplementedBy<AnswerFacadeService>()
                .Interceptors<SecurityInterceptor>());
            container.Register(Component.For<ITagFacadeService>().ImplementedBy<TagFacadeService>()
                .Interceptors<SecurityInterceptor>());

            container.Register(Component.For<IQuestionNotificationService>().ImplementedBy<QuestionNotificationService>()
                .Interceptors<SecurityInterceptor>().LifestyleScoped());

        }
    }
}