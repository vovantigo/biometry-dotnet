using Biometry.Common.Models;
using PipServices.Data.Memory;

namespace People.Logic.Memory
{
    public class PeopleMemoryPersistence: IdentifiableMemoryPersistence<Person, string>, IPeopleMemoryPersistence
    {
    }
}
