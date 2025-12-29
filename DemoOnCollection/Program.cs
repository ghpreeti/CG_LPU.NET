// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;

namespace DemoOnCollection
{
    class Program
    {
        public void ArrayDemo()
        {
            int[] arrNum;
            arrNum = new int[5];

            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            string[] cities = { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix" };

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            // var result = x in cities where x.Length > 6 select x;
            Customer[] custArray; // Customer c1 m
            custArray = new Customer[1];

            //Init the object
            custArray[0] = new Customer();

            custArray[0].ID = 101;
            custArray[0].Name = "Alok";

            //init the address class
            custArray[0].BillingAddress = new Address();

            custArray[0].BillingAddress.FlatNo = "1802";
            custArray[0].BillingAddress.BuildingName = "Sunshine Apartments";
            custArray[0].BillingAddress.Street = "Main Street";
            custArray[0].BillingAddress.City = "Mumbai";

            custArray[0].ShippingAddress = custArray[0].BillingAddress;

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
