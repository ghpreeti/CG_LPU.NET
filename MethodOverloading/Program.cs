// See https://aka.ms/new-console-template for more information
using System;
using MethodOverloading;

class Program
{
       static void Main(string[] args)
    {
        Source source = new Source();
        int intResult = source.Add(10, 20, 30);
        double doubleResult = source.Add(10.5, 20.5, 30.5);
        Console.WriteLine($"Integer Addition Result: {intResult}");
        Console.WriteLine($"Double Addition Result: {doubleResult}");
    }

}

