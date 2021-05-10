using System;
using System.Collections.Generic;
using System.Linq;

namespace CardProject
{
    public class Deck
    {
        public readonly string Name;
        public readonly List<Card> Cards;
        private readonly List<Card> sortedSetCards=GetSortedDeck();

        public Deck(string name)
        {
            Name = name;
            Cards = sortedSetCards.ToList();
        }

        public Deck(string name, bool isSortedDeckNeeded)
        {
            Name = name;
            Cards = isSortedDeckNeeded ? sortedSetCards.ToList() : new List<Card>();
        }

        public Deck(string deckName, List<Card> cards)
        {
            Name = deckName;
            Cards = cards.ToList();
        }

        public override string ToString() => Name + "\n" + string.Join(Environment.NewLine, Cards);

        private static List<Card> GetSortedDeck()
        {
            var suits = Enum.GetNames(typeof(Suit))
                .Select(x => (Suit) Enum.Parse(typeof(Suit), x))
                .Skip(1);
            var ranks = Enum.GetNames(typeof(Rank))
                .Select(x => (Rank) Enum.Parse(typeof(Rank), x))
                .Skip(1);

            return (from suit in suits from rank in ranks select new Card(suit, rank)).ToList();
        }
    }
}