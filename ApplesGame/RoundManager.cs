﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public class RoundManager: IRoundManager
    {
        public List<PlayedApple> GetSubmissions(List<Player> players, Player judge)
        {
            var submissions = new List<PlayedApple>();

            foreach (var player in players)
            {
                if (player != judge)
                {
                    var submitCommand = new SubmitRedAppleCommand(player, submissions);
                    submitCommand.Execute();
                }
            }

            return submissions.OrderBy(_ => Guid.NewGuid()).ToList();
        }

        public void ReplenishHands(List<Player> players, Deck<string> redAppleDeck)
        {
            foreach (var player in players)
            {
                if (player.Hand.Count < 7)
                {
                    player.DrawCards(redAppleDeck.DrawMultiple(7 - player.Hand.Count));
                }
            }
        }
    }
}

