using System;

namespace classes
{
	class InterestEarningAccount : BankAccount
	{
		//call the parent constructor as this is a derived class and we have to call it
		// explicitly
		public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
		{}

		public override void PerformMonthEndTransactions()
		{
			if(Balance > 500m)
			{
				decimal interest = Balance * 0.05m;
				MakeDeposit(interest, DateTime.Now, "Monthly Interest");
			}
		}


	}
}