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
            return record.Values.Distinct().Count();
        }
    }
}
