using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplesGame.cards;

namespace ApplesGame.playersLogic
{
    public class PlayersManager : IPlayersManager
    {
        private int _numOfHummanPlayers;
        private int _numOfBotPlayers;
        public PlayersManager(int hummanPlayers, int botPlayers)
        {
            _numOfBotPlayers = botPlayers;
            _numOfHummanPlayers = hummanPlayers;
        }
        public List<Player> AddPlayer()
        {
            try
            {
                List<Player> players = new();
                var playersNUmber = _numOfHummanPlayers + _numOfBotPlayers;

                for (int i = 0; i < playersNUmber; i++)
                {
                    players.Add(PlayerFactory.CreatePlayer(i, isBot: i < _numOfBotPlayers));
                }
                return players;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ErrorMessages.Get("Fail when adding players"));
            }

        }
        public void DealInitialCards(List<Player> players, Deck<string> redAppleDeck)
        {
            foreach (var player in players)
            {
                player.DrawCards(redAppleDeck.DrawMultiple(7));
            }
        }
    }
}
