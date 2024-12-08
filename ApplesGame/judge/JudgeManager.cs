using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplesGame.playersLogic;

namespace ApplesGame.judge
{
    public class JudgeManager : IJudgeManager
    {
        protected readonly Random random = new();

        public PlayedApple JudgeSubmissions(Player judge, List<PlayedApple> submissions)
        {
            Console.WriteLine("\nSubmissions:");
            for (int i = 0; i < submissions.Count; i++)
            {
                Console.WriteLine($"[{i}] {submissions[i].RedApple}");
            }

            return judge.JudgeCards(submissions);
        }
        public int RandomizeJudge(List<Player> players) => random.Next(players.Count);
        public Player GetCurrentJudge(List<Player> players, int currentJudgeIndex) => players[currentJudgeIndex];
        public int RotateJudge(List<Player> players, int currentJudgeIndex) => (currentJudgeIndex + 1) % players.Count;
    }
}
