using System;
using Castle.Windsor;
using Framework.Castle;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            services.AddCors();
            var cors = new DefaultCorsPolicyService(new Logger<DefaultCorsPolicyService>(new LoggerFactory()))
            {
                AllowAll = true
            };
            services.AddSingleton<ICorsPolicyService>(cors);
            var connectionString = Configuration["ConnectionStrings:DBConnection"];

            //Begin Identity Configuration
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            var knowladgeBankUi = Configuration["EndPoints:KnowladgeBankUi"];
            var identityServerConfiguration = new IdentityServerConfiguration(knowladgeBankUi);
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(identityServerConfiguration.ApiResources())
                .AddInMemoryClients(identityServerConfiguration.Clients())
                .AddInMemoryIdentityResources(identityServerConfiguration.IdentityResources())
                .AddTestUsers(TestUsers.GetUsers());

            //End Identity Configuration
            var container = new WindsorContainer();
            FrameworkBootstrapper.WireUp(container);

            UserManagementBootstrapper.Wireup(container, connectionString);
            var service = new WindsorServiceResolver(services, container).GetServiceProvider();
            return service;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseIdentityServer();
            app.UseMvcWithDefaultRoute();
        }
    }
}