using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public class Player : IGameObserver
    {
        public int Id { get; }
        public List<string> Hand { get; private set; }
        public List<string> GreenApples { get; private set; }
        public virtual int Score => GreenApples.Count;

        private readonly IPlayerBehavior behavior;

        public Player(int id, IPlayerBehavior behavior)
        {
            Id = id;
            this.behavior = behavior;
            Hand = new List<string>();
            GreenApples = new List<string>();
        } 

        public void DrawCards(IEnumerable<string> cards)
        {
            Hand.AddRange(cards);
        }

        public PlayedApple PlayRedApple()
        {
            return behavior.PlayCard(Hand, Id);
        }

        public PlayedApple JudgeCards(List<PlayedApple> submissions)
        {
            return behavior.JudgeCards(submissions);
        }

        public void AddPoint(string greenApple)
        {
            GreenApples.Add(greenApple);
        }

        public void Update(string message)
        {
            Console.WriteLine(message);
        }
    }
}
