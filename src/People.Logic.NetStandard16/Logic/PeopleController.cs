using System.Collections.Generic;
using System.Threading.Tasks;
using Biometry.Common.Build;
using Biometry.Common.Models;
using People.Logic.Memory;
using PipServices.Commons.Config;
using PipServices.Commons.Data;
using PipServices.Commons.Errors;
using PipServices.Commons.Log;
using PipServices.Commons.Refer;
using Biometry.Common.Helpers;

namespace People.Logic.Logic
{
    public class PeopleController : IPeopleController, IReferenceable, IConfigurable
    {
        private readonly CompositeLogger _logger = new CompositeLogger();
        private IPeopleMemoryPersistence _persistence;

        public Task<List<Person>> GetAllAsync(string correlationId)
        {
            _logger.Trace(correlationId, this);
            return _persistence.GetListByQueryAsync(correlationId, string.Empty, new SortParams());
        }

        public Task<Person> GetByIdAsync(string correlationId, string id)
        {
            _logger.Trace(correlationId, this);
            return _persistence.GetOneByIdAsync(correlationId, id);
        }

        public Task<Person> CreateAsync(string correlationId, Person item)
        {
            _logger.Trace(correlationId, this);
            return _persistence.CreateAsync(correlationId, item);
        }

        public Task<Person> UpdateAsync(string correlationId, Person item)
        {
            _logger.Trace(correlationId, this);
            return _persistence.UpdateAsync(correlationId, item);
        }

        public void SetReferences(IReferences references)
        {
            _logger.SetReferences(references);

            _persistence = references.GetOneRequired<IPeopleMemoryPersistence>(Descriptors.PeopleMemoryPersistence);

            if (_persistence == null)
                throw new ConfigException(null, "NO_PERSISTENCE", "People Memory Persistance is not configured");

            _persistence.SetReferences(references);
        }

        public void Configure(ConfigParams config)
        {
            _logger.Configure(config);
        }
    }
}
