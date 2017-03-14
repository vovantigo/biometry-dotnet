using System.Threading;
using System.Threading.Tasks;
using PipServices.Commons.Refer;
using PipServices.Container;
using Biometry.Common.Build;
using HealthDashboard.Service.Build;

namespace HealthDashboard.Service.Run
{
    public class HealthDashboardProcess : ProcessContainer
    {
        protected override void InitReferences(IReferences references)
        {
            base.InitReferences(references);

            // Factory to statically resolve echo components
            references.Put(Descriptors.HealthDashboardFactory, new HealthDashboardFactory());
        }

        public Task RunAsync(string[] args, CancellationToken token)
        {
            var configPath = args.Length > 0 ? args[0] : "./config/config.dashboard.yaml";
            return RunWithConfigFileAsync("health_dashboard", args, configPath, token);
        }
    }
}
