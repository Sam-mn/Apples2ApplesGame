using ApplesGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TheNextPlayerInTheListBecomesTheJudge
    {
        [Fact]
        public void The_Next_Player_In_The_List_Becomes_The_Judge()
        {
            var redApples = new Deck<string>(File.ReadAllLines("./redApples.txt"));
            var greenApples = new Deck<string>(File.ReadAllLines("./redApples.txt"));

            var players = new List<Player>();

            var playerManager = new PlayersManager(0, 4);
            var roundManager = new RoundManager();
            var judgeManager = new JudgeManager();
            players.AddRange(playerManager.AddPlayer());
            playerManager.DealInitialCards(players, redApples);

            int judgeIndex = 0;

            var submissions = roundManager.GetSubmissions(players, players[judgeIndex]);

            int winnerId = 0;
            var judgeCommand = new JudgeCardsCommand(players[judgeIndex], submissions, winner =>
            {
                players[winner.PlayerId].AddPoint(greenApples.Draw());
                winnerId = winner.PlayerId;
            });
            judgeCommand.Execute();

            judgeIndex = judgeManager.RotateJudge(players, judgeIndex);

            Assert.Equal(judgeIndex, 1);
        }
    }
}
