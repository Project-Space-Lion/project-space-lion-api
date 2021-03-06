using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Space.Lion.Data;
//using Microsoft.OpenApi.Writers;


namespace Space.Lion.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            	var host = CreateHostBuilder(args).Build();
                CreateDbIfNotExists(host);
                host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scopre = host.Services.CreateScope())
            {
                var services = scopre.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                try
                {
                    var context = services.GetRequiredService<StoreContext>();
                    context.Database.EnsureCreated();
                    DbInitializer.Initialize(context, logger);
                }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Error occured creating the database.");
                    }
            }
        }
    }
}
