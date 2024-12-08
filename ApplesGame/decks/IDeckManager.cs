using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame.cards
{
    public interface IDeckManager<T>
    {
        // Read all lines from text file and return it as a Deck list
        Deck<T> LoadDeck(string filePath);
    }
}
