using System;
using System.Collections.Generic;

namespace classes
{
    class BankAccount
    {
		//properties
        public string Number { get; }
		public string Owner{ get; set; }
		public decimal Balance
		{ 
			get
			{
				decimal balance = 0;
				foreach (Transaction item in allTransactions)
				{
					balance += item.Amount;
				}

				return balance;
			} 
		}
		private readonly decimal minimumBalance;

		private static int accountNumberSeed = 1234567890;

		private List<Transaction> allTransactions = new List<Transaction>();

		//constructor
		public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
		{
			this.Owner = name;
			this.Number = accountNumberSeed.ToString();
			accountNumberSeed++;

			this.minimumBalance = minimumBalance;

			//use the initialBalance as a deposit and add transaction
			if(initialBalance > 0)
				MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
		}

		public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }

		//methods
		public void MakeDeposit(decimal amount, DateTime date, string note)
		{
			if(amount <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive.");
			}
			Transaction depotsit = new Transaction(amount, date, note);
			allTransactions.Add(depotsit);
		}

		public void MakeWithdrawal(decimal amount, DateTime date, string note)
		{
			if(amount <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive.");
			}
			var overdraftTransaction = CheckWithdrawalLimit(Balance - amount < minimumBalance);
			var withdrawal = new Transaction(-amount, date, note);
			allTransactions.Add(withdrawal);
			if(overdraftTransaction != null)
				allTransactions.Add(overdraftTransaction);

		}

		protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
		{
			if(isOverdrawn)
			{
				throw new InvalidOperationException("Insufficient Funds For This Withdrawal.");
			}
			else
			{
				return default;
			}
		}

		public string GetAccountHistory()
		{
			System.Text.StringBuilder report = new System.Text.StringBuilder();

			decimal balance = 0;
			report.AppendLine("Date\tAmount\tBalance\tNote");

			foreach(Transaction item in allTransactions)
			{
				balance += item.Amount;
				report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
			}

			return report.ToString();
		}

		public virtual void PerformMonthEndTransactions() {}
    }
}
