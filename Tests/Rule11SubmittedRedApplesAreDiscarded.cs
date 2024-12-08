using ApplesGame;
using ApplesGame.playersLogic;
using ApplesGame.gameLogic;
using ApplesGame.cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Rule11SubmittedRedApplesAreDiscarded
    {
        [Fact]
        public void All_Submitted_Red_Apples_Are_Discarded()
        {
            // Arrange
            var redApples = new Deck<string>(File.ReadAllLines("./redApples.txt"));
            var players = new List<Player>();

            // Act
            var playerManager = new PlayersManager(0, 4);
            var roundManager = new RoundManager();
            players.AddRange(playerManager.AddPlayer());
            playerManager.DealInitialCards(players, redApples);

            int judgeIndex = 3;

            // Assert
            Assert.True(players[0].Hand.Count == 7);

            // Act
            var submissions = roundManager.GetSubmissions(players, players[judgeIndex]);

            // Asser
            Assert.True(players[0].Hand.Count == 6);
        }
    }
}
