using Biometry.Common.Models;
using PipServices.Commons.Config;
using PipServices.Commons.Refer;
using PipServices.Commons.Run;
using PipServices.Data;

namespace People.Logic.Memory
{
    interface IPeopleMemoryPersistence : IReferenceable, IOpenable, ICleanable, IReconfigurable,
        IWriter<Person, string>, IGetter<Person, string>, ISetter<Person>, IQuerableReader<Person>
    {
    }
}
 