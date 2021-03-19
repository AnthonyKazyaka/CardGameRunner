using CardGameEngine.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace CardGameRunner
{
    class Program
    {
        static Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            return host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    ConfigureServices(services));

        static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.ConfigureCardGameEngineDependencies();
        }
    }
}
