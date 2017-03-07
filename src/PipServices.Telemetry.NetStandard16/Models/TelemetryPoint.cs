using System;

namespace PipServices.Telemetry.Models
{
    public sealed class TelemetryPoint
    {
        public DateTime ReadDataTime { get; set; }
        public double Value { get; set; }
    }
}
