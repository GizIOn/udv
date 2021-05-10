using System.Collections.Generic;
using System.Linq;

namespace CardProject
{
    public class DeckManager
    {
        private readonly List<Deck> decks;
        private int automaticallyGeneratedDecksCount;
        private readonly IShuffler shuffler;

        public DeckManager(IShuffler shuffler = default)
        {
            decks = new List<Deck>();
            automaticallyGeneratedDecksCount = 0;
            this.shuffler = shuffler ?? new RandomShuffler();
        }

        public void CreateDeck()
        {
            decks.Add(new Deck($"deck {automaticallyGeneratedDecksCount++}"));
        }

        public void CreateDeck(string name)
        {
            AddDeck(new Deck(name));
        }


        public void AddDeck(Deck deckToAdd)
        {
            decks.Add(deckToAdd);
        }

        public void CreateDecks(int decksToCreate)
        {
            for (var i = 0; i < decksToCreate; i++)
            {
                CreateDeck();
            }
        }

        public void RemoveDeck(string name)
        {
            var deck = decks.Find(x => x.Name == name);
            decks.RemoveAll(x => deck != null && x.Name.Equals(deck.Name));
        }

        public void RemoveDeck(Deck deckToRemove)
        {
            if (decks.Find(x => x.Name == deckToRemove.Name) != null) decks.Remove(deckToRemove);
        }

        public Deck GetDeckOrNull(string name)
        {
            return decks.Find(x => x.Name == name);
        }

        public List<string> GetNames()
        {
            return decks.Select(t => t.Name).ToList();
        }

        public Deck Shuffle(Deck deck)
        {
            var shuffleDeck = shuffler.Shuffle(deck);
            UpdateDecks(deck, shuffleDeck);
            return shuffleDeck;
        }

        public Deck Shuffle(string deckToShuffle)
        {
            var deckNameToShuffle = GetDeckOrNull(deckToShuffle);
            var shuffleDeck = shuffler.Shuffle(deckNameToShuffle);
            UpdateDecks(deckNameToShuffle, shuffleDeck);
            return shuffleDeck;
        }

        private void UpdateDecks(Deck deckToRemove, Deck deckToAdd)
        {
            decks.Remove(deckToRemove);
            decks.Add(deckToAdd);
        }
    }
}