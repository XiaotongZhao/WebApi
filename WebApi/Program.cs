using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using System;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Winton.Extensions.Configuration.Consul;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            Log.Information("Starting up");
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, builder) =>
                {
                    var env = hostContext.HostingEnvironment;
                    Console.WriteLine(env.ApplicationName);
                    Console.WriteLine(env.EnvironmentName);
                    builder.AddConsul($"{env.ApplicationName}/appsettings.{env.EnvironmentName}.json",
                        options =>
                        {
                            options.ConsulConfigurationOptions =
                                cco => { cco.Address = new Uri("http://localhost:8500"); };
                            options.Optional = true;
                            options.ReloadOnChange = true;
                            options.OnLoadException = exceptionContext => { exceptionContext.Ignore = true; };
                        });
                    hostContext.Configuration = builder.Build();
                })
                .UseSerilog()
                .UseStartup<Startup>();
    }
}