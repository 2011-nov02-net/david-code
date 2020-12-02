using System;
using System.Collections.Generic;
using RockPaperSissors.Library.Difficulty;
using RockPaperSissors.Library;

namespace RockPaperSissors.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //get user input
            string input = null;
            while(input != "y" && input != "n")
            {
                Console.Write("Would you like to play Rock Paper Sissors? (y/n): ");
                input = Console.ReadLine();
            }

            var history = new List<Turn>(); 

            while(input == "y")
            {
                //reset input
                input = null;
                while(input != "e")
                {
                    Console.Write("What Difficulty? (e)asy: ");
                    input = Console.ReadLine();
                }

                IDifficulty comp;
                switch(input)
                {
                    case "e":
                        comp = new EasyDifficulty();
                        break;
                    default:
                        comp = new EasyDifficulty();
                        break;
                }

                //in interest of fairness, get computer move first
                string compMove = comp.getMove();

                //get player move
                input = null;
                while(input != "r" && input != "p" && input != "s")
                {
                    Console.Write("Please make your choice (\"r\" | \"p\" | \"s\"): ");
                    input = Console.ReadLine();
                }

                string playerMove = null;
                switch(input)
                {
                    case "r":
                        playerMove = "Rock";
                        break;
                    case "p":
                        playerMove = "Paper";
                        break;
                    case "s":
                        playerMove = "Sissors";
                        break;
                }
                           
                //figure out the winner
                var turn = new Turn(playerMove, compMove);

                if(turn.Winner != "Invalid")
                {
                    Console.WriteLine($"You played:\t\t{turn.PlayerHand}");
                    Console.WriteLine($"Computer Played:\t{turn.CompHand}");
                    Console.WriteLine($"The winner is: {turn.Winner}");
                }

                history.Add(turn);

                //ask if the player would like to play again
                input = null;
                while (input != "y" && input != "n")
                {
                    Console.Write("Would you like to play again? (y/n): ");
                    input = Console.ReadLine();
                    Console.Clear();
                }

            }

        }
    }
}
