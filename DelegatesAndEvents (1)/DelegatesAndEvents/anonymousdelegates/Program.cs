using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anonymousdelegates
{
    delegate int mydelegate(int a,int b);
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Enter two numbers");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            mydelegate mdel = delegate(int c, int d)
            {
                return a + b;
            };
            Console.WriteLine(mdel(a, b));
            Console.ReadLine();
     
        }
    }
}
