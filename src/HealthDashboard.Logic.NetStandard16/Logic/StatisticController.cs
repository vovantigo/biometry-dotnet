using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PipServices.Commons.Config;
using PipServices.Commons.Errors;
using PipServices.Commons.Log;
using PipServices.Commons.Refer;
using PipServices.Telemetry.Build;
using PipServices.Telemetry.Clients;
using PipServices.Telemetry.Models;
using PipServices.Telemetry.Helpers;

namespace PipServices.Telemetry.Logic
{
    public class StatisticController : IStatisticController, IReferenceable, IConfigurable
    {
        private readonly CompositeLogger _logger = new CompositeLogger();
        private ITelemetryClient _client;

        public void SetReferences(IReferences references)
        {
            _logger.SetReferences(references);

            _client = references.GetOneRequired<ITelemetryClient>(Descriptors.TelemetryClient);

            if (_client == null)
                throw new ConfigException(null, "NO_TELEMETRY_CLIENT", "Telemetry Client is not configured");

            var referensable = _client as IReferenceable;
            referensable?.SetReferences(references);
        }

        public void Configure(ConfigParams config)
        {
            _logger.Configure(config);
        }

        public async Task<IEnumerable<TelemetryPoint>> GetTemperatureAsync(string correlationId, string personId, DateTime @from, DateTime to)
        {
            _logger.Trace(correlationId, this);

            var telemetries = await _client.GetAllAsync(correlationId);
            var result =
                telemetries.Where(x => x.PersonId.Equals(personId) && x.ReadDataTime >= from && x.ReadDataTime <= to)
                    .Select(x => new TelemetryPoint {ReadDataTime = x.ReadDataTime, Value = x.Temperature}).ToList();
            return result;
        }

        public async Task<IEnumerable<TelemetryPoint>> GetHeartRateAsync(string correlationId, string personId, DateTime @from, DateTime to)
        {
            var telemetries = await _client.GetAllAsync(correlationId);
            var result =
                telemetries.Where(x => x.PersonId.Equals(personId) && x.ReadDataTime >= from && x.ReadDataTime <= to)
                    .Select(x => new TelemetryPoint { ReadDataTime = x.ReadDataTime, Value = x.HeartRate }).ToList();
            return result;
        }

        public async Task<IEnumerable<TelemetryPoint>> GetBloodOxygenAsync(string correlationId, string personId, DateTime @from, DateTime to)
        {
            var telemetries = await _client.GetAllAsync(correlationId);
            var result =
                telemetries.Where(x => x.PersonId.Equals(personId) && x.ReadDataTime >= from && x.ReadDataTime <= to)
                    .Select(x => new TelemetryPoint { ReadDataTime = x.ReadDataTime, Value = x.BloodOxygen }).ToList();
            return result;
        }
    }
}
