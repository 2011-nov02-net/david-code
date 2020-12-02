using System;

namespace classes
{
    class Transaction
    {
		public decimal Amount {get;}
		public DateTime Date {get;}
		public string Notes {get;}

		public Transaction(decimal amount, DateTime date, String note)
		{
			this.Amount = amount;
			this.Date = date;
			this.Notes = note;
		}
    }
}
