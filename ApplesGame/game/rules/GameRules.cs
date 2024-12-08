using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame.gameLogic.rules
{
    public class GameRules
    {
        private IGameRules _gameRules;

        public GameRules() { }
        public GameRules(IGameRules gameRules)
        {
            _gameRules = gameRules;
        }

        public void SetGameRoules(IGameRules gameRules)
        {
            _gameRules = gameRules;
        }
    }
}
