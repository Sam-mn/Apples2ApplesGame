namespace ApplesGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ErrorMessages.Load("greenApples.txt");
                ErrorMessages.Load("redApples.txt");


                var gameRoules = new DefaultGameRules();
                var game = Game.GetInstance(gameRoules);
                game.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}\n{e.StackTrace}");
            }
        }
    }
}
