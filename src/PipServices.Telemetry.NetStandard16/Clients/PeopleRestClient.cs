using System.Net.Http;
using System.Threading.Tasks;
using PipServices.Net.Rest;
using PipServices.Telemetry.Models;

namespace PipServices.Telemetry.Clients
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
                    $"people?correlation_id={correlationId}"
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
                    $"people/{id}?correlation_id={correlationId}"
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
                    $"people?correlation_id={correlationId}",
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
