using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public interface IPlayerBehavior
    {
        PlayedApple PlayCard(List<string> hand, int playerId);
        PlayedApple JudgeCards(List<PlayedApple> submissions);
    }
}
