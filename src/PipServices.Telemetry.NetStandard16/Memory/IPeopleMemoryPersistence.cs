using PipServices.Commons.Config;
using PipServices.Commons.Refer;
using PipServices.Commons.Run;
using PipServices.Data;
using PipServices.Telemetry.Models;

namespace PipServices.Telemetry.Memory
{
    interface IPeopleMemoryPersistence : IReferenceable, IOpenable, ICleanable, IReconfigurable,
        IWriter<Person, string>, IGetter<Person, string>, ISetter<Person>, IQuerableReader<Person>
    {
    }
}
 