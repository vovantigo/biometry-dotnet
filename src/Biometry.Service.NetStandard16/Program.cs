using System;
using System.Threading;
using Biometry.Service.Run;

namespace Biometry.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var task = (new BiometryProcess()).RunAsync(args, CancellationToken.None);
                task.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
