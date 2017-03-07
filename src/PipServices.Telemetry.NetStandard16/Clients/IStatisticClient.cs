using System;
using System.Threading.Tasks;
using PipServices.Telemetry.Models;

namespace PipServices.Telemetry.Clients
{
    interface IStatisticClient
    {
        Task<TelemetryPoint[]> GetTemperatureAsync(string correlationId, string personId, DateTime from, DateTime to);
        Task<TelemetryPoint[]> GetHeartRateAsync(string correlationId, string personId, DateTime from, DateTime to);
        Task<TelemetryPoint[]> GetBloodOxygenAsync(string correlationId, string personId, DateTime from, DateTime to);
    }
}
