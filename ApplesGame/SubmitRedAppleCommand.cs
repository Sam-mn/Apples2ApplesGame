using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public class SubmitRedAppleCommand : ICommand
    {
        private readonly Player player;
        private readonly List<PlayedApple> submissions;

        public SubmitRedAppleCommand(Player player, List<PlayedApple> submissions)
        {
            this.player = player;
            this.submissions = submissions;
        }

        public void Execute()
        {
            var playedApple = player.PlayCard();
            submissions.Add(playedApple);
        }
    }
}
