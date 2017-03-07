using System.Threading.Tasks;
using PipServices.Commons.Errors;
using PipServices.Commons.Refer;
using PipServices.Net.Direct;
using PipServices.Telemetry.Build;
using PipServices.Telemetry.Logic;
using PipServices.Telemetry.Models;

namespace PipServices.Telemetry.Clients
{
    public class TelemetryDirectClient : DirectClient, ITelemetryClient
    {
        private ITelemetryController _controller;

        public override bool IsOpened()
        {
            return _controller != null;
        }

        public override void SetReferences(IReferences references)
        {
            base.SetReferences(references);

            _controller = references.GetOneRequired<ITelemetryController>(Descriptors.TelemetryController);

            if (_controller == null)
                throw new ConfigException(null, "NO_TELEMETRY_CONTROLLER", "Telemetry Controller is not configured");

        }

        public async Task<PersonTelemetry[]> GetAllAsync(string correlationId)
        {
            using (var timing = Instrument(correlationId))
            {
                var result = await _controller.GetAllAsync(correlationId);
                return result.ToArray();
            }
        }

        public Task<PersonTelemetry> GetByIdAsync(string correlationId, string id)
        {
            using (var timing = Instrument(correlationId))
            {
                return _controller.GetByIdAsync(correlationId, id);
            }
        }

        public Task<PersonTelemetry> CreateAsync(string correlationId, PersonTelemetry item)
        {
            using (var timing = Instrument(correlationId))
            {
                return _controller.CreateAsync(correlationId, item);
            }
        }
    }
}
