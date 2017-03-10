using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PipServices.Telemetry.Logic;
using PipServices.Telemetry.Models;

namespace PipServices.Telemetry.Controllers
{
    [Route("people")]
    public class PeopleApiController : Controller
    {
        public PeopleApiController(IPeopleController controller)
        {
            if (controller == null)
                throw new ArgumentNullException(nameof(controller));

            _controller = controller;
        }

        private readonly IPeopleController _controller;

        [HttpGet]
        public async Task<Person[]> GetAllAsync([FromQuery(Name = "correlation_id")] string correlationId = null)
        {
            var result = await _controller.GetAllAsync(correlationId);
            return result.ToArray();
        }

        [HttpGet("{id}")]
        public async Task<Person> GetByIdAsync(string id,
            [FromQuery(Name = "correlation_id")] string correlationId = null)
        {
            return await _controller.GetByIdAsync(correlationId, id);
        }

        [HttpPost]
        public async Task<Person> CreateAsync([FromBody] Person entity,
            [FromQuery(Name = "correlation_id")] string correlationId = null)
        {
            return await _controller.CreateAsync(correlationId, entity);
        }

        [HttpPut]
        public async Task<Person> UpdateAsync([FromBody] Person entity,
            [FromQuery(Name = "correlation_id")] string correlationId = null)
        {
            return await _controller.UpdateAsync(correlationId, entity);
        }
    }
}
