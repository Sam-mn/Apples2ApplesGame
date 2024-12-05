using ApplesGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TellWhenTheGameIsOver
    {
        [Fact]
        public void Tell_When_The_Game_Is_Over()
        {
            var rules = new DefaultGameRules();
            var playesNumbers = 4;

            // Act
            int score = rules.GetWinningScore(playesNumbers);

            // Assert
            Assert.Equal(8, score);

            playesNumbers = 5;

            // Act
            int scoreFOrFive = rules.GetWinningScore(playesNumbers);

            // Assert
            Assert.Equal(7, scoreFOrFive);

            playesNumbers = 6;

            // Act
            int scoreFOrSex= rules.GetWinningScore(playesNumbers);

            // Assert
            Assert.Equal(6, scoreFOrSex);

        }
    }
}
