using System;
using System.Collections.Generic;
using System.Text;

namespace KhataBook
{
    public class Khata
    {
        private Dictionary<string, int> record;

        // Public constructor
        public Khata(Dictionary<string, int> record)
        {
            this.record = record;
        }

        // Returns total amount spent on all items
        public int getTotal()
        {
            int total = 0;
            foreach (int amount in record.Values)
            {
                total += amount;
            }
            return total;
        }

        // Returns count of unique amounts in the dictionary
        public int getRepeatAmount()
        {
            Dictionary<int,int> amountCount = new Dictionary<int,int>();
            foreach(var amount in record.Values)
            {
                if(amountCount.ContainsKey(amount))
                {
                    amountCount[amount]++;
                }
                else
                {
                    amountCount[amount] = 1;
                }
            }
             int count=0;
            foreach(var c in amountCount.Values)
            {
                if(c > 1)
                {
                    count++;
                }
            }
            return count;
        }

        public void AddItem(string itemName, int amount)
        {
            if(record.ContainsKey(itemName))
            {
                record[itemName] += amount;
            }
            else
            record.Add(itemName, amount);
        }
    }
}
