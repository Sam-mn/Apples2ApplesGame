using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplesGame.cards;
using ApplesGame.gameLogic.rules;
using ApplesGame.playersLogic;

namespace ApplesGame.gameLogic
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
        protected abstract void DealInitialCards();
        protected abstract void RandomizeJudge();
        protected abstract Player GetCurrentJudge();
    }
}

