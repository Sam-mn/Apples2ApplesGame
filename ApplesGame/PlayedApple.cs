using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public class PlayedApple
    {
        public int PlayerId { get; }
        public string RedApple { get; }

        public PlayedApple(int playerId, string redApple)
        {
            PlayerId = playerId;
            RedApple = redApple;
        }
    }
}
