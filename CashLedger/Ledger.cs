using System;
using System.Collections.Generic;

namespace CashLedger
{
    public class Ledger<T> where T : Transaction
{
    private List<T> transactions = new List<T>();

    public void AddEntry(T entry)
    {
        transactions.Add(entry);
    }

    public List<T> GetTransactionsByDate(DateTime date)
    {
        List<T> result = new List<T>();
        foreach (var t in transactions)
        {
            if (t.Date == date)
            {
                result.Add(t);
            }
        }
        return result;
    }

    public int CalculateTotal()
    {
        int total = 0;
        
        foreach(var item in transactions)
        {
            total += item.Amount;
        }
        
        return total;
    }

}
}


