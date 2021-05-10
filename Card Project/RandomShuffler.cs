using System;
using System.Linq;

namespace CardProject
{
    public class RandomShuffler : IShuffler
    {
        public string SorterName => "Random Sorter";

        public Deck Shuffle(Deck deck)
        {
            var cardsCount = deck.Cards.Count;
            var output = new Card[cardsCount];
            var rnd = new Random();
            while (output.Any(x => x is null))
            {
                var i = rnd.Next(cardsCount);
                var j = rnd.Next(cardsCount);
                if (output[i] is null) output[i] = deck.Cards[j];
            }

            return new Deck(deck.Name + " shuffled by " + SorterName, output.ToList());
        }
    }
}