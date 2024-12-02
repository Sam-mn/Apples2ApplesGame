using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public class BotPlayerBehavior : IPlayerBehavior
    {
        private readonly Random random = new();

        public PlayedApple PlayCard(List<string> hand, int playerId)
        {
            string selectedCard = hand[random.Next(hand.Count)];
            hand.Remove(selectedCard);

            return new PlayedApple(playerId, selectedCard);
        }

        public PlayedApple JudgeCards(List<PlayedApple> submissions)
        {
            // Bot selects the first submission as the winner
            return submissions[random.Next(submissions.Count)];
        }
    }
}
