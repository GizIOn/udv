using System;
using System.Collections.Generic;
using System.Linq;

namespace CardProject
{
    public class HandShuffler : IShuffler
    {
        public string SorterName => "Hand Sorter";

        public Deck Shuffle(Deck deck)
        {
            var name = deck.Name;
            var cards = deck.Cards.ToList();
            var count = cards.Count;
            if (count < 2) return new Deck(name, cards);
            if (count == 2) return new Deck(name, new List<Card> {cards[1], cards[0]});
            var half = count / 2;
            var fifth = count / 5;
            var rnd = new Random().Next(half - fifth, half + fifth);
            var left = ShuffleCards(cards.Take(rnd).ToList());
            var right = ShuffleCards(cards.Skip(rnd).ToList());
            var i = 0;
            while (i < 75)
            {
                var temp = left.ToList();
                left = ShuffleCards(right.ToList());
                right = ShuffleCards(temp.ToList());
                i++;
            }

            return new Deck(name + " shuffled by " + SorterName, Merge(right, left));
        }

        private static List<Card> ShuffleCards(List<Card> cards)
        {
            var cardsCount = cards.Count;
            var half = cardsCount/2;
            var fifth = cardsCount / 7;
            var rnd = new Random().Next(half-fifth, half+fifth);
            var left = cards.Take(rnd).ToList();
            var right = cards.Skip(rnd).ToList();
            return Merge(right, left);
        }

        private static List<Card> Merge(List<Card> left, List<Card> right)
        {
            var output = left.ToList();
            output.AddRange(right);
            return output;
        }
    }
}