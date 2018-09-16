using System;
using Castle.Windsor;
using Forum.Infrastructure.Config;
using Framework.Castle;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            //Begin Identity Configuration

            services.AddMvcCore().AddAuthorization().AddJsonFormatters();
            services.AddAuthentication("Bearer").AddIdentityServerAuthentication(options =>
            {
                options.Authority = "http://localhost:5000";
                options.RequireHttpsMetadata = false;
                options.ApiName = "Forum_Api";
            });

            //End Identity Configuration

            var container = new WindsorContainer();
            Bootstrapper.WireUp(container);
            var connectionString = Configuration["ConnectionStrings:DBConnection"];
            ForumBootstrapper.Wireup(container, connectionString);
            services.AddCors();
            var service = new WindsorServiceResolver(services, container).GetServiceProvider();
            return service;
        }

        //public IServiceProvider ConfigureServices(IServiceCollection services)
        //{
        //    var container = new WindsorContainer();
        //    var service = new WindsorServiceResolver(container);
        //    Bootstrapper.WireUp(container);
        //    ForumBootstrapper.Wireup(container);
        //    services.AddCors();
        //    services.AddMvc();
        //    return service;
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        "default",
            //        "{controller}/{id?}");
            //});
            app.UseMvc();
        }
    }
}