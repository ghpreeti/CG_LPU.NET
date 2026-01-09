using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace covariance
{
    delegate normal_calci del_normalcalci();
    class Program
    {
        static void Main(string[] args)
        {
            scientific_calci sc = new scientific_calci();
            del_normalcalci delobj = new del_normalcalci(sc.add_precise);
            delobj();
            Console.ReadLine();
        }
    }

    class normal_calci
    {
        public normal_calci()
        {
        }

    }
    class scientific_calci : normal_calci
    {
        public scientific_calci()
        {
        }
        public scientific_calci add_precise()
        {

            int a = 50;
            int b = 30;
            Console.WriteLine(a + b);
            return null;

        }
    }
}
