using System;
using PipServices.Commons.Build;
using PipServices.Commons.Refer;
using Biometry.Common.Build;
using Biometry.Logic.Memory;
using Biometry.Logic.Logic;
using Biometry.Service.Services;

namespace Biometry.Service.Build
{
    public class BiometryFactory: IFactory
    {
        private static readonly Lazy<BiometryMemoryPersistence> BiometryPersistance = new Lazy<BiometryMemoryPersistence>();

        public object CanCreate(object locater)
        {
            var descriptor = locater as Descriptor;

            if (descriptor != null)
            {
                if (descriptor.Equals(Descriptors.BiometryMemoryPersistence))
                    return true;
                if (descriptor.Equals(Descriptors.BiometryController))
                    return true;
                if (descriptor.Equals(Descriptors.BiometryRestService))
                    return true;
            }

            return null;
        }

        public object Create(object locater)
        {
            var descriptor = locater as Descriptor;

            if (descriptor != null)
            {
                if (descriptor.Equals(Descriptors.BiometryMemoryPersistence))
                    return BiometryPersistance.Value;
                if (descriptor.Equals(Descriptors.BiometryController))
                    return new BiometryController();
                if (descriptor.Equals(Descriptors.BiometryRestService))
                    return new BiometryRestService();
            }

            return null;
        }

        public static object Create(Descriptor descriptor)
        {
            var factory = new BiometryFactory();
            return factory.Create((object)descriptor);
        }
    }
}
