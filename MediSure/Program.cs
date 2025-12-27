// See https://aka.ms/new-console-template for more information
using System;
using MediSure;

public class Program
{
    public static void Main()
    {
        PatientBill lastBill = null;

        while (true)
        {
            Console.WriteLine("================== MediSure Clinic Billing ==================");
            Console.WriteLine("1. Create New Bill (Enter Patient Details)");
            Console.WriteLine("2. View Last Bill");
            Console.WriteLine("3. Clear Last Bill");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateNewBill(ref lastBill);
                    break;
                case "2":
                    ViewLastBill(lastBill);
                    break;
                case "3": 
                    ClearLastBill(ref lastBill);
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

    static void CreateNewBill(ref PatientBill lastBill)
    {
        PatientBill bill = new PatientBill();

        Console.Write("Enter Bill Id: ");
        bill.BillID = Console.ReadLine();

        Console.Write("Enter Patient Name: ");
        bill.PatientName = Console.ReadLine();

        Console.Write("Is the patient insured? (Y/N): ");
        string insured = Console.ReadLine().ToUpper();
        bill.HasInsurance = insured == "Y"; //BOOL 

        Console.Write("Enter Consultation Fee: ");
        bill.ConsultationFee = decimal.Parse(Console.ReadLine());

        Console.Write("Enter Lab Charges: ");
        bill.LabCharges = decimal.Parse(Console.ReadLine());

        Console.Write("Enter Medicine Charges: ");
        bill.MedicineCharges = decimal.Parse(Console.ReadLine());

        bill.CalculateBill();

        lastBill = bill;

        Console.WriteLine("\nBill created successfully.");
        Console.WriteLine($"Gross Amount: {bill.GrossAmount:}");
        Console.WriteLine($"Discount Amount: {bill.DiscountAmount:}");
        Console.WriteLine($"Final Payable: {bill.FinalPayable:}");
        Console.WriteLine("------------------------------------------------------------");
    }

    static void ViewLastBill(PatientBill lastBill)
    {
        if (lastBill == null)
        {
            Console.WriteLine("No bill available. Please create a new bill first.");
            return;
        }

        Console.WriteLine("----------- Last Bill -----------");
        Console.WriteLine($"BillId: {lastBill.BillID}");
        Console.WriteLine($"Patient: {lastBill.PatientName}");
        Console.WriteLine($"Insured: {(lastBill.HasInsurance ? "Yes" : "No")}");
        Console.WriteLine($"Consultation Fee: {lastBill.ConsultationFee:}");
        Console.WriteLine($"Lab Charges: {lastBill.LabCharges:}");
        Console.WriteLine($"Medicine Charges: {lastBill.MedicineCharges:}");
        Console.WriteLine($"Gross Amount: {lastBill.GrossAmount:}");
        Console.WriteLine($"Discount Amount: {lastBill.DiscountAmount:}");
        Console.WriteLine($"Final Payable: {lastBill.FinalPayable:}");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("------------------------------------------------------------");
    }

    static void ClearLastBill(ref PatientBill lastBill)
    {
        lastBill = null;
        Console.WriteLine("Last bill cleared.");
    }
}
