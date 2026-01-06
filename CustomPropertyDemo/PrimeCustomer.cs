using System;
using System.Collections.Generic;
using System.Text;

namespace CustomPropertyDemo
{
    internal class PrimeCustomer : Customer
    {
        public List<Order> MyPrimeOrder // write only prop
        {
            set
            {
                MyOrders = value;
            }
        }
    }
}
