using System;
using System.Threading;
using HealthDashboard.Service.Run;

namespace HealthDashboard.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var task = (new HealthDashboardProcess()).RunAsync(args, CancellationToken.None);
                task.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
