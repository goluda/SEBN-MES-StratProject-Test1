using System;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            for (var i = 0; i < 10; i++)
            {
                var dzis = DateTime.Now;
                System.Console.WriteLine($"{dzis.Month} {dzis.Year} ....");
                System.Console.WriteLine(dzis.ToString("- dd-MM HH:mm:ss"));
                await Task.Delay(1200);
            }
        }
    }
}
