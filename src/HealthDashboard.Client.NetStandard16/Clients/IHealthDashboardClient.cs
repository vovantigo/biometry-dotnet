using System;
using System.Threading.Tasks;
using Biometry.Common.Models;

namespace HealthDashboard.Client.Clients
{
    interface IHealthDashboardClient
    {
        Task<BiometryPoint[]> GetTemperatureAsync(string correlationId, string personId, DateTime from, DateTime to);
        Task<BiometryPoint[]> GetHeartRateAsync(string correlationId, string personId, DateTime from, DateTime to);
        Task<BiometryPoint[]> GetBloodOxygenAsync(string correlationId, string personId, DateTime from, DateTime to);
    }
}
