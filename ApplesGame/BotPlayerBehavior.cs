using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public class BotPlayerBehavior : Player
    {
        public BotPlayerBehavior(int id) : base(id)
        {
        }

        private readonly Random random = new();


        public override PlayedApple PlayCard()
        {
            string selectedCard = this.Hand[random.Next(this.Hand.Count)];
            this.Hand.Remove(selectedCard);

            return new PlayedApple(this.Id, selectedCard);
        }

        public override PlayedApple JudgeCards(List<PlayedApple> submissions)
        {
            // Bot selects the first submission as the winner
            return submissions[random.Next(submissions.Count)];
        }
    }
}
