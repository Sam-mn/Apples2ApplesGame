namespace ApplesGame.cards
{
    public interface IDeck<T>
    {
        // Get and return the geen card, then remove it from the list
        T Draw();

        // Get multiple red cards and remove it from the list
        List<T> DrawMultiple(int count);

        // Shuffle the card list
        void Shuffle();
    }
}