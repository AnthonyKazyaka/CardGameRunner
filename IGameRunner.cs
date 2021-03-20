using CardGameEngine.Game;

namespace CardGameRunner
{
    public interface IGameRunner
    {
        void Run(ICardGame cardGame);
    }
}
