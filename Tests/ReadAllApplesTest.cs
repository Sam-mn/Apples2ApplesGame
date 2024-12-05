using ApplesGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ReadAllApplesTest
    {
        [Fact]
        public void Read_Green_Apples_File()
        {
            // Assert
            Assert.NotNull(File.ReadAllLines("./greenApples.txt"));
        }

        [Fact]
        public void Read_Red_Apples_File()
        {
            // Assert
            Assert.NotNull(File.ReadAllLines("./redApples.txt"));
        }

        [Fact]
        public void Read_All_Green_Apples()
        {
            // Act
            var greenApples = new Deck<string>(File.ReadAllLines("./greenApples.txt"));

            // Assert
            Assert.Equal(614, greenApples.getCardsNumber());
        }

        [Fact]
        public void Read_All_Red_Apples()
        {
            // Act
            var redApples = new Deck<string>(File.ReadAllLines("./redApples.txt"));

            // Assert
            Assert.Equal(1826, redApples.getCardsNumber());
        }
    }
}
