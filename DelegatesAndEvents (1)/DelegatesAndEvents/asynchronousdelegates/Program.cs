using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace asynchronousdelegates
{
    delegate int mydel(int a,int b);
    class Program
    {
        static void Main(string[] args)
        {
            calculate c = new calculate();
            mydel d = new mydel(c.add);
            //int res=d(10, 20);
            //Console.WriteLine(res);
            //Console.WriteLine("Hello");

            IAsyncResult res = d.BeginInvoke(10, 20, null, null);
            Console.WriteLine("Hello");
            //d.EndInvoke(res);
            Console.WriteLine(d.EndInvoke(res));
            Console.ReadLine();
        }
    }
    class calculate
    {
        public int add(int a, int b)
        {
            int c = a + b;
           // Thread.Sleep(5000);
            return c;
        }
        public int sub(int a, int b)
        {
            return a-b;
        }
    }
}
