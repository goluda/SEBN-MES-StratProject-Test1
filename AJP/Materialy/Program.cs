using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Materialy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // TestDB();
            CreateHostBuilder(args).Build().Run();
        }



        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void TestDB()
        {
            using (var db = new MyContext())
            {
                System.Console.WriteLine("Materialy:");
                foreach (var m in db.Material)
                {
                    System.Console.WriteLine($" - {m.MaterialNo} {m.Name}");
                }
                System.Console.WriteLine("Routingi:");
                foreach (var m in db.Routing)
                {
                    System.Console.WriteLine($" - {m.MaterialNo} {m.Description}");
                }
                System.Console.WriteLine("Bomy:");
                foreach (var m in db.Bom)
                {
                    System.Console.WriteLine($" - {m.MaterialNo} {m.ComponentNo}");
                }
            }
        }
    }
}
