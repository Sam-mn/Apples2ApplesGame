using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public interface IPlayersManager
    {
        public List<Player> AddPlayer();
        public void DealInitialCards(List<Player> players, Deck<string> redAppleDeck);
    }
}
