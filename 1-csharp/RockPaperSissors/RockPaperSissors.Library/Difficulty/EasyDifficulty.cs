using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperSissors.Library.Difficulty
{
    public class EasyDifficulty : IDifficulty
    {
        private string[] options = { "Rock", "Paper", "Sissors" };
        public EasyDifficulty() { }

        public string getMove()
        {
            Random rand = new Random();
            int index = rand.Next(options.Length);
            return options[index];
        }
    }
}
