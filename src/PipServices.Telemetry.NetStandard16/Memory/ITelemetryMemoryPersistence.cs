using PipServices.Commons.Config;
using PipServices.Commons.Refer;
using PipServices.Commons.Run;
using PipServices.Data;
using PipServices.Telemetry.Models;

namespace PipServices.Telemetry.Memory
{
    interface ITelemetryMemoryPersistence : IReferenceable, IOpenable, ICleanable, IReconfigurable,
        IWriter<PersonTelemetry, string>, IGetter<PersonTelemetry, string>, ISetter<PersonTelemetry>, IQuerableReader<PersonTelemetry>
    {
    }
}
