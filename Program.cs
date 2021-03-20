using CardGameEngine.Cards;
using CardGameEngine.Configuration;
using CardGameEngine.Game;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quaranta;
using Quaranta.Cards;
using Quaranta.Configuration;

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
            var quarantaGame = serviceProvider.GetService<ICardGame>();

            gameRunner.Run(quarantaGame);

            serviceProvider.Dispose();
        }

        static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.ConfigureQuarantaServices();
            serviceCollection.AddTransient<IGameRunner, GameRunner>();
            serviceCollection.AddTransient<ICardGame, QuarantaGame>();
            serviceCollection.AddTransient<IPointEvaluator, PointEvaluator>();

        }
    }
}
