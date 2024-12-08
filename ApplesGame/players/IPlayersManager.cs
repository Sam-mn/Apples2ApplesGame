using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplesGame.cards;

namespace ApplesGame.playersLogic
{
    public interface IPlayersManager
    {
        // Add new human players and bot players 
        public List<Player> AddPlayer();

        // Deal 7 red cards to all players
        public void DealInitialCards(List<Player> players, Deck<string> redAppleDeck);
    }
}
