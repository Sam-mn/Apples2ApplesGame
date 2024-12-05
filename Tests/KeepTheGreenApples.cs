﻿using ApplesGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Tests
{
    public class KeepTheGreenApples
    {
        [Fact]
        public void Keep_Score_By_Keeping_The_Green_Apples()
        {
            var redApples = new Deck<string>(File.ReadAllLines("./redApples.txt"));
            var greenApples = new Deck<string>(File.ReadAllLines("./redApples.txt"));

            var players = new List<Player>();

            var playerManager = new PlayersManager(0, 4);
            var roundManager = new RoundManager();
            players.AddRange(playerManager.AddPlayer());
            playerManager.DealInitialCards(players, redApples);

            int judgeIndex = 3;

            var submissions = roundManager.GetSubmissions(players, players[judgeIndex]);

            int winnerId = 0;
            var theGreenApple = greenApples.Draw();
            var judgeCommand = new JudgeCardsCommand(players[judgeIndex], submissions, winner =>
            {
                players[winner.PlayerId].AddPoint(theGreenApple);
                winnerId = winner.PlayerId;
            });
            judgeCommand.Execute();

            var WinnerGreenApples = players[winnerId].GreenApples[0];

            Assert.Equal(WinnerGreenApples, theGreenApple);
        }
    }
}