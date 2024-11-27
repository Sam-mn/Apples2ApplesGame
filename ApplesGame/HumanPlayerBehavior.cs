using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    internal class HumanPlayerBehavior : IPlayerBehavior
    {
        public PlayedApple PlayCard(List<string> hand, int playerId)
        {
            Console.WriteLine($"Player {playerId}, choose a red apple to play:");
            for (int i = 0; i < hand.Count; i++)
            {
                Console.WriteLine($"[{i}] {hand[i]}");
            }

            int choice = int.Parse(Console.ReadLine());
            string selectedCard = hand[choice];
            hand.RemoveAt(choice);

            return new PlayedApple(playerId, selectedCard);
        }

        public PlayedApple JudgeCards(List<PlayedApple> submissions)
        {
            Console.WriteLine("Judge, select the winning red apple");

            int choice = int.Parse(Console.ReadLine());
            return submissions[choice];
        }
    }
}
