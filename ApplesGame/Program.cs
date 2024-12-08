using ApplesGame.cards;
using ApplesGame.game;
using ApplesGame.gameLogic;
using ApplesGame.gameLogic.rules;
using ApplesGame.judge;
using ApplesGame.playersLogic;

namespace ApplesGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ErrorMessages.Load("greenApples.txt");
                ErrorMessages.Load("redApples.txt");


                var gameRules = new DefaultGameRules();
                IDeckManager<string> deckManager = new DeckManager();
                IJudgeManager judgeManager = new JudgeManager();
                IRoundManager roundManager = new RoundManager();
                IPlayersManager addPlayersManager = new PlayersManager(1, 3);

                var game = Game.GetInstance(gameRules, deckManager, judgeManager, roundManager, addPlayersManager);
                Client.start(game);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}\n{e.StackTrace}");
            }
        }
    }
}
