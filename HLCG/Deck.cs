using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLCG
{
    class Deck
    {
        private List<Card> deck;

        public Deck(int d = 1)
        {
            deck = new List<Card>(52 * d);
            //assign all card unshuffled
            for (int c = 0; c < d; c++)
            {
                for (int s = 1; s < 5; s++)
                {
                    for (int r = 1; r < 14; r++)
                    {
                        deck.Add(new Card(r, s));
                    }
                }
                Shuffle();
            }
            Console.WriteLine("Playing " + d + " deck(s) ("+ 52*d +" cards)");

        }

        public List<Card> CardDeck { get { return deck; } }

        public void Shuffle()
        {
            for (int i = 0; i < deck.Count; i++) {
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                int j = rand.Next(0, deck.Count);
                Card A = deck[j];
                deck[j] = deck[i];
                deck[i] = A;
            }
        }

        public void DeckPrint()      //for debugging
        {
            for (int i = 0; i < 52; i++)
            {
                Console.Write(i + deck[i].GetName() + "    \t");
                if (i != 0 && (i + 1) % 2 == 0) { Console.Write("\n"); }
            }
        }
    }
}
