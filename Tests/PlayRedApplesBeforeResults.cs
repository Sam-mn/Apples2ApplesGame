using ApplesGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class PlayRedApplesBeforeResults
    {
        public void All_Players_Must_Play_Their_Red_Apples_Before_The_Results_Are_Shown()
        {
            var redApples = new Deck<string>(File.ReadAllLines("./redApples.txt"));
            var players = new List<Player>();

            var playerManager = new PlayersManager(0, 4);
            var roundManager = new RoundManager();
            players.AddRange(playerManager.AddPlayer());
            playerManager.DealInitialCards(players, redApples);

            int judgeIndex = 3;

            var submissions = roundManager.GetSubmissions(players, players[judgeIndex]);

            var revealCommand = new RevealSubmissionsCommand(submissions);
            revealCommand.Execute();

        }
    }
}
