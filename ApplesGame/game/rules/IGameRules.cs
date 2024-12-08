using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplesGame.playersLogic;

namespace ApplesGame.gameLogic.rules
{
    public interface IGameRules
    {

        // Check if any of players have 
        bool CheckIfGameWon(IEnumerable<Player> players);

        // Check the number of players and return the number of green apples they must keep to win
        int GetWinningScore(int playerCount);
    }
}
