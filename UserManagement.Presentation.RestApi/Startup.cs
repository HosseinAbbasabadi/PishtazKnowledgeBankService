using System;
using Castle.Windsor;
using Framework.Castle;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using UserManagement.Infrastructure.Config;

namespace UserManagement.Presentation.RestApi
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
            //Begin Identity Configuration

            services.AddMvc();
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(Config.ApiResources())
                .AddInMemoryClients(Config.Clients())
                .AddTestUsers(TestUser.GetUsers())
                .AddInMemoryIdentityResources(Config.GetIdentityResources());

            services.AddCors();
            var cors = new DefaultCorsPolicyService(new Logger<DefaultCorsPolicyService>(new LoggerFactory()))
            {
                AllowedOrigins = { "http://localhost:4200" }
            };
            services.AddSingleton<ICorsPolicyService>(cors);



            //End Identity Configuration
            var container = new WindsorContainer();
            Bootstrapper.WireUp(container);

            var connectionString = Configuration["ConnectionStrings:DBConnection"];
            UserManagementBootstrapper.Wireup(container, connectionString);
            services.AddCors();
            services.AddMvc();
            services.AddCors();
            var service = new WindsorServiceResolver(services, container).GetServiceProvider();
            return service;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseIdentityServer();
            app.UseMvcWithDefaultRoute();
        }
    }
}