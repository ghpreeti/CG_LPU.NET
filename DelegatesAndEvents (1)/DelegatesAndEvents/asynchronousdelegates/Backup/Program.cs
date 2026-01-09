using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace asynchronousdelegates
{
    delegate int mydel(int a,int b);
    class Program
    {
        static void Main(string[] args)
        {
            calculate c = new calculate();
            mydel d = new mydel(c.add);
            IAsyncResult res = d.BeginInvoke(10,20,null,null);
            d.EndInvoke(res);
            Console.WriteLine(d.EndInvoke(res));
            Console.ReadLine();
        }
    }
    class calculate
    {
        public int add(int a, int b)
        {
            int c = a + b;
            return c;
        }
        public int sub(int a, int b)
        {
            return a-b;
        }
    }
}
