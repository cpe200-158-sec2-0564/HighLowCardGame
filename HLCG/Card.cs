using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLCG
{
    class Card
    {
        private int rank;
        private int suit;
        private static string[] cardName = { "Ace" , "Deuce" , "Three",
                                             "Four" , "Five" , "Six",
                                             "Seven", "Eight", "Nine",
                                             "Ten" , "Jack", "Queen" , "King" };
        private static string[] cardSuit = { "Spade", "Heart", "Diamond", "Club" };

        public Card(int r, int s)
        {
            rank = r;
            suit = s;
        }

        public int Rank
        {
            get { return rank; }
            set { rank = (value >= 1 && value <= 13) ? value:0; }
        }

        public int Suit
        {
            get { return suit; }
            set { suit = (value >= 1 && value <= 4) ? value:0; }
        }

        public string GetName()
        {
            string s = cardName[rank-1] + " of " + cardSuit[suit-1];
            return s; 
        }
    }
}
