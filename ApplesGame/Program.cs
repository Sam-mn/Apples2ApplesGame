namespace ApplesGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var gameRoules = new DefaultGameRules();
                var game = new GameEngine(gameRoules);
                game.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}\n{e.StackTrace}");
            }
        }
    }
}
