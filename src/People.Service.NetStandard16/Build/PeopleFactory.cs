using System;
using PipServices.Commons.Build;
using PipServices.Commons.Refer;
using Biometry.Common.Build;
using People.Logic.Memory;
using People.Logic.Logic;
using People.Service.Service;

namespace People.Service.Build
{
    public class PeopleFactory: IFactory
    {
        private static readonly Lazy<PeopleMemoryPersistence> PeoplePersistance = new Lazy<PeopleMemoryPersistence>();

        public object CanCreate(object locater)
        {
            var descriptor = locater as Descriptor;

            if (descriptor != null)
            {
                if (descriptor.Equals(Descriptors.PeopleMemoryPersistence))
                    return true;
                if (descriptor.Equals(Descriptors.PeopleController))
                    return true;
                if (descriptor.Equals(Descriptors.PeopleRestService))
                    return true;
            }

            return null;
        }

        public object Create(object locater)
        {
            var descriptor = locater as Descriptor;

            if (descriptor != null)
            {
                if (descriptor.Equals(Descriptors.PeopleMemoryPersistence))
                    return PeoplePersistance.Value;
                if (descriptor.Equals(Descriptors.PeopleController))
                    return new PeopleController();
                if (descriptor.Equals(Descriptors.PeopleRestService))
                    return new PeopleRestService();
            }

            return null;
        }

        public static object Create(Descriptor descriptor)
        {
            var factory = new PeopleFactory();
            return factory.Create((object)descriptor);
        }
    }
}
