using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public class Deck<T> : IDeck<T>
    {
        private readonly List<T> cards;
        private readonly Random random = new();

        public int getCardsNumber()
        {
            return cards.Count;
        }

        public Deck(IEnumerable<T> items)
        {
            cards = new List<T>(items);
            Shuffle();
        }

        public void Shuffle()
        {
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int index = random.Next(i + 1);
                (cards[i], cards[index]) = (cards[index], cards[i]);
            }
        }

        public T Draw()
        {
            if (cards.Count == 0) throw new InvalidOperationException("Deck is empty.");
            var card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public List<T> DrawMultiple(int count)
        {
            if (count > cards.Count) throw new InvalidOperationException("Not enough cards in the deck.");
            var drawnCards = cards.Take(count).ToList();
            cards.RemoveRange(0, count);
            return drawnCards;
        }
    }
}
