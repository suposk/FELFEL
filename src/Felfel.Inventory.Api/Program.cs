using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Felfel.Inventory.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Felfel.Inventory.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run(); 

            var host = CreateHostBuilder(args).Build();

            // migrate the database.  Best practice = in Main, using service scope
            using (var scope = host.Services.CreateScope())
            {
                ILogger<Program> logger = null;
                try
                {
                    logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                }
                catch { }

                try
                {
                    logger?.LogInformation("CreateHostBuilder Started");

                    var context = scope.ServiceProvider.GetService<InventoryContext>();

                    // for demo purposes, delete the database & migrate on startup so we can start with a clean slate                   
                    context.Database.EnsureDeleted(); logger?.LogInformation("Called EnsureDeleted");

                    context.Database.Migrate(); logger?.LogInformation("Called Migrate");
                }
                catch (Exception ex)
                {
                    logger?.LogError(ex, "An error occurred while migrating the database.");
                }
            }

            // run the web app
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
