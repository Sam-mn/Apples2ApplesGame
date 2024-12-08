using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplesGame.playersLogic;

namespace ApplesGame.commands
{
    public class RevealSubmissionsCommand : ICommand
    {
        private readonly List<PlayedApple> submissions;

        public RevealSubmissionsCommand(List<PlayedApple> submissions)
        {
            this.submissions = submissions;
        }

        public void Execute()
        {
            var randomizedSubmissions = submissions.OrderBy(_ => Guid.NewGuid()).ToList();
            Console.WriteLine("\nSubmissions:");
            for (int i = 0; i < randomizedSubmissions.Count; i++)
            {
                Console.WriteLine($"[{i}] {randomizedSubmissions[i].RedApple}");
            }
        }
    }
}
