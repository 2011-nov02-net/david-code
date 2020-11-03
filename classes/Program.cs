using System;

namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
			BankAccount acct = new BankAccount("David", 2000);
			Console.WriteLine($"Account {acct.Number} was created for {acct.Owner} with {acct.balance} inital balance");
        }
    }
}
