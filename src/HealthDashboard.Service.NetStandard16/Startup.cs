using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PipServices.Net.Rest;
using PipServices.Telemetry.Logic;

namespace PipServices.Telemetry
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
            //var builder = services.AddMvc();
            //builder.AddMvcOptions(o =>
            //{
            //    o.Filters.Add(new RestExceptionHandler());
            //});

            services.AddSingleton<IPeopleController, PeopleController>();
            services.AddSingleton<ITelemetryController, TelemetryController>();
            services.AddSingleton<IStatisticController, StatisticController>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IApplicationLifetime applicationLifetime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseMvc();
        }
    }
}
