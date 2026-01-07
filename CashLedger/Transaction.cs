using System;

namespace CashLedger
{
    public abstract class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }

        public abstract string GetSummary();
    }
}