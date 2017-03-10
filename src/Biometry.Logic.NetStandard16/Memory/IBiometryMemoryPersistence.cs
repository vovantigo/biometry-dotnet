using Biometry.Common.Models;
using PipServices.Commons.Config;
using PipServices.Commons.Refer;
using PipServices.Commons.Run;
using PipServices.Data;

namespace Biometry.Logic.Memory
{
    interface IBiometryMemoryPersistence : IReferenceable, IOpenable, ICleanable, IReconfigurable,
        IWriter<PersonBiometry, string>, IGetter<PersonBiometry, string>, ISetter<PersonBiometry>, IQuerableReader<PersonBiometry>
    {
    }
}
