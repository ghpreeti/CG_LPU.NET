using System;

class AddProg
{
    public static void Run()
    {
        int num1;
        int num2;
        int numResult;

        // Taking input
        Console.Write("Enter First Number: ");
        num1 = Int32.Parse(Console.ReadLine());//in C# int takes 4bytes in memory : 32bits

        Console.Write("Enter Second Number: ");
        num2 = Int32.Parse(Console.ReadLine());

        // Business Logic
        int discount = (num1+num2)*10/100;
        numResult = (num1 + num2)-discount; // payable amount after discount

        // Output
        //Console.Write("The Sum of {0} and {1} is {2}", num1, num2, numResult);
        Console.WriteLine("LPU Shopee");
        Console.WriteLine("Price of product1 {0}", num1);
        Console.WriteLine("Price of product2 {0}", num2);
        Console.WriteLine("Total Payable Amount {0}", (num1+num2));
        Console.WriteLine("Discounted Price {0}", discount);
        Console.WriteLine("Final Amount to be paid after discount {0}", numResult);
    }
}

