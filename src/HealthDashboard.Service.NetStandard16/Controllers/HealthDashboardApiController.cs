using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Biometry.Common.Models;
using HealthDashboard.Logic.Logic;
using System.Linq;

namespace HealthDashboard.Service.Controllers
{
    [Route("health_dashboard")]
    public class HealthDashboardApiController : Controller
    {
        public HealthDashboardApiController(IHealthDashboardController controller)
        {
            if (controller == null)
                throw new ArgumentNullException(nameof(controller));

            _controller = controller;
        }

        private readonly IHealthDashboardController _controller;

        [HttpGet("temperature/{personId}")]
        public async Task<BiometryPoint[]> GetTemperatureAsync(string personId, 
            [FromQuery(Name = "correlation_id")] string correlationId,
            DateTime from,
            DateTime to)
        {
            var result = await _controller.GetTemperatureAsync(correlationId, personId, from, to);
            return result.ToArray();
        }

        [HttpGet("blood/{personId}")]
        public async Task<BiometryPoint[]> GetBloodOxygenAsync(string personId,
            [FromQuery(Name = "correlation_id")] string correlationId,
            DateTime from,
            DateTime to)
        {
            var result = await _controller.GetBloodOxygenAsync(correlationId, personId, from, to);
            return result.ToArray();
        }

        [HttpGet("heart/{personId}")]
        public async Task<BiometryPoint[]> GetHeartRateAsync(string personId,
            [FromQuery(Name = "correlation_id")] string correlationId,
            DateTime from,
            DateTime to)
        {
            var result = await _controller.GetHeartRateAsync(correlationId, personId, from, to);
            return result.ToArray();
        }
    }
}
