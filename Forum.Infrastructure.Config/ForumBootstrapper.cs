﻿using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Forum.Application;
using Forum.Domain.Models.Questions;
using Forum.Infrastructure.Persistance.Nh;
using Forum.Infrastructure.Persistance.Nh.Mappings;
using Forum.Presentation.Query;
using Framework.Application.Command;
using Framework.Nhibernate;
using NHibernate;

namespace Forum.Infrastructure.Config
{
    public static class ForumBootstrapper
    {
        public static void Wireup(WindsorContainer container)
        {
            const string boundedContextName = "Forum";
            const string sessionName = boundedContextName + "_Session";
            const string connectionString = "Data Source=.;Initial Catalog=KnowladgeBank;User ID=sa;Password=123456";

            container.Register(Classes.FromAssemblyContaining(typeof(QuestionCommandHandler))
                .BasedOn(typeof(ICommandHandler<>)).WithService.AllInterfaces().LifestyleTransient());

            container.Register(Component.For<IQuestionRepository>().ImplementedBy<QuestionRepository>()
                .LifestyleBoundTo<QuestionCommandHandler>());

            container.Register(Component.For<IQuestionQuery>().ImplementedBy<QuestionQuery>());

            var sessionFactory =
                SessionFactoryBuilder.CreateByConnectionStringName(connectionString, typeof(QuestionMapping).Assembly);

            container.Register(Component.For<ISession>()
                .UsingFactoryMethod(a => sessionFactory.OpenSession()).LifestyleSingleton().Named(sessionName));
        }
    }
}