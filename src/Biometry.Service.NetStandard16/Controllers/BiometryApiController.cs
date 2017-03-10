using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Biometry.Logic.Logic;
using Biometry.Common.Models;

namespace Biometry.Service.Controllers
{
    [Route("biometry")]
    public class BiometryApiController : Controller
    {
        public BiometryApiController(IBiometryController controller)
        {
            if (controller == null)
                throw new ArgumentNullException(nameof(controller));

            _controller = controller;
        }

        private readonly IBiometryController _controller;

        [HttpGet]
        public async Task<PersonBiometry[]> GetAllAsync([FromQuery(Name = "correlation_id")] string correlationId = null)
        {
            var result = await _controller.GetAllAsync(correlationId);
            return result.ToArray();
        }

        [HttpGet("{id}")]
        public async Task<PersonBiometry> GetByIdAsync(string id,
            [FromQuery(Name = "correlation_id")] string correlationId = null)
        {
            return await _controller.GetByIdAsync(correlationId, id);
        }

        [HttpPost]
        public async Task<PersonBiometry> CreateAsync([FromBody] PersonBiometry entity,
            [FromQuery(Name = "correlation_id")] string correlationId = null)
        {
            return await _controller.CreateAsync(correlationId, entity);
        }
    }
}
