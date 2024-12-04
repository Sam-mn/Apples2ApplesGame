using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public abstract class GameTemplate
    {
        protected readonly List<Player> players = new();
        protected Deck<string> greenAppleDeck;
        protected Deck<string> redAppleDeck;
        protected int currentJudgeIndex = 0;
        protected readonly IGameRules rules;
        protected readonly Random random = new();

        protected GameTemplate(IGameRules rules)
        {
            this.rules = rules;
        }

        // Template Method
        public void RunGame()
        {
            LoadDecks();
            AddPlayers();
            InitializeGame();

            while (!IsGameOver())
            {
                PlayRound();
                RotateJudge();
            }

            AnnounceWinner();
        }

        // Steps to be implemented or extended by subclasses
        protected abstract void LoadDecks();
        protected abstract void AddPlayers();
        protected virtual void InitializeGame()
        {
            DealInitialCards();
            RandomizeJudge();
        }
        protected abstract bool IsGameOver();
        protected abstract void PlayRound();
        protected abstract void RotateJudge();
        protected abstract void AnnounceWinner();

        protected void DealInitialCards()
        {
            foreach (var player in players)
            {
                player.DrawCards(redAppleDeck.DrawMultiple(7));
            }
        }

        protected void RandomizeJudge()
        {
            currentJudgeIndex = random.Next(players.Count);
        }

        protected Player GetCurrentJudge() => players[currentJudgeIndex];
    }
}

