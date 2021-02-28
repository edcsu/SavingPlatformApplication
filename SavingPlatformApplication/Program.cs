using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SavingPlatformApplication.Data;
using SavingPlatformApplication.Data.DatabaseInitializer;
using Serilog;
using Serilog.Events;

namespace SavingPlatformApplication
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("Logs\\contosographqlapi.txt", rollingInterval: RollingInterval.Hour)
                .WriteTo.File("Logs\\contosographqlapi.json", rollingInterval: RollingInterval.Hour)
                .CreateLogger();

            var host = CreateWebHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                Log.Information("Starting Demo Contoso Graphql API");
                var context = services.GetRequiredService<ApplicationDbContext>();

                await DatabaseInitializer.SeedAsync(context);

                host.Run();

                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Saving platform failed to start. Host terminated unexpectedly, {0} - {1} \n {2}", ex.Message, ex.InnerException, ex.Data);

                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog();
    }
}
