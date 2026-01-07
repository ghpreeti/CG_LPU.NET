using System;

namespace CashLedger
{
    public class ExpenseTransaction : Transaction
    {
        public string Category { get; set; }

        public override string GetSummary()
        {
            return $"Expense {Description} ({Category}) amount ${Amount} on {Date: dd-mm-yyyy}";
        }
    }
}