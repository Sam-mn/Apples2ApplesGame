using ApplesGame;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class DefaultGameRulesTest
    {
        [Fact]
        public void CheckIfGameWon_NoPlayerHasWinningScore_ReturnsFalse()
        {
            // Arrange
            var rules = new DefaultGameRules();
            var players = new List<Player>
        {
            CreateMockPlayer(1, 2), // Player with 2 points
            CreateMockPlayer(2, 3)  // Player with 3 points
        };

            // Act
            bool result = rules.CheckIfGameWon(players);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckIfGameWon_PlayerReachesWinningScore_ReturnsTrue()
        {
            // Arrange
            var rules = new DefaultGameRules();
            var players = new List<Player>
        {
            CreateMockPlayer(1, 8), // Player with 8 points (winning score for 4 players)
            CreateMockPlayer(2, 3)
        };

            // Act
            bool result = rules.CheckIfGameWon(players);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckIfGameWon_PlayerExceedsWinningScore_ReturnsTrue()
        {
            // Arrange
            var rules = new DefaultGameRules();
            var players = new List<Player>
        {
            CreateMockPlayer(1, 9), // Player with 9 points (exceeds winning score for 4 players)
            CreateMockPlayer(2, 3)
        };

            // Act
            bool result = rules.CheckIfGameWon(players);

            // Assert
            Assert.True(result);
        }

        // Helper method to create a mock Player object
        private Player CreateMockPlayer(int id, int score)
        {
            var mockPlayer = new Mock<HumanPlayerBehavior>(id); // Mocked Player object
            mockPlayer.Setup(p => p.Score).Returns(score); // Simulate the player's score
            return mockPlayer.Object;
        }
    }
}
