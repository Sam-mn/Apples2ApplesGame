using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplesGame.cards;
using ApplesGame.playersLogic;

namespace ApplesGame.commands
{
    public class ReplenishHandsCommand : ICommand
    {
        private readonly List<Player> players;
        private readonly Deck<string> redAppleDeck;

        public ReplenishHandsCommand(List<Player> players, Deck<string> redAppleDeck)
        {
            this.players = players;
            this.redAppleDeck = redAppleDeck;
        }

        public void Execute()
        {
            foreach (var player in players)
            {
                if (player.Hand.Count < 7)
                {
                    var cardsToDraw = 7 - player.Hand.Count;
                    var newCards = redAppleDeck.DrawMultiple(cardsToDraw);
                    player.DrawCards(newCards);
                }
            }
        }
    }
}
