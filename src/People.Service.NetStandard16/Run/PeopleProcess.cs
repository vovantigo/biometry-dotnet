﻿using System.Threading;
using System.Threading.Tasks;
using PipServices.Commons.Refer;
using PipServices.Container;

namespace PipServices.Telemetry.Run
{
    public class PeopleProcess : ProcessContainer
    {
        protected override void InitReferences(IReferences references)
        {
            base.InitReferences(references);

            // Factory to statically resolve echo components
            references.Put(Descriptors.TelemetryFactory, new BiometryFactory());
        }

        public Task RunAsync(string[] args, CancellationToken token)
        {
            var configPath = args.Length > 0 ? args[0] : "./config/config.people.yaml";
            return RunWithConfigFileAsync("telemetry", args, configPath, token);
        }
    }
}
