using System;


namespace CashLedger
{
    public class IncomeTransaction : Transaction
    {
        public string Source { get; set; }

        public override string GetSummary()
        {
            return $"Income {Description} from {Source} amount ${Amount} on {Date:dd-mm-yyyy}";
        }
    }
}