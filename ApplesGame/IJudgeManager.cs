using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public interface IJudgeManager
    {
        PlayedApple JudgeSubmissions(Player judge, List<PlayedApple> submissions);
        public int RandomizeJudge(List<Player> players);
        public Player GetCurrentJudge(List<Player> players, int currentJudgeIndex);
        public int RotateJudge(List<Player> players, int currentJudgeIndex);
    }
}
