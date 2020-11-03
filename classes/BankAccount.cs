using System;

namespace classes
{
    class BankAccount
    {
		//properties
        public string Number { get; }
		public string Owner{ get; set; }
		public decimal balance{ get; }

		private static int accountNumberSeed = 1234567890;

		//constructor
		public BankAccount(string name, decimal initialBalance)
		{
			this.Owner = name;
			this.balance = initialBalance;
			this.Number = accountNumberSeed.ToString();
			accountNumberSeed++;
		}

		//methods
		public void MakeDeposit(decimal amount, DateTime date, string note)
		{

		}

		public void MakeWithdrawal(decimal amount, DateTime date, string note)
		{

		}
    }
}
