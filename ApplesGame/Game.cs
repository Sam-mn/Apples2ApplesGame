using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public sealed class Game : GameTemplate
    {
        private static Game _instance;
        private Game(IGameRules rules) : base(rules) { }

        public static Game GetInstance(IGameRules rules)
        {
            if (_instance == null)
            {
                _instance = new Game(rules);
            }
            return _instance;
        }

        protected override void LoadDecks()
        {
            greenAppleDeck = new Deck<string>(File.ReadAllLines("./greenApples.txt"));
            redAppleDeck = new Deck<string>(File.ReadAllLines("./redApples.txt"));
        }

        protected override void AddPlayers()
        {
            // Add bots
            for (int i = 0; i < 3; i++)
            {
                players.Add(PlayerFactory.CreatePlayer(i, isBot: true));
            }

            // Add human player
            players.Add(PlayerFactory.CreatePlayer(players.Count, isBot: false));
        }

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
            var submissions = GetPlayerSubmissions(judge);



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
            ReplenishHands();
        }

        protected override void RotateJudge()
        {
            currentJudgeIndex = (currentJudgeIndex + 1) % players.Count;
        }

        protected override void AnnounceWinner()
        {
            var winner = players.OrderByDescending(p => p.Score).First();
            Console.WriteLine($"\nGame Over! Winner is Player {winner.Id} with {winner.Score} green apples.");
        }

        private List<PlayedApple> GetPlayerSubmissions(Player judge)
        {
            var submissions = new List<PlayedApple>();
            foreach (var player in players)
            {
                if (player != judge)
                {
                    var submitCommand = new SubmitRedAppleCommand(player, submissions);
                    submitCommand.Execute();
                }
            }

            return submissions.OrderBy(_ => Guid.NewGuid()).ToList();
        }

        private PlayedApple JudgeWinner(Player judge, List<PlayedApple> submissions)
        {
            if (judge.Id != players.Count - 1)
            {
                Console.WriteLine("\nSubmissions:");
                for (int i = 0; i < submissions.Count; i++)
                {
                    Console.WriteLine($"[{i}] {submissions[i].RedApple}");
                }
            }

            return judge.JudgeCards(submissions);
        }

        // Replenish hands
        private void ReplenishHands()
        {
            var replenishCommand = new ReplenishHandsCommand(players, redAppleDeck);
            replenishCommand.Execute();
        }
    }
}
