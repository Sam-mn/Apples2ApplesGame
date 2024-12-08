using ApplesGame;
using ApplesGame.playersLogic;
using ApplesGame.cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Rule4DealSevenRedApples
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

            // Act
            var redAppleDeck = new Deck<string>(redAppleCards);

            foreach (var player in players)
            {
                player.DrawCards(redAppleDeck.DrawMultiple(7));
            }

            // Assert
            foreach (var player in players)
            {
                Assert.Equal(7, player.Hand.Count);
            }
        }
    }

}
