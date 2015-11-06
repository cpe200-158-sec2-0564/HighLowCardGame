using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLCG
{
    class Game
    {
        private Player player1,player2;
        private Deck cardDeck;

        public Game()
        {
            SetupDialogue();
            StartDialogue();
            GameLoop();
        }

        private void SetupDialogue()
        {
            int Nplayer;
            Console.Write("How many deck? :");

            try { Nplayer = Convert.ToInt32(Console.ReadLine()); }
            catch(Exception e) { Nplayer = 1; }

            cardDeck = new Deck(Nplayer);
        }

        private void StartDialogue()
        {
            string name1,name2;
            Console.Write("Enter Player 1 name:");
            name1 = Console.ReadLine();
            player1 = new Player(name1, 0, cardDeck);

            Console.Write("Enter Player 2 name:");
            name2 = Console.ReadLine();
            player2 = new Player(name2, 26, cardDeck);
        }

        private void GameLoop()
        {       //Perform deal card(s)
            while (player1.Pile.Count > 0 && player2.Pile.Count > 0)
            {
                player1.Deal();
                player2.Deal();
                Console.WriteLine(ValueCompare());
                Console.ReadKey();
            }
                //Ending result//
            if (player1.Score > player2.Score)
            {
                Console.WriteLine("\t\t\t\t\t\t{0} (Player 1) wins!", player1.Name);
            }
            else if (player1.Score < player2.Score)
            {
                Console.WriteLine("\t\t\t\t\t\t{0} (Player 2) wins!", player2.Name);
            }
            else
            {
                Console.WriteLine("\t\t\t\t\t\t Tie!");

            }
            Console.WriteLine("\n\t\t\t\t\t\t Press Any Key to Exit");
        }

        public string ValueCompare(int r=1)
        {
            string winner="";
            //--- Normal case---//
            if (r == 1)
            {
                if (player1.RecentCard.Rank < player2.RecentCard.Rank)    //Player 1 greater
                {
                    player1.Take();
                    player1.Remove();
                    player2.Remove();
                    winner = player1.Name + " wins.  " + player1.Name + ":" + player1.Score + "  " + player2.Name + ":" + player2.Score;
                }
                else if (player1.RecentCard.Rank > player2.RecentCard.Rank)//Player 2 greater
                {
                    player2.Take();
                    player1.Remove();
                    player2.Remove();
                    winner = player2.Name + " wins.  " + player1.Name + ":" + player1.Score + "  " + player2.Name + ":" + player2.Score;
                }
                else if (player1.RecentCard.Rank == player2.RecentCard.Rank)//Tie
                {
                    Console.WriteLine("Draw!");
                    int drewCard = player1.RecentCard.Rank;
                    if (drewCard < player1.Pile.Count || drewCard < player2.Pile.Count)
                    {
                        player1.Deal(player1.RecentCard.Rank + 1);
                        player2.Deal(player2.RecentCard.Rank + 1);
                        Console.Write(ValueCompare(drewCard));
                    }
                    else if (player1.Pile.Count!=1 && player2.Pile.Count!=1)
                    {
                        Console.WriteLine("Not enough cards to play. Shuffling>>>");
                        player1.Shuffle();
                        player2.Shuffle();
                        Console.WriteLine("\nPress Any Key to Continue");
                    }
                    else
                    {
                        Console.WriteLine("\t\t\t\t\tIt is the last card. Game is ending.");
                        player1.Remove();
                        player2.Remove();
                    }
                }
            }
            //---Tie case---//
            else
            {
                if (player1.RecentCard.Rank < player2.RecentCard.Rank)
                {
                    player1.Take(r + 1);
                    player1.Remove(r + 1);
                    player2.Remove(r + 1);
                    winner = player1.Name + " wins.  " + player1.Name + ":" + player1.Score + "  " + player2.Name + ":" + player2.Score;
                }
                //Player 2 greater
                else if (player1.RecentCard.Rank > player2.RecentCard.Rank)
                {
                    player2.Take(r + 1);
                    player1.Remove(r + 1);
                    player2.Remove(r + 1);
                    winner = player2.Name + " wins.  " + player1.Name + ":" + player1.Score + "  " + player2.Name + ":" + player2.Score;
                }
                //Tie again
                else if (player1.RecentCard.Rank == player2.RecentCard.Rank)
                {
                    Console.WriteLine("Tie again! Shuffling>>>");
                    player1.Shuffle();
                    player2.Shuffle();
                    Console.WriteLine("\nPress Any Key to Continue");
                }
            }
            return winner;
        }
        
    }
}
