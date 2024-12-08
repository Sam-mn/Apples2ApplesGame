using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplesGame.cards;
using ApplesGame.playersLogic;

namespace ApplesGame.gameLogic
{
    public interface IRoundManager
    { 
        //Get players submissions
        List<PlayedApple> GetSubmissions(List<Player> players, Player judge);

        // Give players new red apples until they have 7 red apples
        void ReplenishHands(List<Player> players, Deck<string> redAppleDeck);
    }
}
