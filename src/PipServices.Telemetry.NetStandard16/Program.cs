using System;
using System.Threading;
using PipServices.Telemetry.Run;

namespace PipServices.Telemetry
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var task = (new TelemetryProcess()).RunAsync(args, CancellationToken.None);
                task.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
