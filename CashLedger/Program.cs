using System;
using CashLedger;
class Program
{
    static void Main()
    {
      
        Ledger<IncomeTransaction> incomeLedger = new Ledger<IncomeTransaction>();

       
        incomeLedger.AddEntry(new IncomeTransaction
        {
            Description = "Replenishment",
            Source = "Main Cash",
            Amount = 500,
            Date = DateTime.Now
        });

        
        Ledger<ExpenseTransaction> expenseLedger = new Ledger<ExpenseTransaction>();

     
        expenseLedger.AddEntry(new ExpenseTransaction
        {
            Description = "Stationery",
            Category = "Office Supplies",
            Amount = 20,
            Date = DateTime.Now
        });

        expenseLedger.AddEntry(new ExpenseTransaction
        {
            Description = "Team Snacks",
            Category = "Refreshments",
            Amount = 15,
            Date = DateTime.Now
        });

      
        Console.WriteLine("=== Ledger Summary ===");
        Console.WriteLine($"Total Income: ${incomeLedger.CalculateTotal()}");
        Console.WriteLine($"Total Expenses: ${expenseLedger.CalculateTotal()}");

        ///<summary
        /// 
        /// </summary>
        
        
        // Console.WriteLine("=== Transaction Details ===");
        // List<Transaction> allTransactions = new List<Transaction>();
        // foreach (var t in incomeLedger)
        // {
        //     Console.WriteLine(t.GetSummary());
        // }

      
        int netBalance = incomeLedger.CalculateTotal() - expenseLedger.CalculateTotal();
        Console.WriteLine($"=== Net Balance ===");
        Console.WriteLine($"Net Balance: ${netBalance}");
    }

   
}