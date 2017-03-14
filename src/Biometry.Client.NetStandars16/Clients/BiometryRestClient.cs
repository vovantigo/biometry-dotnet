using System.Net.Http;
using System.Threading.Tasks;
using Biometry.Common.Models;
using PipServices.Net.Rest;

namespace Biometry.Client.Clients
{
    public class BiometryRestClient : RestClient, IBiometryClient
    {
        public Task<PersonBiometry[]> GetAllAsync(string correlationId)
        {
            using (var timing = Instrument(correlationId))
            {
                return ExecuteAsync<PersonBiometry[]>(
                    correlationId,
                    HttpMethod.Get,
                    "biometry" + (string.IsNullOrWhiteSpace(correlationId) ? string.Empty : $"?correlation_id={correlationId}")
                );
            }
        }

        public Task<PersonBiometry> GetByIdAsync(string correlationId, string id)
        {
            using (var timing = Instrument(correlationId))
            {
                return ExecuteAsync<PersonBiometry>(
                    correlationId,
                    HttpMethod.Get,
                    $"biometry/{id}" + (string.IsNullOrWhiteSpace(correlationId) ? string.Empty : $"?correlation_id={correlationId}")
                );
            }
        }

        public Task<PersonBiometry> CreateAsync(string correlationId, PersonBiometry item)
        {
            using (var timing = Instrument(correlationId))
            {
                return ExecuteAsync<PersonBiometry>(
                    correlationId,
                    HttpMethod.Post,
                    "biometry" + (string.IsNullOrWhiteSpace(correlationId) ? string.Empty : $"?correlation_id={correlationId}"),
                    item
                );
            }
        }
    }
}
