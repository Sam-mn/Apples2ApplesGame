using ApplesGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class PlayersAreGivenNewRedApples
    {
        [Fact]
        public void Players_Are_Given_New_Red_Apples_Until_They_Have_7_Red_Apples()
        {
            var redApples = new Deck<string>(File.ReadAllLines("./redApples.txt"));
            var players = new List<Player>();

            var playerManager = new PlayersManager(0, 4);
            var roundManager = new RoundManager();
            players.AddRange(playerManager.AddPlayer());
            playerManager.DealInitialCards(players, redApples);

            int judgeIndex = 3;

            Assert.True(players[0].Hand.Count == 7);
            var submissions = roundManager.GetSubmissions(players, players[judgeIndex]);
            Assert.True(players[0].Hand.Count == 6);

            roundManager.ReplenishHands(players, redApples);
            Assert.True(players[0].Hand.Count == 7);
        }
    }
}
