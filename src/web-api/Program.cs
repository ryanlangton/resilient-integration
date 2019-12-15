using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                    .ConfigureServices(services => services.AddAutofac())
                    .UseStartup<Startup>()
                    .UseSerilog((hostingContext, loggerConfiguration) =>
                        loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));
    }
}
