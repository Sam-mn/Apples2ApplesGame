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
    public class Rule8RandomiseTheSubmissions
    {
        [Fact]
        public void Printed_Order_Of_The_Played_Red_Apples_Should_Be_Randomised()
        {
            // Arrange
            var redApples = new Deck<string>(File.ReadAllLines("./redApples.txt"));
            var players = new List<Player>();

            // Act
            var playerManager = new PlayersManager(1, 3);
            var roundManager = new RoundManager();
            players.AddRange(playerManager.AddPlayer());
            playerManager.DealInitialCards(players, redApples);

            int judgeIndex = 3;

            var submissions1 = roundManager.GetSubmissions(players, players[judgeIndex]);
            var submissions2 = roundManager.GetSubmissions(players, players[judgeIndex]);

            // Assert
            Assert.NotEqual(submissions1, submissions2);
        }
    }
}
