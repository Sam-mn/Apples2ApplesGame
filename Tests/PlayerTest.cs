using ApplesGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class PlayerTest
    {
        private static IPlayerBehavior GetPrivateBehavior(Player player)
        {
            var behaviorField = typeof(Player).GetField("behavior", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return (IPlayerBehavior)behaviorField.GetValue(player);
        }

        [Fact]
        public void TestPlayerIsNotNull()
        {
            var player = PlayerFactory.CreatePlayer(0, isBot: false);
            Assert.NotNull(player);
        }

        [Fact]
        public void Test_Add_New_Humman_Player()
        {
            // Arrange
            int playerId = 0;
            bool isBot = false;

            // Act
            var player = PlayerFactory.CreatePlayer(playerId, isBot);

            // Assert
            Assert.NotNull(player); // Player should not be null
            Assert.Equal(playerId, player.Id); // Player ID should match
            Assert.IsType<HumanPlayerBehavior>(GetPrivateBehavior(player));
        }

        [Fact]
        public void Test_Add_New_Bot_Player()
        {
            // Arrange
            int playerId = 0;
            bool isBot = true;

            // Act
            var player = PlayerFactory.CreatePlayer(playerId, isBot);

            // Assert
            Assert.NotNull(player); // Player should not be null
            Assert.Equal(playerId, player.Id); // Player ID should match
            Assert.IsType<BotPlayerBehavior>(GetPrivateBehavior(player));
        }
    }
}
