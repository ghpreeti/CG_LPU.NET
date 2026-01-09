using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace contravariance_demo
{
    delegate void del_contravar(B obj);
    class Program
    {
        static void Main(string[] args)
        {
            B b1 = new B();
            del_contravar dc = new del_contravar(b1.AFun);
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
