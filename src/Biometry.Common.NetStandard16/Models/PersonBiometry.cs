using System;
using PipServices.Commons.Data;

namespace Biometry.Common.Models
{
    public sealed class PersonBiometry : IStringIdentifiable
    {
        public string Id { get; set; }
        public string PersonId { get; set; }
        public DateTime ReadDataTime { get; set; }
        public double Temperature { get; set; }
        public double HeartRate { get; set; }
        public double BloodOxygen { get; set; }
    }
}
