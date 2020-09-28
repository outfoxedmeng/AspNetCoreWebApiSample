using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSample.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ApiSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scop = host.Services.CreateScope())
            {
                try
                {
                    var db = scop.ServiceProvider.GetService<MyDbContext>();
                    //db.Database.EnsureDeleted();
                    //db.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    var logger = scop.ServiceProvider.GetService<ILogger<Program>>();

                    logger.LogError(ex, ex.Message);
                }

            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
