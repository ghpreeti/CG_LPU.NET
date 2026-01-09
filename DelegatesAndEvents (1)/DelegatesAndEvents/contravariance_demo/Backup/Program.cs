using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace contravariance_demo
{
    delegate void del_contravar(B bobj);
    class Program
    {
        static void Main(string[] args)
        {
            B a = new B();
            del_contravar dc = new del_contravar(a.AFun);
            dc(new B());
            Console.ReadLine();
        }
    }
    class A
    {
        public A()
        {

        }
        public void AFun(A obj)
        {
            Console.WriteLine("A Fun called...");
        }

    }
    class B : A
    {
        public void BFun(B obj)
        {
            Console.WriteLine("B Fun called...");
        }

    }
}
