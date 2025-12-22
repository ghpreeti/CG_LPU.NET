using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    public class MathClass : IAll,IAddSub,IAdd
    {
        public int AddMe(int a, int b)
        {
            return a + b;
        }
        public int SubMe(int a, int b)
        {
            return a - b;
        }
        public int ProdMe(int a, int b)
        {
            return a * b;
        }
        public float DivMe(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Denominator cannot be zero.");
            }
            return (float)a / b;
        }



    }
}
