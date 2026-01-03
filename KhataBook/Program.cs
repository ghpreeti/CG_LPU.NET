// See https://aka.ms/new-console-template for more information
using System;
using KhataBook;

public class Program
{
    static void Main()
    {
        Dictionary<string, int> items = new Dictionary<string, int>()
        {
            { "Milk", 50 },
            { "Bread", 40 },
            { "Butter", 50 },
            { "Eggs", 40 },
            { "Fruits", 100 }
        };

        Khata khata = new Khata(items);

        Console.WriteLine("Total Amount: " + khata.getTotal());        // 280
        Console.WriteLine("Unique Amount Count: " + khata.getRepeatAmount()); // 3
    }
}
