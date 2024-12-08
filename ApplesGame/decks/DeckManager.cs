using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame.cards
{
    public class DeckManager : IDeckManager<string>
    {
        public Deck<string> LoadDeck(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            return new Deck<string>(lines);
        }
    }
}
