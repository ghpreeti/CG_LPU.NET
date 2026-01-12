// See https://aka.ms/new-console-template for more information

using System;
using System.Runtime.InteropServices;
using LINQConsoleApp;
class Program
{
    public static void LinqToObjectDemo()
    {
        int[] numArray = { 12, 23, 34, 45, 56, 67, 78, 89, 90 };
        string[] nameArray = { "Alok", "Riya", "Ayush", "Yash", "Ram", "Teja", "Karan" };

        //foreach (var num in numArrya)
        //{
        //    if(num%2==0)
        //    Console.WriteLine(num);
        //}

        //LINQ query syntax

        //var result = from data in numArray
        //             where data % 2 == 0 && data > 30
        //             select data;


        //var result = from data in nameArray
        //             where data.Contains('a') || data.Contains('A')
        //             select data;

        //Console.WriteLine("Enter the name: ");
        //string dataToSearch = Console.ReadLine();

        //var result = from data in nameArray
        //             where data == dataToSearch
        //             select data;

        //var result = nameArray.Where(data => data == dataToSearch); 
        var result = from data in nameArray
                   // where data == dataToSearch
                   orderby data
                   select data;

        foreach (var num in result)
        {
            Console.WriteLine(num);
        }
    }

    public static void LinqToObjectDemoOnCustomType()
    {
        List<Customer> custList = new List<Customer>()
        {
            new Customer(){ CustomerId=101, Name="Alok", City="Mumbai"},
            new Customer(){ CustomerId=102, Name="Riya", City="Pune"},
            new Customer(){ CustomerId=103, Name="Ayush", City="Delhi"},
            new Customer(){ CustomerId=104, Name="Yash", City="Chennai"},
            new Customer(){ CustomerId=105, Name="Ram", City="Kolkata"},
            new Customer(){ CustomerId=106, Name="Teja", City="Pune"},
            new Customer(){ CustomerId=107, Name="Karan", City="Mumbai"},
            new Customer(){ CustomerId=108, Name="Anita", City="Bangalore"},

        };

        //Anonymous type
        var data = new { OrderId = 1180, OrderDate = 05 / 01 / 2020, TotalAmount = 14000 };

        var result = custList.Where(cust => cust.City == "Mumbai");//multiple occurence
        //var result1 = custList.Find(cust=>cust.City == "Pune");//its gives first occurence based on primaryKey col
        var result1 = custList.FindAll(cust => cust.City == "Pune");//all occurence

        foreach (var cust in result)
        {
            Console.WriteLine($"CustomerId: {cust.CustomerId}, Name: {cust.Name}, City: {cust.City}");
        }
    }

    public static void LamdaLookUp()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
        var query = numbers.ToLookup(n => n % 2);

        foreach (IGrouping<int, int> group in query)
        {
            Console.WriteLine("Key:{0}", group.Key);
            foreach (int num in group)
            {
                Console.WriteLine(num);
            }
        }
    }

    public static void LamdaLookUpOnStudentList()
    {
        StudentRepo sRepo = new StudentRepo();
        List<Student> tempList = sRepo.GetAllStudents();
        var query = tempList.ToLookup(s=>s.Gender=="M");

        foreach (IGrouping<bool, Student> group in query)
        {
            //Console.WriteLine("Key:{0}", group.Key);
            int totalFees = 0;
            if (group.Key == true)
            {
                Console.WriteLine("Male details: ");
            }
            else
            {
                Console.WriteLine("Female details: ");
            }
                foreach (Student std in group)
                {
                    Console.WriteLine($"{std.Name}");
                totalFees += std.Fees;
                }
            Console.WriteLine($"Total Fees Paid: {totalFees}");
        }

    }
    public static void Main()
    {
        // LinqToObjectDemo();
        //LinqToObjectDemoOnCustomType();
        //LamdaLookUp();
        //LamdaLookUpOnStudentList();

        //StudentRepo sRepo = new StudentRepo();
        //List<Student> templist = sRepo.GetAllStudents();

        //var total = templist.Select(f => f.Fees).Sum();
        //var total1 = templist.Select(f => f.Fees).Min();
        //var total2 = templist.Select(f => f.Fees).Max();

        //Console.WriteLine($"Total {total}");
        //Console.WriteLine($"Total1 {total1}");
        //Console.WriteLine($"Total2 {total2}");

        List<Product> prodList = new List<Product>()
            {
                new Product(){ID=1,Name="Maza",Cost=50,Quantity=2000},
                  new Product(){ID=2,Name="RedBull",Cost=50,Quantity=4000},
                    new Product(){ID=3,Name="Sprite",Cost=150,Quantity=2000},
                      new Product(){ID=4,Name="Coke",Cost=200,Quantity=2000},
                       new Product(){ID=5,Name="Fanta",Cost=30,Quantity=4000}
            };
        Dictionary<string, int> demoDict = new Dictionary<string, int>();
        var itemsList = prodList.GroupBy(item => item.Name == "RedBull")
            .Select(group => new
            {
                Qty = group.Key,
                items = group.ToList()
            });
        foreach (var item in itemsList)
        {
            Console.WriteLine("Quantity :{0}", item.Qty);
            demoDict.Add(item.Qty.ToString(), item.items.Count());
            Console.WriteLine($"Items Count {item.items.Count()}");
            int total = 0;
            foreach (var data in item.items)
            {
                Console.WriteLine(data.Name);
                total += data.Cost;
            }
            Console.WriteLine($"Total Cost of Products :{total}");
        }
    }

}

