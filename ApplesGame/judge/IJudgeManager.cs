using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplesGame.playersLogic;

namespace ApplesGame.judge
{
    public interface IJudgeManager
    {
        // Chose the winner player by choose a random card if the player is bot or submit the number or the card if the player is humman.
        PlayedApple JudgeSubmissions(Player judge, List<PlayedApple> submissions);

        // Get the judge index by getting a random number between the first player index and the last player index
        public int RandomizeJudge(List<Player> players);

        // Get the player who is the judge in this round
        public Player GetCurrentJudge(List<Player> players, int currentJudgeIndex);

        // Get the next player index to judge
        public int RotateJudge(List<Player> players, int currentJudgeIndex);
    }
}
