using PipServices.Commons.Refer;

namespace PipServices.Telemetry.Build
{
    public static class Descriptors
    {
        private const string Group = "pip-services-telemetry";

        public static Descriptor TelemetryFactory { get; } = new Descriptor(Group, "factory", "default", "default", "1.0");

        public static Descriptor PeopleMemoryPersistence { get; } = new Descriptor(Group, "persistence", "memory", "people", "1.0");
        public static Descriptor TelemetryMemoryPersistence { get; } = new Descriptor(Group, "persistence", "memory", "telemetry", "1.0");

        public static Descriptor PeopleController { get; } = new Descriptor(Group, "controller", "default", "people", "1.0");
        public static Descriptor TelemetryController { get; } = new Descriptor(Group, "controller", "default", "telemetry", "1.0");
        public static Descriptor StatisticController { get; } = new Descriptor(Group, "controller", "default", "statistic", "1.0");

        public static Descriptor PeopleRestService { get; } = new Descriptor(Group, "service", "rest", "people", "1.0");
        public static Descriptor PeopleRestClient { get; } = new Descriptor(Group, "client", "rest", "people", "1.0");
        public static Descriptor PeopleDirectClient { get; } = new Descriptor(Group, "client", "direct", "people", "1.0");

        public static Descriptor TelemetryRestService { get; } = new Descriptor(Group, "service", "rest", "telemetry", "1.0");
        public static Descriptor TelemetryRestClient { get; } = new Descriptor(Group, "client", "rest", "telemetry", "1.0");
        public static Descriptor TelemetryDirectClient { get; } = new Descriptor(Group, "client", "direct", "telemetry", "1.0");
        public static Descriptor TelemetryClient { get; } = new Descriptor(Group, "client", "*", "telemetry", "*");

        public static Descriptor StatisticRestService { get; } = new Descriptor(Group, "service", "rest", "statistic", "1.0");
        public static Descriptor StatisticRestClient { get; } = new Descriptor(Group, "client", "rest", "statistic", "1.0");
    }
}
