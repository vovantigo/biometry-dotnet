using Biometry.Common.Build;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using People.Logic.Logic;
using People.Service.Build;
using PipServices.Commons.Refer;
using PipServices.Net.Rest;

namespace People.Service
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
            services.AddSingleton<IPeopleController, PeopleController>(provider =>
            {
                var persistence = PeopleFactory.Create(Descriptors.PeopleMemoryPersistence);
                var references = References.FromTuples(Descriptors.PeopleMemoryPersistence, persistence);
                var controller = (PeopleController)PeopleFactory.Create(Descriptors.PeopleController);
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
