using System.Threading;
using System.Threading.Tasks;
using PipServices.Commons.Refer;
using PipServices.Container;
using Biometry.Common.Build;
using People.Service.Build;

namespace People.Service.Run
{
    public class PeopleProcess : ProcessContainer
    {
        protected override void InitReferences(IReferences references)
        {
            base.InitReferences(references);

            // Factory to statically resolve echo components
            references.Put(Descriptors.PeopleFactory, new PeopleFactory());
        }

        public Task RunAsync(string[] args, CancellationToken token)
        {
            var configPath = args.Length > 0 ? args[0] : "./config/config.people.yaml";
            return RunWithConfigFileAsync("people", args, configPath, token);
        }
    }
}
