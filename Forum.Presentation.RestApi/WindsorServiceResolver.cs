﻿using System;
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
            //container.Register(Component.For<QuestionController>().LifestyleTransient());
            //container.Register(Component.For<AnswerController>().LifestyleTransient()
            //    .Interceptors<ControllerExceptionInterceptor>());
            //container.Register(Component.For<IdentityController>().LifestyleTransient());
            //container.Register(Component.For<SearchController>().LifestyleTransient());
            _serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(container, services);
        }

        public IServiceProvider GetServiceProvider()
        {
            return _serviceProvider;
        }
    }
}