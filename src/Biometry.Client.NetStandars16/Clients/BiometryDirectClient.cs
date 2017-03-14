using System.Threading.Tasks;
using Biometry.Common.Build;
using Biometry.Common.Models;
using Biometry.Logic.Logic;
using PipServices.Commons.Errors;
using PipServices.Commons.Refer;
using PipServices.Net.Direct;

namespace Biometry.Client.Clients
{
    public class BiometryDirectClient : DirectClient, IBiometryClient
    {
        private IBiometryController _controller;

        public override bool IsOpened()
        {
            return _controller != null;
        }

        public override void SetReferences(IReferences references)
        {
            base.SetReferences(references);

            _controller = references.GetOneRequired<IBiometryController>(Descriptors.BiometryController);

            if (_controller == null)
                throw new ConfigException(null, "NO_BIOMETRY_CONTROLLER", "Biometry Controller is not configured");

        }

        public async Task<PersonBiometry[]> GetAllAsync(string correlationId)
        {
            using (var timing = Instrument(correlationId))
            {
                var result = await _controller.GetAllAsync(correlationId);
                return result.ToArray();
            }
        }

        public Task<PersonBiometry> GetByIdAsync(string correlationId, string id)
        {
            using (var timing = Instrument(correlationId))
            {
                return _controller.GetByIdAsync(correlationId, id);
            }
        }

        public Task<PersonBiometry> CreateAsync(string correlationId, PersonBiometry item)
        {
            using (var timing = Instrument(correlationId))
            {
                return _controller.CreateAsync(correlationId, item);
            }
        }
    }
}
