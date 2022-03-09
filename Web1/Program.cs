using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web1.Data;
using Web1.Models;

namespace Web1
{
    public class Program
    {
        public static void Main(string[] args)
        {


        Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.Debug().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();

            //CreateHostBuilder(args).Build().Run() ;
            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            host.Run();
           
         
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }
                
                
                ).UseSerilog();
       
        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DataContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }
    }
}
