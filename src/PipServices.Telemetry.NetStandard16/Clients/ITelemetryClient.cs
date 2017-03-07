using System.Threading.Tasks;
using PipServices.Telemetry.Models;

namespace PipServices.Telemetry.Clients
{
    public interface ITelemetryClient
    {
        Task<PersonTelemetry[]> GetAllAsync(string correlationId);
        Task<PersonTelemetry> GetByIdAsync(string correlationId, string id);
        Task<PersonTelemetry> CreateAsync(string correlationId, PersonTelemetry item);
    }
}
