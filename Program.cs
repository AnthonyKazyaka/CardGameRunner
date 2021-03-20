using CardGameEngine.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace CardGameRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new ServiceCollection();

            ConfigureServices(collection);

            var serviceProvider = collection.BuildServiceProvider();

            var gameRunner = serviceProvider.GetService<IGameRunner>();
            gameRunner.Run();

            serviceProvider.Dispose();
        }

        static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.ConfigureCardGameEngineDependencies();
            serviceCollection.AddTransient<IGameRunner, GameRunner>(); // Does this belong?
        }
    }
}
