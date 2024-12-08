using ApplesGame;
using System;
using ApplesGame.cards;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Rule3ShuffleGreenAndRedApplesDeck
    {
        [Fact]
        public void Shuffle_Green_Appels_Decks()
        {
            // Arrange
            var deck = new Deck<string>(File.ReadAllLines("./greenApples.txt"));

            // Act
            var beforeShuffle = new List<string>(File.ReadAllLines("./greenApples.txt"));
            deck.Shuffle();
            var afterShuffle = deck.DrawMultiple(deck.getCardsNumber());

            // Assert
            Assert.NotEqual(beforeShuffle, afterShuffle); // Order should be different
            Assert.True(beforeShuffle.OrderBy(x => x).SequenceEqual(afterShuffle.OrderBy(x => x))); // Same items
        }

        [Fact]
        public void Shuffle_Red_Appels_Decks()
        {
            // Arrange
            var deck = new Deck<string>(File.ReadAllLines("./redApples.txt"));

            // Act
            var beforeShuffle = new List<string>(File.ReadAllLines("./redApples.txt"));
            deck.Shuffle();
            var afterShuffle = deck.DrawMultiple(deck.getCardsNumber());

            // Assert
            Assert.NotEqual(beforeShuffle, afterShuffle); // Order should be different
            Assert.True(beforeShuffle.OrderBy(x => x).SequenceEqual(afterShuffle.OrderBy(x => x))); // Same items
        }
    }
}
