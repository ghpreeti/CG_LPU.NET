using System;
using System.Collections.Generic;
using System.Text;

namespace LINQConsoleApp
{
    internal class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }
    }
}
