using System;
using System.Collections.Generic;
using System.Text;

namespace MethodOverloading
{
    internal class Source
    {
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        public double Add(double a, double b, double c)
        {
            return a + b + c;
        }
    }
}
