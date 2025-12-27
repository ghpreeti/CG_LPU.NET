// See https://aka.ms/new-console-template for more information
using System;
using QuickMart;

class Program
{
    public static void Main()
    {
        SaleTransaction lastTransaction = null;

        while (true)
        {
            Console.WriteLine("================== QuickMart Traders ==================");
            Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
            Console.WriteLine("2. View Last Transaction");
            Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateNewTransaction(ref lastTransaction);
                    break;
                case "2":
                    ViewLastTransaction(lastTransaction);
                    break;
                case "3":
                    CalculateProfitLoss(lastTransaction);
                    break;
                case "4":
                    Console.WriteLine("Thank you. Application closed normally.");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }

    static void CreateNewTransaction(ref SaleTransaction lastTransaction)
    {
        SaleTransaction saleObj = new SaleTransaction();

        Console.Write("Enter Invoice No: ");
        saleObj.InvoiceNo = Console.ReadLine();

        Console.Write("Enter Customer Name: ");
        saleObj.CustomerName = Console.ReadLine();

        Console.Write("Enter Item Name: ");
        saleObj.ItemName = Console.ReadLine();

        Console.Write("Enter Quantity: ");
        saleObj.Quantity = Int32.Parse(Console.ReadLine());

        Console.Write("Enter Purchase Amount (total): ");
        saleObj.PurchaseAmount = decimal.Parse(Console.ReadLine());

        Console.Write("Enter Selling Amount (total): ");
        saleObj.SellingAmount = decimal.Parse(Console.ReadLine());

        saleObj.CalculateProfitLoss();

        lastTransaction = saleObj;

        Console.WriteLine("\nTransaction saved successfully.");
        Console.WriteLine($"Status: {saleObj.ProfitOrLossStatus}");
        Console.WriteLine($"Profit/Loss Amount: {saleObj.ProfitOrLossAmount}");
        Console.WriteLine($"Profit Margin (%): {saleObj.ProfitMarginPercent}");
        Console.WriteLine("------------------------------------------------------");
    }

    static void ViewLastTransaction(SaleTransaction lastTransaction)
    {
        if (lastTransaction == null)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first");
            return;
        }

        Console.WriteLine("-------------- Last Transaction --------------");
        Console.WriteLine($"InvoiceNo: {lastTransaction.InvoiceNo}");
        Console.WriteLine($"Customer: {lastTransaction.CustomerName}");
        Console.WriteLine($"Item: {lastTransaction.ItemName}");
        Console.WriteLine($"Quantity: {lastTransaction.Quantity}");
        Console.WriteLine($"Purchase Amount: {lastTransaction.PurchaseAmount}");
        Console.WriteLine($"Selling Amount: {lastTransaction.SellingAmount}");
        Console.WriteLine($"Status: {lastTransaction.ProfitOrLossStatus}");
        Console.WriteLine($"Profit/Loss Amount: {lastTransaction.ProfitOrLossAmount}");
        Console.WriteLine($"Profit Margin (%): {lastTransaction.ProfitMarginPercent}");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("------------------------------------------------------");
    }

    static void CalculateProfitLoss(SaleTransaction lastTransaction)
    {
        if (lastTransaction == null)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            return;
        }

        lastTransaction.CalculateProfitLoss();

        Console.WriteLine("Profit/Loss recalculated.");
        Console.WriteLine($"Status: {lastTransaction.ProfitOrLossStatus}");
        Console.WriteLine($"Profit/Loss Amount: {lastTransaction.ProfitOrLossAmount}");
        Console.WriteLine($"Profit Margin (%): {lastTransaction.ProfitMarginPercent}");
    }
}


