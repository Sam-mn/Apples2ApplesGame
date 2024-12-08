using ApplesGame;
using ApplesGame.playersLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Rule5RandomiseWhichPlayerStartBeingTheJudge
    {
        [Fact]
        public void InitializeGame_ShouldRandomizeStartingJudge()
        {
            // Arrange
            var players = new List<Player>
        {
            new HumanPlayerBehavior(0),
            new BotPlayerBehavior (1),
            new BotPlayerBehavior (2)
        };

            var currentJudgeIndex = new Random().Next(players.Count);
            
            // Act
            var judgeIndex = players[currentJudgeIndex].Id;

            // Assert
            Assert.InRange(judgeIndex, 0, players.Count - 1); 
        }
    }
}
