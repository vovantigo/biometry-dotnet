using System.Collections.Generic;
using System.Threading.Tasks;
using Biometry.Common.Build;
using Biometry.Common.Helpers;
using Biometry.Common.Models;
using Biometry.Logic.Memory;
using PipServices.Commons.Config;
using PipServices.Commons.Data;
using PipServices.Commons.Errors;
using PipServices.Commons.Log;
using PipServices.Commons.Refer;

namespace Biometry.Logic.Logic
{
    public class BiometryController : IBiometryController, IReferenceable, IConfigurable
    {
        private readonly CompositeLogger _logger = new CompositeLogger();
        private IBiometryMemoryPersistence _persistence;

        public Task<List<PersonBiometry>> GetAllAsync(string correlationId)
        {
            _logger.Trace(correlationId, this);
            return _persistence.GetListByQueryAsync(correlationId, string.Empty, new SortParams());
        }

        public Task<PersonBiometry> GetByIdAsync(string correlationId, string id)
        {
            _logger.Trace(correlationId, this);
            return _persistence.GetOneByIdAsync(correlationId, id);
        }

        public Task<PersonBiometry> CreateAsync(string correlationId, PersonBiometry item)
        {
            _logger.Trace(correlationId, this);
            return _persistence.CreateAsync(correlationId, item);
        }

        public Task<PersonBiometry> UpdateAsync(string correlationId, PersonBiometry item)
        {
            _logger.Trace(correlationId, this);
            return _persistence.UpdateAsync(correlationId, item);
        }

        public void SetReferences(IReferences references)
        {
            _logger.SetReferences(references);

            _persistence = references.GetOneRequired<IBiometryMemoryPersistence>(Descriptors.BiometryMemoryPersistence);

            if (_persistence == null)
                throw new ConfigException(null, "NO_PERSISTENCE", "Biometry Memory Persistance is not configured");

            _persistence.SetReferences(references);
        }

        public void Configure(ConfigParams config)
        {
            _logger.Configure(config);
        }
    }
}
