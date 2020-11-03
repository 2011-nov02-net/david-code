using System;

namespace AcronymMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a string you would like to be turned into an acronym: ");
			string input = Console.ReadLine();

			var acronym = new System.Text.StringBuilder();
			while(input.CompareTo("") != 0)
			{
				Console.WriteLine(input);
				//get the character a postition 0
				acronym.Append(input[0]);

				//get the location of the next space
				int index = input.IndexOf(" ");

				//check to see if there is anoter space
				if(index == -1)
				{
					// " " was not found in the string and we are at the end
					// so set the input to null, so we can break out of the loop
					input = "";
				}
				else
				{
					input = input.Substring(index + 1);
				}
			}

			Console.WriteLine($"The Acronym is: {acronym}");
        }
    }
}
