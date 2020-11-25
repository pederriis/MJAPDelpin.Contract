using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MJAPDelpin.Contract.Application.Infrastructure;

namespace MJAPDelpin.Contract.Edge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RabbitLogic logic= new RabbitLogic();
            logic.GetCustomerCreatedFromRabbit();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
