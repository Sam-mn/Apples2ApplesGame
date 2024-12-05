using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public class JudgeCardsCommand : ICommand
    {
        private readonly Player judge;
        private readonly List<PlayedApple> submissions;
        private readonly Action<PlayedApple> onJudgment;
        private int? winnerPlayerId = null;


        public JudgeCardsCommand(Player judge, List<PlayedApple> submissions, Action<PlayedApple> onJudgment)
        {
            this.judge = judge;
            this.submissions = submissions;
            this.onJudgment = onJudgment;
        }

        public void Execute()
        {
            var winner = judge.JudgeCards(submissions);
            onJudgment(winner);
            winnerPlayerId = winner.PlayerId;
            Console.WriteLine($"\nJudge Player {judge.Id} selected Player {winner.PlayerId}'s card as the winner.\n");
        }

        public int? GetWinner()
        {
            if (winnerPlayerId == null) return null;
            return winnerPlayerId;
        }
    }

}
