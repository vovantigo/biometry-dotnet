using Biometry.Common.Models;
using PipServices.Data.Memory;

namespace Biometry.Logic.Memory
{
    public class BiometryMemoryPersistence : IdentifiableMemoryPersistence<PersonBiometry, string>, IBiometryMemoryPersistence
    {
    }
}
