namespace CardProject
{
    public interface IShuffler
    {
        string SorterName { get; }
        Deck Shuffle(Deck deck);
    }
}