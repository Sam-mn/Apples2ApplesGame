using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public class Game : ISubject
    {
        private readonly List<Player> players = new();
        private Deck<string> greenAppleDeck;
        private Deck<string> redAppleDeck;
        private int currentJudgeIndex = 0;
        private readonly IGameRules rules;
        private readonly List<IGameObserver> gameObservers = new List<IGameObserver>();
        public Game(IGameRules rules)
        {
            this.rules = rules;
        }

        public void Start()
        {
            InitializeGame();
            PlayRounds();
        }

        private void InitializeGame()
        {
            // Load and shuffle decks
            greenAppleDeck = new Deck<string>(File.ReadAllLines("./greenApples.txt"));
            redAppleDeck = new Deck<string>(File.ReadAllLines("./redApples.txt"));

            // Add players
            AddPlayers();

            // Deal 7 red apples to each player
            foreach (var player in players)
            {
                gameObservers.Add(player);
                player.DrawCards(redAppleDeck.DrawMultiple(7));
            }

            // Randomize judge
            currentJudgeIndex = new Random().Next(players.Count);
        }

        private void AddPlayers()
        {
            // Add 3 bots
            for (int i = 0; i < 3; i++)
            {
                players.Add(PlayerFactory.CreatePlayer(i, isBot: true));

            }

            // Add one human player
            players.Add(PlayerFactory.CreatePlayer(players.Count, isBot: false));
        }

        public override void AttachObserver(IGameObserver observer)
        {
            gameObservers.Add(observer);
        }

        public override void NotifyObservers(string message)
        {
            foreach (var observer in gameObservers)
            {
                observer.Update(message);
            }
        }

        private void PlayRounds()
        {
            bool gameFinished = false;

            while (!gameFinished)
            {
                var judge = players[currentJudgeIndex];

                Console.WriteLine("\n*****************************************************");
                if (judge.Id == 3)
                {
                    Console.WriteLine("** NEW ROUND - JUDGE **");
                }
                else
                {
                    Console.WriteLine("** NEW ROUND **");
                }
                Console.WriteLine("*****************************************************");

                Console.WriteLine($"Player {judge.Id} is the judge for this round.\n");

                // Draw a green apple
                var greenApple = greenAppleDeck.Draw();
                Console.WriteLine($"==== Green Apple: {greenApple} ====\n");

                // Players submit their red apples
                var submissions = new List<PlayedApple>();
                foreach (var player in players)
                {
                    if (player != judge)
                    {
                        var submitCommand = new SubmitRedAppleCommand(player, submissions);
                        submitCommand.Execute();
                    }
                }

                if (players[players.Count - 1] != judge)
                {
                    var revealCommand = new RevealSubmissionsCommand(submissions);
                    revealCommand.Execute();
                }

                // Judge selects a winner
                var judgeCommand = new JudgeCardsCommand(judge, submissions, winner =>
                {
                    players[winner.PlayerId].AddPoint(greenApple);
                });
                judgeCommand.Execute();

                // Check if the game is won
                gameFinished = rules.CheckIfGameWon(players);

                // Replenish hands
                var replenishCommand = new ReplenishHandsCommand(players, redAppleDeck);
                replenishCommand.Execute();

                // Rotate judge
                currentJudgeIndex = (currentJudgeIndex + 1) % players.Count;
            }

            AnnounceWinner();
        }

        private List<PlayedApple> GetPlayerSubmissions(Player judge)
        {
            var submissions = new List<PlayedApple>();

            foreach (var player in players)
            {
                if (player != judge)
                {
                    submissions.Add(player.PlayRedApple());
                }
            }

            return submissions.OrderBy(_ => Guid.NewGuid()).ToList();
        }

        private PlayedApple JudgeWinner(Player judge, List<PlayedApple> submissions, string greenApple)
        {
            Console.WriteLine("\nSubmissions:");
            for (int i = 0; i < submissions.Count; i++)
            {
                Console.WriteLine($"[{i}] {submissions[i].RedApple}");
            }

            return judge.JudgeCards(submissions);
        }

        private void ReplenishHands()
        {
            foreach (var player in players)
            {
                if (player.Hand.Count < 7)
                {
                    player.DrawCards(redAppleDeck.DrawMultiple(7 - player.Hand.Count));
                }
            }
        }

        private void AnnounceWinner()
        {
            var winner = players.OrderByDescending(p => p.Score).First();
            // Here I added observer pattern but, it was not usable in this case.
            //foreach(var observer in gameObservers)
            //{
            //    observer.Update($"\nGame Over! Winner is Player {winner.Id} with {winner.Score} green apples.");
            //}
            Console.WriteLine($"\nGame Over! Winner is Player {winner.Id} with {winner.Score} green apples.");
        }
    }
}
