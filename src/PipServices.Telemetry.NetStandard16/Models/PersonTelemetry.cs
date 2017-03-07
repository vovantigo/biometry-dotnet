using System;
using PipServices.Commons.Data;

namespace PipServices.Telemetry.Models
{
    public sealed class PersonTelemetry : IStringIdentifiable
    {
        public string Id { get; set; }
        public string PersonId { get; set; }
        public DateTime ReadDataTime { get; set; }
        public double Temperature { get; set; }
        public double HeartRate { get; set; }
        public double BloodOxygen { get; set; }
    }
}
