using System.Net.Http;
using System.Threading.Tasks;
using PipServices.Net.Rest;
using PipServices.Telemetry.Models;

namespace PipServices.Telemetry.Clients
{
    public class TelemetryRestClient : RestClient, ITelemetryClient
    {
        public Task<PersonTelemetry[]> GetAllAsync(string correlationId)
        {
            using (var timing = Instrument(correlationId))
            {
                return ExecuteAsync<PersonTelemetry[]>(
                    correlationId,
                    HttpMethod.Get,
                    $"telemetry?correlation_id={correlationId}"
                );
            }
        }

        public Task<PersonTelemetry> GetByIdAsync(string correlationId, string id)
        {
            using (var timing = Instrument(correlationId))
            {
                return ExecuteAsync<PersonTelemetry>(
                    correlationId,
                    HttpMethod.Get,
                    $"telemetry/{id}?correlation_id={correlationId}"
                );
            }
        }

        public Task<PersonTelemetry> CreateAsync(string correlationId, PersonTelemetry item)
        {
            using (var timing = Instrument(correlationId))
            {
                return ExecuteAsync<PersonTelemetry>(
                    correlationId,
                    HttpMethod.Post,
                    $"telemetry?correlation_id={correlationId}",
                    item
                );
            }
        }
    }
}
