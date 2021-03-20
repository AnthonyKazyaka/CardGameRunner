using CardGameEngine.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quaranta;

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

            QuarantaGame quaranta = new QuarantaGame();

            gameRunner.Run(quaranta);

            serviceProvider.Dispose();
        }

        static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.ConfigureCardGameEngineDependencies();
            serviceCollection.AddTransient<IGameRunner, GameRunner>();
        }
    }
}
