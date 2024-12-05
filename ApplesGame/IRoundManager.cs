using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public interface IRoundManager
    {
        List<PlayedApple> GetSubmissions(List<Player> players, Player judge);
        void ReplenishHands(List<Player> players, Deck<string> redAppleDeck);
    }
}
