using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplesGame.cards;
using ApplesGame.gameLogic;
using ApplesGame.judge;
using ApplesGame.playersLogic;
using ApplesGame.commands;
using ApplesGame.gameLogic.rules;

namespace ApplesGame.game
{
    public sealed class Game : GameTemplate
    {
        private static Game _instance;
        private readonly IDeckManager<string> deckManager;
        private readonly IJudgeManager judgeManager;
        private readonly IRoundManager roundManager;
        private readonly IPlayersManager playersManager;

        private Game(IGameRules rules, IDeckManager<string> deckManager, IJudgeManager judgeManager, IRoundManager roundManager, IPlayersManager playersManager)
           : base(rules)
        {
            this.deckManager = deckManager;
            this.judgeManager = judgeManager;
            this.roundManager = roundManager;
            this.playersManager = playersManager;
        }

        public static Game GetInstance(IGameRules rules, IDeckManager<string> deckManager, IJudgeManager judgeManager, IRoundManager roundManager, IPlayersManager playersManager)
        {
            return _instance ??= new Game(rules, deckManager, judgeManager, roundManager, playersManager);
        }

        protected override void LoadDecks()
        {
            greenAppleDeck = deckManager.LoadDeck("./greenApples.txt");
            redAppleDeck = deckManager.LoadDeck("./redApples.txt");
        }

        protected override void AddPlayers() => players.AddRange(playersManager.AddPlayer());


        protected override bool IsGameOver() => rules.CheckIfGameWon(players);

        protected override void PlayRound()
        {
            var judge = GetCurrentJudge();

            Console.WriteLine("\n*****************************************************");
            Console.WriteLine(judge.Id == players.Count - 1 ? "** NEW ROUND - JUDGE **" : "** NEW ROUND **");
            Console.WriteLine("*****************************************************");

            Console.WriteLine($"Player {judge.Id} is the judge for this round.\n");

            var greenApple = greenAppleDeck.Draw();
            Console.WriteLine($"==== Green Apple: {greenApple} ====\n");

            // Players submit red apples
            var submissions = roundManager.GetSubmissions(players, judge);

            // Judge selects a winner
            var judgeCommand = new JudgeCardsCommand(judge, submissions, winner =>
            {
                players[winner.PlayerId].AddPoint(greenApple);
            });
            judgeCommand.Execute();

            if (players[players.Count - 1] != judge)
            {
                var revealCommand = new RevealSubmissionsCommand(submissions);
                revealCommand.Execute();
            }

            // Replenish cards
            roundManager.ReplenishHands(players, redAppleDeck);
        }

        protected override void RotateJudge()
        {
            currentJudgeIndex = judgeManager.RotateJudge(players, currentJudgeIndex);
        }

        protected override void RandomizeJudge()
        {
            currentJudgeIndex = judgeManager.RandomizeJudge(players);
        }
        protected override Player GetCurrentJudge()
        {
            return judgeManager.GetCurrentJudge(players, currentJudgeIndex);
        }

        protected override void AnnounceWinner()
        {
            var winner = players.OrderByDescending(p => p.Score).First();
            Console.WriteLine($"\nGame Over! Winner is Player {winner.Id} with {winner.Score} green apples.");
        }

        protected override void DealInitialCards() => playersManager.DealInitialCards(players, redAppleDeck);
    }
}
