﻿using ApplesGame;
using ApplesGame.playersLogic;
using ApplesGame.gameLogic;
using ApplesGame.cards;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tests
{
    public class Rule7ChooseRedApple
    {
        [Fact]
        public void All_Players_Except_The_Judge_Choose_Red_Apple()
        {
            // Arrange
            var redApples = new Deck<string>(File.ReadAllLines("./redApples.txt"));
            var players = new List<Player>();

            // Act
            var playerManager = new PlayersManager(1, 3);
            var roundManager = new RoundManager();
            players.AddRange(playerManager.AddPlayer());
            playerManager.DealInitialCards(players, redApples);

            int judgeIndex = 3;

            var submissions = roundManager.GetSubmissions(players, players[judgeIndex]);

            // Assert
            Assert.Equal(players.Count - 1, submissions.Count);

        }
    }
}
