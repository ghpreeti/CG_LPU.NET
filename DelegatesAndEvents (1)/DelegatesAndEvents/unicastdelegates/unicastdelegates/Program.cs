using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace unicastdelegates
{
    delegate int myfirstdelegate(int a,int b);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Two Numbers");
            int a =Convert.ToInt32( Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            calculate c = new calculate();
            myfirstdelegate mfd = new myfirstdelegate(c.add);
            int z =mfd(a,b);
            Console.WriteLine(z);
            Console.ReadLine();
        }
    }
    class calculate
    {
        public int add(int a,int b)
        {
            int c = a + b;
            return c;
        }
    }
}
