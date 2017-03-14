using System;
using PipServices.Commons.Build;
using PipServices.Commons.Refer;
using Biometry.Common.Build;
using HealthDashboard.Logic.Logic;
using Biometry.Client.Clients;
using HealthDashboard.Service.Service;

namespace HealthDashboard.Service.Build
{
    public class HealthDashboardFactory: IFactory
    {
        private static readonly Lazy<BiometryRestClient> BiometryClient = new Lazy<BiometryRestClient>();

        public object CanCreate(object locater)
        {
            var descriptor = locater as Descriptor;

            if (descriptor != null)
            {
                if (descriptor.Equals(Descriptors.HealthDashboardController))
                    return true;
                if (descriptor.Equals(Descriptors.BiometryRestClient))
                    return true;
                if (descriptor.Equals(Descriptors.BiometryDirectClient))
                    return true;
                if (descriptor.Equals(Descriptors.HealthDashboardRestService))
                    return true;
            }

            return null;
        }

        public object Create(object locater)
        {
            var descriptor = locater as Descriptor;

            if (descriptor != null)
            {
                if (descriptor.Equals(Descriptors.HealthDashboardController))
                    return new HealthDashboardController();
                if (descriptor.Equals(Descriptors.BiometryRestClient))
                    return BiometryClient.Value;
                if (descriptor.Equals(Descriptors.BiometryDirectClient))
                    return new BiometryDirectClient();
                if (descriptor.Equals(Descriptors.HealthDashboardRestService))
                    return new StatisticRestService();
            }

            return null;
        }

        public static object Create(Descriptor descriptor)
        {
            var factory = new HealthDashboardFactory();
            return factory.Create((object)descriptor);
        }
    }
}
