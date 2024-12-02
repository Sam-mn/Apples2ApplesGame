
namespace ApplesGame
{
    public interface IDeck<T>
    {
        T Draw();
        List<T> DrawMultiple(int count);
        void Shuffle();
    }
}