﻿using System;
using Castle.Windsor;
using Forum.Infrastructure.Config;
using Framework.Castle;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Presentation.RestApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("policy",
                builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials()));

            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.Configure<MvcOptions>(options =>
            {
                //options.Filters.Add(new CorsAuthorizationFilterFactory("policy"));
            });

            //Begin Identity Configuration

            services.AddAuthentication("Bearer").AddIdentityServerAuthentication(options =>
            {
                options.Authority = "http://192.168.249.12:5000";
                options.RequireHttpsMetadata = false;
                options.ApiName = "Forum_Api";
            });

            //End Identity Configuration

            var container = new WindsorContainer();
            Bootstrapper.WireUp(container);
            var connectionString = Configuration["ConnectionStrings:DBConnection"];
            ForumBootstrapper.Wireup(container, connectionString);
            var service = new WindsorServiceResolver(services, container).GetServiceProvider();
            return service;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("policy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseControllerExceptionHandler();
            }
            //else
            //{
            //    app.UseControllerExceptionHandler();
            //    app.UseExceptionHandler();
            //}

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}