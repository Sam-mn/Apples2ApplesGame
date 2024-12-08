using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplesGame.gameLogic;

namespace ApplesGame
{
    public static class Client
    {
        public static void start(GameTemplate game)
        {
             game.RunGame();
        }
    }
}
