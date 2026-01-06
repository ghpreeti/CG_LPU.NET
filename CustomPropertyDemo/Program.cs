// See https://aka.ms/new-console-template for more information
using CustomPropertyDemo;
using System;

class Program
{
    struct Customer1    //Structure are Value Type
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }
    static void Main()
    {
        Customer custObj= new Customer();
        //Customer1 cust1;

        custObj.CustID = 101;
        custObj.Name = "Test";

        //Init shipping adress
        custObj.ShipingAddress = new Address();
        custObj.ShipingAddress.FlatNo = 1802;
        custObj.ShipingAddress.Locality = "Locality";
        custObj.ShipingAddress.BuildingName = "Sky Tower";
        custObj.ShipingAddress.Street = "STREET";
        custObj.ShipingAddress.City = "Pune";

        //1 customer-have-many Orders

        custObj.MyOrders = new List<Order>()
        {
            new Order { OrderID = 1002, OrderDate = new DateTime(2002, 01, 15), Amount = 18500 },
            new Order { OrderID = 1003, OrderDate = new DateTime(2003, 03, 10), Amount = 9200 },
            new Order { OrderID = 1004, OrderDate = new DateTime(2004, 06, 18), Amount = 25600 },
            new Order { OrderID = 1005, OrderDate = new DateTime(2005, 09, 05), Amount = 11300 },
            new Order { OrderID = 1006, OrderDate = new DateTime(2006, 11, 22), Amount = 30500 },
            new Order { OrderID = 1007, OrderDate = new DateTime(2007, 02, 14), Amount = 17800 },
            new Order { OrderID = 1008, OrderDate = new DateTime(2008, 07, 30), Amount = 6400 }


        };


    }
}
