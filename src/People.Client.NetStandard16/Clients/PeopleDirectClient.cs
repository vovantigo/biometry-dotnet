using System.Threading.Tasks;
using Biometry.Common.Build;
using Biometry.Common.Models;
using People.Logic.Logic;
using PipServices.Commons.Errors;
using PipServices.Commons.Refer;
using PipServices.Net.Direct;

namespace People.Client.Clients
{
    public class PeopleDirectClient : DirectClient, IPeopleClient
    {
        private IPeopleController _controller;

        public override bool IsOpened()
        {
            return _controller != null;
        }

        public override void SetReferences(IReferences references)
        {
            base.SetReferences(references);

            _controller = references.GetOneRequired<IPeopleController>(Descriptors.PeopleController);

            if (_controller == null)
                throw new ConfigException(null, "NO_PEOPLE_CONTROLLER", "People Controller is not configured");

        }

        public async Task<Person[]> GetAllAsync(string correlationId)
        {
            using (var timing = Instrument(correlationId))
            {
                var result = await _controller.GetAllAsync(correlationId);
                return result.ToArray();
            }
        }

        public Task<Person> GetByIdAsync(string correlationId, string id)
        {
            using (var timing = Instrument(correlationId))
            {
                return _controller.GetByIdAsync(correlationId, id);
            }
        }

        public Task<Person> CreateAsync(string correlationId, Person item)
        {
            using (var timing = Instrument(correlationId))
            {
                return _controller.CreateAsync(correlationId, item);
            }
        }

        public Task<Person> UpdateAsync(string correlationId, Person item)
        {
            using (var timing = Instrument(correlationId))
            {
                return _controller.UpdateAsync(correlationId, item);
            }
        }
    }
}
