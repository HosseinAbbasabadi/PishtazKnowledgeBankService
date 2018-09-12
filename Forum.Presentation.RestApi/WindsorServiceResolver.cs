using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Forum.Presentation.RestApi.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Presentation.RestApi
{
    public class WindsorServiceResolver
    {
        private static IServiceProvider _serviceProvider;

        public WindsorServiceResolver(IServiceCollection services, IWindsorContainer container)
        {
            container.Register(Component.For<QuestionController>().LifestyleTransient());
            container.Register(Component.For<AnswerController>().LifestyleTransient());
            _serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(container, services);
        }

        public IServiceProvider GetServiceProvider()
        {
            return _serviceProvider;
        }
    }
}