using System;

namespace Biometry.Common.Models
{
    public sealed class BiometryPoint
    {
        public DateTime ReadDataTime { get; set; }
        public double Value { get; set; }
    }
}
