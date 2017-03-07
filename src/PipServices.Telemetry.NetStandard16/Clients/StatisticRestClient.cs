using System;
using System.Net.Http;
using System.Threading.Tasks;
using PipServices.Net.Rest;
using PipServices.Telemetry.Models;

namespace PipServices.Telemetry.Clients
{
    public class StatisticRestClient : RestClient, IStatisticClient
    {
        public Task<TelemetryPoint[]> GetTemperatureAsync(string correlationId, string personId, DateTime from, DateTime to)
        {
            using (var timing = Instrument(correlationId))
            {
                return ExecuteAsync<TelemetryPoint[]>(
                    correlationId,
                    HttpMethod.Get,
                    $"statistic/temperature/{personId}?correlation_id={correlationId}&from={from}&to={to}"
                );
            }
        }

        public Task<TelemetryPoint[]> GetHeartRateAsync(string correlationId, string personId, DateTime from, DateTime to)
        {
            using (var timing = Instrument(correlationId))
            {
                return ExecuteAsync<TelemetryPoint[]>(
                    correlationId,
                    HttpMethod.Get,
                    $"statistic/heart/{personId}?correlation_id={correlationId}&from={from}&to={to}"
                );
            }
        }

        public Task<TelemetryPoint[]> GetBloodOxygenAsync(string correlationId, string personId, DateTime from, DateTime to)
        {
            using (var timing = Instrument(correlationId))
            {
                return ExecuteAsync<TelemetryPoint[]>(
                    correlationId,
                    HttpMethod.Get,
                    $"statistic/blood/{personId}?correlation_id={correlationId}&from={from}&to={to}"
                );
            }
        }
    }
}
