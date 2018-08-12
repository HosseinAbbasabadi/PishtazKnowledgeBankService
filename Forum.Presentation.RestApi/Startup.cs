using Castle.Windsor;
using Forum.Infrastructure.Config;
using Framework.Application.Command;
using Framework.Castle;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Presentation.RestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(env.ContentRootPath)
            //    .AddJsonFile("appsettings.json", false, true)
            //    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
            //    .AddEnvironmentVariables();
            //Configuration = builder.Build();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICommandBus>(new CommandBus());
            var container = new WindsorContainer();
            Bootstrapper.WireUp(container);
            ForumBootstrapper.Wireup(container);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }

    public class MyConfiguration
    {
        public bool MyProperty { get; set; }
    }
}