using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Biometry.Common.Models;

namespace HealthDashboard.Logic.Logic
{
    public interface IHealthDashboardController
    {
        Task<IEnumerable<BiometryPoint>> GetTemperatureAsync(string correlationId, string personId, DateTime from, DateTime to);
        Task<IEnumerable<BiometryPoint>> GetHeartRateAsync(string correlationId, string personId, DateTime from, DateTime to);
        Task<IEnumerable<BiometryPoint>> GetBloodOxygenAsync(string correlationId, string personId, DateTime from, DateTime to);
    }
}
