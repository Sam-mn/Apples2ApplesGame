using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public static class PlayerFactory
    {
        public static Player CreatePlayer(int id, bool isBot)
        {
            IPlayerBehavior behavior = isBot ? new BotPlayerBehavior() : new HumanPlayerBehavior();
            return new Player(id, behavior);
        }
    }
}
