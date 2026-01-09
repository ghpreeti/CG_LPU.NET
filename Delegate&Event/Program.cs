// See https://aka.ms/new-console-template for more information
using System;
using Delegate_Event;
//using System.Threading;

class Program
{
    public delegate bool CreateRecord(Product p);
    public delegate void CallerDelegate(string str);
    public delegate void strDelegate(string str);

    public class Handler
    {
        public static void Uppercase(string s)
        {
            Thread.Sleep(5000);
            Console.WriteLine(s.ToUpper());
        }
    }

    public static void ShowMe(string str)
    {
        Console.WriteLine("Show Me Caller");
    }

    public void GenerateBill(string str)
    {
        Console.WriteLine("GenerateBill Called");
    }
    
    static void Main(string[] arg)
    {
        //ProductRepo pRepo = new ProductRepo();

        //CreateRecord AddProduct = new CreateRecord(pRepo.Add);
        //AddProduct(new Product());

        Program p1 = new Program();

        //CallerDelegate CallMe = new CallerDelegate(Program.ShowMe);
        //CallMe -= new CallerDelegate(p1.GenerateBill);
        //CallMe += new CallerDelegate(p1.GenerateBill);

        //CallMe("LPU");
         
        strDelegate sd = new strDelegate(Handler.Uppercase);
        //sd("lpu university");

        //IAsyncResult result = sd.BeginInvoke("asynchronous call", null, null);
        IAsyncResult result = sd.BeginInvoke("lpu university",null,null);
        Console.WriteLine("Main Method Complete");
        sd.EndInvoke(result);
        
    }
} 

