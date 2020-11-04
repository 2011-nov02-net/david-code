using System;

namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
			BankAccount acct = new BankAccount("David", 2000);
			Console.WriteLine($"Account {acct.Number} was created for {acct.Owner} with {acct.Balance} inital balance");

			//test deposit and withdrawals
			acct.MakeWithdrawal(600, DateTime.Now, "Rent");
			Console.WriteLine(acct.Balance);

			acct.MakeDeposit(500, DateTime.Now, "Refund of expensive purchase");
			Console.WriteLine(acct.Balance);

			//force an error
			try
			{
				BankAccount test = new BankAccount("Invalid", -55);
			}
			catch (ArgumentOutOfRangeException e)
			{
				Console.WriteLine("Exception caught while making account");
				Console.WriteLine(e.ToString());
			}

			//test for negative balance
			try
			{
				acct.MakeWithdrawal(3000, DateTime.Now, "Attempt to overdraw");
			}
			catch (InvalidOperationException e)
			{
				Console.WriteLine("Exception caught trying to overdraw");
				Console.WriteLine(e.ToString());
			}

			Console.WriteLine(acct.GetAccountHistory());
		}
    }
}
