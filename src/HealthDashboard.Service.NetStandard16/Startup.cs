using Biometry.Common.Build;
using HealthDashboard.Logic.Logic;
using HealthDashboard.Service.Build;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PipServices.Commons.Refer;
using PipServices.Net.Rest;

namespace HealthDashboard.Service
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddMvc();
            builder.AddMvcOptions(o =>
            {
                o.Filters.Add(typeof(RestExceptionHandler));
            });
            services.AddSingleton<IHealthDashboardController, HealthDashboardController>(provider =>
            {
                var client = HealthDashboardFactory.Create(Descriptors.BiometryClient);
                var references = References.FromTuples(Descriptors.BiometryClient, client);
                var controller = (HealthDashboardController)HealthDashboardFactory.Create(Descriptors.HealthDashboardController);
                controller.SetReferences(references);
                return controller;
            });
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IApplicationLifetime applicationLifetime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseMvc();
        }
    }
}
