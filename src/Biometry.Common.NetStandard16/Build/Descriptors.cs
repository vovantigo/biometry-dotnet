using PipServices.Commons.Refer;

namespace Biometry.Common.Build
{
    public static class Descriptors
    {
        private const string Group = "pip-services-biometry";

        public static Descriptor BiometryFactory { get; } = new Descriptor(Group, "factory", "default", "default", "1.0");

        public static Descriptor PeopleMemoryPersistence { get; } = new Descriptor(Group, "persistence", "memory", "people", "1.0");
        public static Descriptor BiometryMemoryPersistence { get; } = new Descriptor(Group, "persistence", "memory", "biometry", "1.0");

        public static Descriptor PeopleController { get; } = new Descriptor(Group, "controller", "default", "people", "1.0");
        public static Descriptor BiometryController { get; } = new Descriptor(Group, "controller", "default", "biometry", "1.0");
        public static Descriptor StatisticController { get; } = new Descriptor(Group, "controller", "default", "statistic", "1.0");

        public static Descriptor PeopleRestService { get; } = new Descriptor(Group, "service", "rest", "people", "1.0");
        public static Descriptor PeopleRestClient { get; } = new Descriptor(Group, "client", "rest", "people", "1.0");
        public static Descriptor PeopleDirectClient { get; } = new Descriptor(Group, "client", "direct", "people", "1.0");

        public static Descriptor BiometryRestService { get; } = new Descriptor(Group, "service", "rest", "biometry", "1.0");
        public static Descriptor BiometryRestClient { get; } = new Descriptor(Group, "client", "rest", "biometry", "1.0");
        public static Descriptor BiometryDirectClient { get; } = new Descriptor(Group, "client", "direct", "biometry", "1.0");
        public static Descriptor BiometryClient { get; } = new Descriptor(Group, "client", "*", "biometry", "*");

        public static Descriptor StatisticRestService { get; } = new Descriptor(Group, "service", "rest", "statistic", "1.0");
        public static Descriptor StatisticRestClient { get; } = new Descriptor(Group, "client", "rest", "statistic", "1.0");
    }
}
