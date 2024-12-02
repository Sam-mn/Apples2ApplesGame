using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public static class GetRandomeJudge
    {
        public static Player getRandomPlayerAsJudge(List<Player> players, int currentJudgeIndex)
        {
            return players[currentJudgeIndex];
        }
    }
}
