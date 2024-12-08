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
    public class Rule12PlayersAreGivenNewRedApples
    {
        [Fact]
        public void Players_Are_Given_New_Red_Apples_Until_They_Have_7_Red_Apples()
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

            // Assert
            Assert.True(players[0].Hand.Count == 6);

            // Act
            roundManager.ReplenishHands(players, redApples);

            // Assert
            Assert.True(players[0].Hand.Count == 7);
        }
    }
}
