using System;
using PipServices.Commons.Build;
using PipServices.Commons.Refer;
using PipServices.Telemetry.Clients;
using PipServices.Telemetry.Logic;
using PipServices.Telemetry.Memory;
using PipServices.Telemetry.Services;

namespace PipServices.Telemetry.Build
{
    public class TelemetryFactory: IFactory
    {
        private static readonly Lazy<PeopleMemoryPersistence> PeoplePersistance = new Lazy<PeopleMemoryPersistence>();
        private static readonly Lazy<TelemetryMemoryPersistence> TelemetryPersistance = new Lazy<TelemetryMemoryPersistence>();

        public object CanCreate(object locater)
        {
            var descriptor = locater as Descriptor;

            if (descriptor != null)
            {
                if (descriptor.Equals(Descriptors.PeopleMemoryPersistence))
                    return true;
                if (descriptor.Equals(Descriptors.TelemetryMemoryPersistence))
                    return true;

                if (descriptor.Equals(Descriptors.PeopleController))
                    return true;
                if (descriptor.Equals(Descriptors.TelemetryController))
                    return true;
                if (descriptor.Equals(Descriptors.StatisticController))
                    return true;

                if (descriptor.Equals(Descriptors.PeopleRestService))
                    return true;
                if (descriptor.Equals(Descriptors.PeopleRestClient))
                    return true;
                if (descriptor.Equals(Descriptors.PeopleDirectClient))
                    return true;

                if (descriptor.Equals(Descriptors.TelemetryRestService))
                    return true;
                if (descriptor.Equals(Descriptors.TelemetryRestClient))
                    return true;
                if (descriptor.Equals(Descriptors.TelemetryDirectClient))
                    return true;

                if (descriptor.Equals(Descriptors.StatisticRestService))
                    return true;
                if (descriptor.Equals(Descriptors.StatisticRestClient))
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
                if (descriptor.Equals(Descriptors.TelemetryMemoryPersistence))
                    return TelemetryPersistance.Value;

                if (descriptor.Equals(Descriptors.PeopleController))
                    return new PeopleController();
                if (descriptor.Equals(Descriptors.TelemetryController))
                    return new TelemetryController();
                if (descriptor.Equals(Descriptors.StatisticController))
                    return new StatisticController();

                if (descriptor.Equals(Descriptors.PeopleRestService))
                    return new PeopleRestService();
                if (descriptor.Equals(Descriptors.PeopleRestClient))
                    return new PeopleRestClient();
                if (descriptor.Equals(Descriptors.PeopleDirectClient))
                    return new PeopleDirectClient();

                if (descriptor.Equals(Descriptors.TelemetryRestService))
                    return new TelemetryRestService();
                if (descriptor.Equals(Descriptors.TelemetryRestClient))
                    return new TelemetryRestClient();
                if (descriptor.Equals(Descriptors.TelemetryDirectClient))
                    return new TelemetryDirectClient();

                if (descriptor.Equals(Descriptors.StatisticRestService))
                    return new StatisticRestService();
                if (descriptor.Equals(Descriptors.StatisticRestClient))
                    return new StatisticRestClient();
            }

            return null;
        }
    }
}
