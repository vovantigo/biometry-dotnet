using System;
using System.Net.Http;
using System.Threading.Tasks;
using Biometry.Common.Models;
using PipServices.Net.Rest;

namespace HealthDashboard.Client.Clients
{
    public class HealthDashboardRestClient : RestClient, IHealthDashboardClient
    {
        public Task<BiometryPoint[]> GetTemperatureAsync(string correlationId, string personId, DateTime from, DateTime to)
        {
            using (var timing = Instrument(correlationId))
            {
                return ExecuteAsync<BiometryPoint[]>(
                    correlationId,
                    HttpMethod.Get,
                    $"health_dashboard/temperature/{personId}?from={from}&to={to}" + (string.IsNullOrWhiteSpace(correlationId) ? string.Empty : $"&correlation_id={correlationId}")
                );
            }
        }

        public Task<BiometryPoint[]> GetHeartRateAsync(string correlationId, string personId, DateTime from, DateTime to)
        {
            using (var timing = Instrument(correlationId))
            {
                return ExecuteAsync<BiometryPoint[]>(
                    correlationId,
                    HttpMethod.Get,
                    $"health_dashboard/heart/{personId}?from={from}&to={to}" + (string.IsNullOrWhiteSpace(correlationId) ? string.Empty : $"&correlation_id={correlationId}")
                );
            }
        }

        public Task<BiometryPoint[]> GetBloodOxygenAsync(string correlationId, string personId, DateTime from, DateTime to)
        {
            using (var timing = Instrument(correlationId))
            {
                return ExecuteAsync<BiometryPoint[]>(
                    correlationId,
                    HttpMethod.Get,
                    $"health_dashboard/blood/{personId}?from={from}&to={to}" + (string.IsNullOrWhiteSpace(correlationId) ? string.Empty : $"&correlation_id={correlationId}")
                );
            }
        }
    }
}
