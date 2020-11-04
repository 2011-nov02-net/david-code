using System;

namespace classes
{
	class LineOfCreditAccount : BankAccount
	{	

		public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base (name, initialBalance, -creditLimit)
		{}

		public override void PerformMonthEndTransactions()
		{
			if(Balance < 0)
			{
				decimal interest = -Balance * 0.07m;
				MakeWithdrawal(interest, DateTime.Now, "Monthly Interest Charge.");
			}
		}

		protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
			isOverdrawn ? new Transaction(-20, DateTime.Now, "Overdraft fee") : default;
	}
}