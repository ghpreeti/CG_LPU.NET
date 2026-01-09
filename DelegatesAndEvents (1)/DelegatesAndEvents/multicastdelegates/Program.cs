using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace multicastdelegates
{
    delegate void myfirstdelegate(int a, int b);

    class Program
    {
        static void Main(string[] args)
        {
            calculate c = new calculate();
            myfirstdelegate mfd_all ;
            myfirstdelegate mfd = new myfirstdelegate(c.add);
            myfirstdelegate mfd1 = new myfirstdelegate(c.sub);
            mfd_all = mfd;
            mfd_all +=mfd1;
            mfd_all(20, 10);
            Console.ReadLine();
        }
    }
    class calculate
    {
        public void add(int a, int b)
        {
            int c = a + b;
            Console.WriteLine(c);
        }
        public void sub(int a, int b)
        {
            int c = a - b;
            Console.WriteLine(c);
        }
    }
}
