using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Biometry.Client.Clients;
using Biometry.Common.Build;
using Biometry.Common.Helpers;
using Biometry.Common.Models;
using PipServices.Commons.Config;
using PipServices.Commons.Errors;
using PipServices.Commons.Log;
using PipServices.Commons.Refer;
using System.Linq;

namespace HealthDashboard.Logic.Logic
{
    public class HealthDashboardController : IHealthDashboardController, IReferenceable, IConfigurable
    {
        private readonly CompositeLogger _logger = new CompositeLogger();
        private IBiometryClient _client;

        public void SetReferences(IReferences references)
        {
            _logger.SetReferences(references);

            _client = references.GetOneRequired<IBiometryClient>(Descriptors.BiometryClient);

            if (_client == null)
                throw new ConfigException(null, "NO_BIOMETRY_CLIENT", "Telemetry Client is not configured");

            var referensable = _client as IReferenceable;
            referensable?.SetReferences(references);
        }

        public void Configure(ConfigParams config)
        {
            _logger.Configure(config);
        }

        public async Task<IEnumerable<BiometryPoint>> GetTemperatureAsync(string correlationId, string personId, DateTime @from, DateTime to)
        {
            _logger.Trace(correlationId, this);

            var telemetries = await _client.GetAllAsync(correlationId);
            var result =
                telemetries.Where(x => x.PersonId.Equals(personId) && x.ReadDataTime >= from && x.ReadDataTime <= to)
                    .Select(x => new BiometryPoint { ReadDataTime = x.ReadDataTime, Value = x.Temperature}).ToList();
            return result;
        }

        public async Task<IEnumerable<BiometryPoint>> GetHeartRateAsync(string correlationId, string personId, DateTime @from, DateTime to)
        {
            var telemetries = await _client.GetAllAsync(correlationId);
            var result =
                telemetries.Where(x => x.PersonId.Equals(personId) && x.ReadDataTime >= from && x.ReadDataTime <= to)
                    .Select(x => new BiometryPoint { ReadDataTime = x.ReadDataTime, Value = x.HeartRate }).ToList();
            return result;
        }

        public async Task<IEnumerable<BiometryPoint>> GetBloodOxygenAsync(string correlationId, string personId, DateTime @from, DateTime to)
        {
            var telemetries = await _client.GetAllAsync(correlationId);
            var result =
                telemetries.Where(x => x.PersonId.Equals(personId) && x.ReadDataTime >= from && x.ReadDataTime <= to)
                    .Select(x => new BiometryPoint { ReadDataTime = x.ReadDataTime, Value = x.BloodOxygen }).ToList();
            return result;
        }
    }
}
