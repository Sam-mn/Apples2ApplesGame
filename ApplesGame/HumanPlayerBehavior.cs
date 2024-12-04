using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public class HumanPlayerBehavior : Player
    {
        public HumanPlayerBehavior(int id) : base(id)
        {
        }

        public override PlayedApple PlayCard()
        {
            Console.WriteLine($"Player {this.Id}, choose a red apple to play:");
            for (int i = 0; i < this.Hand.Count; i++)
            {
                Console.WriteLine($"[{i}] {this.Hand[i]}");
            }

            int choice;
            while (true)
            {
                try
                {
                    Console.Write("Enter your choice: ");
                    var input = Console.ReadLine();

                    // Check if input is numeric
                    if (!int.TryParse(input, out choice))
                        throw new ArgumentException(ErrorMessages.Get("InvalidInput"));

                    // Check if input is in range
                    if (choice < 0 || choice >= this.Hand.Count)
                        throw new ArgumentOutOfRangeException(ErrorMessages.Get("OutOfRange"));

                    break; // Valid input, exit loop
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            var selectedCard = this.Hand[choice];
            this.Hand.RemoveAt(choice);

            return new PlayedApple(this.Id, selectedCard);
        }

        public override PlayedApple JudgeCards(List<PlayedApple> submissions)
        {
            Console.WriteLine("Judge, select the winning red apple:");
            for (int i = 0; i < submissions.Count; i++)
            {
                Console.WriteLine($"[{i}] {submissions[i].RedApple}");
            }

            int choice;
            while (true)
            {
                try
                {
                    Console.Write("Enter your choice: ");
                    var input = Console.ReadLine();

                    // Check if input is numeric
                    if (!int.TryParse(input, out choice))
                        throw new ArgumentException(ErrorMessages.Get("InvalidInput"));

                    // Check if input is in range (judge has max 2 options)
                    if (choice < 0 || choice >= submissions.Count)
                        throw new ArgumentOutOfRangeException(ErrorMessages.Get("OutOfRange"));

                    break; // Valid input, exit loop
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return submissions[choice];
        }

    }

}
