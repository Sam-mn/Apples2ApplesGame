using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public interface IGameRules
    {
        bool CheckIfGameWon(IEnumerable<Player> players);
        int GetWinningScore(int playerCount);
    }
}
