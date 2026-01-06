using System;
using System.Collections.Generic;
using System.Text;

namespace CustomPropertyDemo
{
    public class Customer
    {

        List<Order> orderList = null;
        public Customer()
        {
            orderList = new List<Order>();
        }

        public List<Order> MyOrders {
            get
            {
                return orderList;
            }

            protected set 
            {
                orderList = value;
            } 
        }
        public int CustID { get; set; }
        public string Name { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShipingAddress { get; set; }



        //List<Order> myOrders=null
        //Order[] myOrders = null;
        //public Customer() { 

        //    //myOrders = new List<Order>();
        //    myOrders = new Order[5];
        //}
    }
}
