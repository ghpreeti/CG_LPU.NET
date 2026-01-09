using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace delegatechaining
{
    delegate void mydel (int a,int b);
    class Program
    {
        static void Main(string[] args)
        {
            calculate c = new calculate();


            mydel[] d = new mydel[]{

                new mydel (c.add),
                new mydel (c.sub)
            };
         mydel md =(mydel)Delegate.Combine(d);
         md(20, 10);
         md=(mydel)Delegate.Remove(md,d[0]);
         md(12, 13);
         Console.ReadLine();
            }
        }
    
    class calculate
    {
        public void  add(int a, int b)
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
