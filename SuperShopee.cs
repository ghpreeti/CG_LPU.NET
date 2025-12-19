using System;
using MyRetailLogic; //importing namespace
//to console CSC /r:looslyCoupled.dll SuperShopee.cs --> taking reference from looslyCoupled.dll used by SuperShopee.cs

public class SuperShopee
{
    public static void Run()
    {
        int prod1;
        int prod2;
        int numResult;

        // Taking input
        Console.Write("Enter First Number: ");
        prod1 = Int32.Parse(Console.ReadLine());//in C# int takes 4bytes in memory : 32bits

        Console.Write("Enter Second Number: ");
        prod2 = Int32.Parse(Console.ReadLine());

        // Business Logic
        //constructor are methods with same name as class name and no return type
        RetailLogic rlObj = new RetailLogic();
        int discount = rlObj.CalcDiscount(prod1 + prod2);
        numResult = (prod1 + prod2)-discount; // payable amount after discount

        // Output
        //Console.Write("The Sum of {0} and {1} is {2}", prod1, prod2, numResult);
        Console.WriteLine("LPU Shopee");
        Console.WriteLine("Price of product1 {0}", num1);
        Console.WriteLine("Price of product2 {0}", num2);
        Console.WriteLine("Total Payable Amount {0}", (num1+num2));
        Console.WriteLine("Discounted Price {0}", discount);
        Console.WriteLine("Final Amount to be paid after discount {0}", numResult);
    }
}

