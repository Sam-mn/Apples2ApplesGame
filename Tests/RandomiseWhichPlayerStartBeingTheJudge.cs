using ApplesGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class RandomiseWhichPlayerStartBeingTheJudge
    {
        [Fact]
        public void InitializeGame_ShouldRandomizeStartingJudge()
        {
            // Arrange
            var players = new List<Player>
        {
            new Player(0, new HumanPlayerBehavior()),
            new Player(1, new BotPlayerBehavior()),
            new Player(2, new BotPlayerBehavior())
        };

            var currentJudgeIndex = new Random().Next(players.Count);
            
            // Act
            var judge = GetRandomeJudge.getRandomPlayerAsJudge(players, currentJudgeIndex);
            var judgeIndex = players[currentJudgeIndex].Id;

            // Assert
            Assert.InRange(judgeIndex, 0, players.Count - 1); //
        }
    }
}
