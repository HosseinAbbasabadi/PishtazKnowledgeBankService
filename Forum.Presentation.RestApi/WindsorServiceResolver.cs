using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Forum.Presentation.RestApi.Controllers;
using Framework.Castle;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Presentation.RestApi
{
    public class WindsorServiceResolver
    {
        private static IServiceProvider _serviceProvider;

        public WindsorServiceResolver(IServiceCollection services, IWindsorContainer container)
        {
            _serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(container, services);
        }

        public IServiceProvider GetServiceProvider()
        {
            return _serviceProvider;
        }
    }
}