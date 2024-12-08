using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame.playersLogic
{
    public static class PlayerFactory
    {
        public static Player CreatePlayer(int id, bool isBot)
        {
            return isBot ? new BotPlayerBehavior(id) : new HumanPlayerBehavior(id);
        }
    }
}
