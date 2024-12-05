using ApplesGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class RandomiseTheSubmissions
    {
        [Fact]
        public void Printed_Order_Of_The_Played_Red_Apples_Should_Be_Randomised()
        {
            var redApples = new Deck<string>(File.ReadAllLines("./redApples.txt"));
            var players = new List<Player>();

            var playerManager = new PlayersManager(1, 3);
            var roundManager = new RoundManager();
            players.AddRange(playerManager.AddPlayer());
            playerManager.DealInitialCards(players, redApples);

            int judgeIndex = 3;

            var submissions1 = roundManager.GetSubmissions(players, players[judgeIndex]);
            var submissions2 = roundManager.GetSubmissions(players, players[judgeIndex]);

            Assert.NotEqual(submissions1, submissions2);

        }
    }
}
