using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public class DefaultGameRules : IGameRules
    {
        public bool CheckIfGameWon(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                if (player.Score >= GetWinningScore(players.Count()))
                {
                    return true;
                }
            }
            return false;
        }

        public int GetWinningScore(int playerCount)
        {
            return playerCount switch
            {
                4 => 8,
                5 => 7,
                6 => 6,
                7 => 5,
                _ => 4,
            };
        }
    }
}
