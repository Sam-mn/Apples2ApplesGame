using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public interface IDeckManager<T>
    {
        Deck<T> LoadDeck(string filePath);
    }
}
