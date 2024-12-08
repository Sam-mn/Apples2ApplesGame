using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplesGame.notUsed;

namespace ApplesGame.playersLogic
{
    public abstract class Player : IGameObserver
    {
        public int Id { get; }
        public List<string> Hand { get; private set; }
        public List<string> GreenApples { get; private set; }
        public virtual int Score => GreenApples.Count;


        public Player(int id)
        {
            Id = id;
            Hand = new List<string>();
            GreenApples = new List<string>();
        }

        public void DrawCards(IEnumerable<string> cards)
        {
            Hand.AddRange(cards);
        }

        public void AddPoint(string greenApple)
        {
            GreenApples.Add(greenApple);
        }

        public void Update(string message)
        {
            Console.WriteLine(message);
        }

        public abstract PlayedApple PlayCard();
        public abstract PlayedApple JudgeCards(List<PlayedApple> submissions);
    }
}
