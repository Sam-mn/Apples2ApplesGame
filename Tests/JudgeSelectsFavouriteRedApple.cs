using ApplesGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class JudgeSelectsFavouriteRedApple
    {
        [Fact]
        public void Judge_Selects_Favourite_Red_Apple()
        {
            var redApples = new Deck<string>(File.ReadAllLines("./redApples.txt"));
            var greenApples = new Deck<string>(File.ReadAllLines("./redApples.txt"));

            var players = new List<Player>();

            var playerManager = new PlayersManager(0, 4);
            var roundManager = new RoundManager();
            players.AddRange(playerManager.AddPlayer());
            playerManager.DealInitialCards(players, redApples);

            int judgeIndex = 3;

            var submissions = roundManager.GetSubmissions(players, players[judgeIndex]);

            var judgeCommand = new JudgeCardsCommand(players[judgeIndex], submissions, winner =>
            {
                players[winner.PlayerId].AddPoint(greenApples.Draw());
            });
            judgeCommand.Execute();
            var winner = judgeCommand.GetWinner();

            Assert.NotNull(winner);

        }

        [Fact]
        public void Player_Rewarded_The_Green_Apple_As_Point()
        {
            var redApples = new Deck<string>(File.ReadAllLines("./redApples.txt"));
            var greenApples = new Deck<string>(File.ReadAllLines("./redApples.txt"));

            var players = new List<Player>();

            var playerManager = new PlayersManager(0, 4);
            var roundManager = new RoundManager();
            players.AddRange(playerManager.AddPlayer());
            playerManager.DealInitialCards(players, redApples);

            int judgeIndex = 3;

            var submissions = roundManager.GetSubmissions(players, players[judgeIndex]);

            int winnerId = 0;
            var judgeCommand = new JudgeCardsCommand(players[judgeIndex], submissions, winner =>
            {
                players[winner.PlayerId].AddPoint(greenApples.Draw());
                winnerId = winner.PlayerId;
            });
            judgeCommand.Execute();

            int WinnerGreenApples = players[winnerId].GreenApples.Count;

            Assert.Equal(WinnerGreenApples, 1);

        }
    }
}
