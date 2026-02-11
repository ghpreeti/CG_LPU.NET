using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternMiniFramework
{
    public class Cart
    {
        public List<string> Items { get; } = new List<string>();
        public double TotalAmount { get; set; }

        public void AddItem(string item, double price)
        {
            Items.Add(item);
            TotalAmount += price;
        }

        public void RemoveItem(string item, double price)
        {
            Items.Remove(item);
            TotalAmount -= price;
        }

        public void ApplyDiscount(double discount)
        {
            TotalAmount -= discount;
        }

        public void RemoveDiscount(double discount)
        {
            TotalAmount += discount;
        }

        public void ShowCart()
        {
            Console.WriteLine("Items: " + string.Join(", ", Items));
            Console.WriteLine("Total: " + TotalAmount);
            Console.WriteLine("-------------------");
        }
    }


}

