namespace CardProject
{
    public class Card
    {
        private readonly Suit suit;
        private readonly Rank rank;

        public Card(Suit suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        public override string ToString() => rank + " of " + suit;

        public override int GetHashCode() => suit.ToString().Length ^ rank.ToString().Length;

        public override bool Equals(object obj)
        {
            if (!(obj is Card card)) return false;
            return card.rank == rank && card.suit == suit;
        }
    }
}