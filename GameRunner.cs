using CardGameEngine.Decks;
using CardGameEngine.Game;

namespace CardGameRunner
{
    public class GameRunner : IGameRunner
    {
        private readonly IDeckFactory _deckFactory;

        public GameRunner(IDeckFactory deckFactory)
        {
            _deckFactory = deckFactory;
        }

        public void Run(ICardGame cardGame)
        {
            cardGame.Play();
        }
    }
}
