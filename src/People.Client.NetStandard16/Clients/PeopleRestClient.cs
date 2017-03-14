using System.Net.Http;
using System.Threading.Tasks;
using Biometry.Common.Models;
using PipServices.Net.Rest;

namespace People.Client.Clients
{
    public class PeopleRestClient : RestClient, IPeopleClient
    {
        public Task<Person[]> GetAllAsync(string correlationId)
        {
            using (var timing = Instrument(correlationId))
            {
                return ExecuteAsync<Person[]>(
                    correlationId,
                    HttpMethod.Get,
                    "people" + (string.IsNullOrWhiteSpace(correlationId) ? string.Empty : $"?correlation_id={correlationId}")
                );
            }
        }

        public Task<Person> GetByIdAsync(string correlationId, string id)
        {
            using (var timing = Instrument(correlationId))
            {
                return ExecuteAsync<Person>(
                    correlationId,
                    HttpMethod.Get,
                    $"people/{id}" + (string.IsNullOrWhiteSpace(correlationId) ? string.Empty : $"?correlation_id={correlationId}")
                );
            }
        }

        public Task<Person> CreateAsync(string correlationId, Person item)
        {
            using (var timing = Instrument(correlationId))
            {
                return ExecuteAsync<Person>(
                    correlationId,
                    HttpMethod.Post,
                    "people" + (string.IsNullOrWhiteSpace(correlationId) ? string.Empty : $"?correlation_id={correlationId}"),
                    item
                );
            }
        }

        public Task<Person> UpdateAsync(string correlationId, Person item)
        {
            using (var timing = Instrument(correlationId))
            {
                return ExecuteAsync<Person>(
                    correlationId,
                    HttpMethod.Put,
                    $"people?correlation_id={correlationId}",
                    item
                );
            }
        }
    }
}
