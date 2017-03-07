using PipServices.Data.Memory;
using PipServices.Telemetry.Models;

namespace PipServices.Telemetry.Memory
{
    public class TelemetryMemoryPersistence : IdentifiableMemoryPersistence<PersonTelemetry, string>, ITelemetryMemoryPersistence
    {
    }
}
