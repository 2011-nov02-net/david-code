using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperSissors.Library
{
    public class Turn
    {
        public string Winner { get; }
        public string PlayerHand { get; }
        public string CompHand { get; }

        public Turn(string playerHand, string compHand)
        {
            PlayerHand = playerHand;
            CompHand = compHand;
            Winner = DetermineWinner();
        }

        public string DetermineWinner()
        {
            string winner = null;
            if (PlayerHand == CompHand)
            {
                //tie Neither side wins
                winner = "Draw";
            }
            else if (PlayerHand == "Rock")
            {
                if (CompHand == "Paper")
                    winner = "Computer";
                else
                    winner = "Player";
            }
            else if (PlayerHand == "Paper")
            {
                if (CompHand == "Sissors")
                    winner = "Computer";
                else
                    winner = "Player";
            }
            else if (PlayerHand == "Sissors")
            {
                if (CompHand == "Rock")
                    winner = "Computer";
                else
                    winner = "Player";
            }
            else
                winner = "Invalid";

            return winner;
        }
    }
}
