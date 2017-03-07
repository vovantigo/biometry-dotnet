using PipServices.Data.Memory;
using PipServices.Telemetry.Models;

namespace PipServices.Telemetry.Memory
{
    public class PeopleMemoryPersistence: IdentifiableMemoryPersistence<Person, string>, IPeopleMemoryPersistence
    {
    }
}
