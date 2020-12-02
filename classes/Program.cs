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


			//------------------------------------------------------

			//test of giftcards

			GiftCardAccount gc = new GiftCardAccount("Gift Card", 100, 50);
			gc.MakeWithdrawal(20, DateTime.Now, "Buy Coffee");
			gc.MakeWithdrawal(50, DateTime.Now, "Buy Groceries");
			gc.PerformMonthEndTransactions();
			gc.MakeDeposit(27.50m, DateTime.Now, "Add additional Spending Money");
			Console.WriteLine(gc.GetAccountHistory());

			// test of Savings account
			InterestEarningAccount savings = new InterestEarningAccount("Savings Account", 10000);
			savings.MakeDeposit(750, DateTime.Now, "Save Some Money");
			savings.MakeDeposit(1250, DateTime.Now, "Add More Savings");
			savings.MakeWithdrawal(250, DateTime.Now, "Pay Monthly Bills");
			savings.PerformMonthEndTransactions();
			Console.WriteLine(savings.GetAccountHistory());

			//----------------------------------------------------

			// test line of credit
			var credit = new LineOfCreditAccount("Credit account", 0, 2000);
			credit.MakeWithdrawal(1000m, DateTime.Now, "Monthly Advance");
			credit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
			credit.MakeWithdrawal(5000m, DateTime.Now, "Emergency!");
			credit.MakeDeposit(150m, DateTime.Now, "Partial Repayment of repairs");
			credit.PerformMonthEndTransactions();
			Console.WriteLine(credit.GetAccountHistory());
		}
    }
}
