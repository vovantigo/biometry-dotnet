using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PipServices.Telemetry.Models;

namespace PipServices.Telemetry.Logic
{
    public interface IStatisticController
    {
        Task<IEnumerable<TelemetryPoint>> GetTemperatureAsync(string correlationId, string personId, DateTime from, DateTime to);
        Task<IEnumerable<TelemetryPoint>> GetHeartRateAsync(string correlationId, string personId, DateTime from, DateTime to);
        Task<IEnumerable<TelemetryPoint>> GetBloodOxygenAsync(string correlationId, string personId, DateTime from, DateTime to);
    }
}
