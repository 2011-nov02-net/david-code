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

		private static int accountNumberSeed = 1234567890;

		private List<Transaction> allTransactions = new List<Transaction>();

		//constructor
		public BankAccount(string name, decimal initialBalance)
		{
			this.Owner = name;
			this.Number = accountNumberSeed.ToString();
			accountNumberSeed++;

			//use the initialBalance as a deposit and add transaction
			MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
		}

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
			if(Balance - amount < 0)
			{
				throw new InvalidOperationException("Insufficent Funds for this withdrawal.");
			}
			Transaction withdrawal = new Transaction(-amount, date, note);
			allTransactions.Add(withdrawal);

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
    }
}
