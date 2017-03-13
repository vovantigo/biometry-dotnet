using System;
using System.Threading;
using People.Service.Run;

namespace People.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var task = (new PeopleProcess()).RunAsync(args, CancellationToken.None);
                task.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
