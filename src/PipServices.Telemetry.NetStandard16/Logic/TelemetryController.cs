using System.Collections.Generic;
using System.Threading.Tasks;
using PipServices.Commons.Config;
using PipServices.Commons.Data;
using PipServices.Commons.Errors;
using PipServices.Commons.Log;
using PipServices.Commons.Refer;
using PipServices.Telemetry.Build;
using PipServices.Telemetry.Helpers;
using PipServices.Telemetry.Memory;
using PipServices.Telemetry.Models;

namespace PipServices.Telemetry.Logic
{
    public class TelemetryController : ITelemetryController, IReferenceable, IConfigurable
    {
        private readonly CompositeLogger _logger = new CompositeLogger();
        private ITelemetryMemoryPersistence _persistence;

        public Task<List<PersonTelemetry>> GetAllAsync(string correlationId)
        {
            _logger.Trace(correlationId, this);
            return _persistence.GetListByQueryAsync(correlationId, string.Empty, new SortParams());
        }

        public Task<PersonTelemetry> GetByIdAsync(string correlationId, string id)
        {
            _logger.Trace(correlationId, this);
            return _persistence.GetOneByIdAsync(correlationId, id);
        }

        public Task<PersonTelemetry> CreateAsync(string correlationId, PersonTelemetry item)
        {
            _logger.Trace(correlationId, this);
            return _persistence.CreateAsync(correlationId, item);
        }

        public Task<PersonTelemetry> UpdateAsync(string correlationId, PersonTelemetry item)
        {
            _logger.Trace(correlationId, this);
            return _persistence.UpdateAsync(correlationId, item);
        }

        public void SetReferences(IReferences references)
        {
            _logger.SetReferences(references);

            _persistence = references.GetOneRequired<ITelemetryMemoryPersistence>(Descriptors.TelemetryMemoryPersistence);

            if (_persistence == null)
                throw new ConfigException(null, "NO_PERSISTENCE", "Telemetry Memory Persistance is not configured");

            _persistence.SetReferences(references);
        }

        public void Configure(ConfigParams config)
        {
            _logger.Configure(config);
        }
    }
}
