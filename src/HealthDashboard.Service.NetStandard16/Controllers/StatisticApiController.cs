using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PipServices.Telemetry.Logic;
using PipServices.Telemetry.Models;

namespace PipServices.Telemetry.Controllers
{
    [Route("statistic")]
    public class StatisticApiController : Controller
    {
        public StatisticApiController(IStatisticController controller)
        {
            if (controller == null)
                throw new ArgumentNullException(nameof(controller));

            _controller = controller;
        }

        private readonly IStatisticController _controller;

        [HttpGet("temperature/{personId}")]
        public async Task<TelemetryPoint[]> GetTemperatureAsync(string personId, 
            [FromQuery(Name = "correlation_id")] string correlationId,
            DateTime from,
            DateTime to)
        {
            var result = await _controller.GetTemperatureAsync(correlationId, personId, from, to);
            return result.ToArray();
        }

        [HttpGet("blood/{personId}")]
        public async Task<TelemetryPoint[]> GetBloodOxygenAsync(string personId,
            [FromQuery(Name = "correlation_id")] string correlationId,
            DateTime from,
            DateTime to)
        {
            var result = await _controller.GetBloodOxygenAsync(correlationId, personId, from, to);
            return result.ToArray();
        }

        [HttpGet("heart/{personId}")]
        public async Task<TelemetryPoint[]> GetHeartRateAsync(string personId,
            [FromQuery(Name = "correlation_id")] string correlationId,
            DateTime from,
            DateTime to)
        {
            var result = await _controller.GetHeartRateAsync(correlationId, personId, from, to);
            return result.ToArray();
        }
    }
}
