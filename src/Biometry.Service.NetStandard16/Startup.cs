using Biometry.Common.Build;
using Biometry.Logic.Logic;
using Biometry.Service.Build;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PipServices.Commons.Refer;
using PipServices.Net.Rest;

namespace Biometry.Service
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
            services.AddSingleton<IBiometryController, BiometryController>(provider =>
            {
                var persistence = BiometryFactory.Create(Descriptors.BiometryMemoryPersistence);
                var references = References.FromTuples(Descriptors.BiometryMemoryPersistence, persistence);
                var controller = (BiometryController) BiometryFactory.Create(Descriptors.BiometryController);
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
