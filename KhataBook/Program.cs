// See https://aka.ms/new-console-template for more information
using System;
using KhataBook;

public class Program
{
    static void Main()
    {
        Dictionary<string, int> items = new Dictionary<string, int>()
        {
            { "Milk", 100 },
            { "Tea", 50 },
            { "Coffee", 100 },
            { "Sugar", 50 },
            { "Salt", 200 },
            {"Bread",100},

        };

        Khata khata = new Khata(items);

        Console.WriteLine("Total Amount: " + khata.getTotal());        
        Console.WriteLine("Unique Amount Count: " + khata.getRepeatAmount()); 
    }
}
