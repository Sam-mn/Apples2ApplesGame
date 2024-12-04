using ApplesGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class DealSevenRedApplesTest
    {
        [Fact]
        public void Deals_Seven_Cards_To_Each_Player()
        {
            // Arrange
            var players = new List<Player>
        {
            new HumanPlayerBehavior (0),
            new BotPlayerBehavior (1), 
            new BotPlayerBehavior (2)
        };

            var redAppleCards = new List<string>(File.ReadAllLines("./redApples.txt"));

            var redAppleDeck = Deck<string>.GetDeckInstance(redAppleCards);

            foreach (var player in players)
            {
                player.DrawCards(redAppleDeck.DrawMultiple(7));
            }

            // Assert
            foreach (var player in players)
            {
                Assert.Equal(7, player.Hand.Count); // Each player should have exactly 7 cards
            }
        }
    }

}
