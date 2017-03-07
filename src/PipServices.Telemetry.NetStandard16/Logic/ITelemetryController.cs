using System.Collections.Generic;
using System.Threading.Tasks;
using PipServices.Telemetry.Models;

namespace PipServices.Telemetry.Logic
{
    public interface ITelemetryController
    {
        Task<List<PersonTelemetry>> GetAllAsync(string correlationId);
        Task<PersonTelemetry> GetByIdAsync(string correlationId, string id);
        Task<PersonTelemetry> CreateAsync(string correlationId, PersonTelemetry item);
    }
}
