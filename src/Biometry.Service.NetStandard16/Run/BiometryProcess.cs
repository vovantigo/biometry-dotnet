using System.Threading;
using System.Threading.Tasks;
using Biometry.Service.Build;
using PipServices.Commons.Refer;
using PipServices.Container;
using Biometry.Common.Build;

namespace Biometry.Service.Run
{
    public class BiometryProcess : ProcessContainer
    {
        protected override void InitReferences(IReferences references)
        {
            base.InitReferences(references);

            // Factory to statically resolve echo components
            references.Put(Descriptors.BiometryFactory, new BiometryFactory());
        }

        public Task RunAsync(string[] args, CancellationToken token)
        {
            var configPath = args.Length > 0 ? args[0] : "./config/config.biometry.yaml";
            return RunWithConfigFileAsync("biometry", args, configPath, token);
        }
    }
}
