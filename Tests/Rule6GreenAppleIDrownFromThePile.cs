using ApplesGame;
using ApplesGame.cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class GreenAppleIDrownFromThePile
    {
        [Fact]
        public void Drow_Green_Apple()
        {
            // Act
            var greenApples = new Deck<string>(File.ReadAllLines("./greenApples.txt"));

            //Arrange
            var greenCard = greenApples.Draw();

            //Assert
            Assert.NotNull(greenCard);
        }
    }
}
