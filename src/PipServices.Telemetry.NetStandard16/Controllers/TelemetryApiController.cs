using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PipServices.Telemetry.Logic;
using PipServices.Telemetry.Models;

namespace PipServices.Telemetry.Controllers
{
    [Route("telemetry")]
    public class TelemetryApiController : Controller
    {
        public TelemetryApiController(ITelemetryController controller)
        {
            if (controller == null)
                throw new ArgumentNullException(nameof(controller));

            _controller = controller;
        }

        private readonly ITelemetryController _controller;

        [HttpGet]
        public async Task<PersonTelemetry[]> GetAllAsync([FromQuery(Name = "correlation_id")] string correlationId = null)
        {
            var result = await _controller.GetAllAsync(correlationId);
            return result.ToArray();
        }

        [HttpGet("{id}")]
        public async Task<PersonTelemetry> GetByIdAsync(string id,
            [FromQuery(Name = "correlation_id")] string correlationId = null)
        {
            return await _controller.GetByIdAsync(correlationId, id);
        }

        [HttpPost]
        public async Task<PersonTelemetry> CreateAsync([FromBody] PersonTelemetry entity,
            [FromQuery(Name = "correlation_id")] string correlationId = null)
        {
            return await _controller.CreateAsync(correlationId, entity);
        }
    }
}
