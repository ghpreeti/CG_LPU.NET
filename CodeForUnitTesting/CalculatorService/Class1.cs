using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
    public class Calculator
    {
        public int AddMe(int num1 , int num2)
        {
            return num1 + num2;
        }

        public int SubMe(int num1, int num2) => num1 - num2;

        public int ProdMe(int num1, int num2) =>num1 * num2;

        public float DivideMe(int num1, int num2)
        {
            float num3 = 0f;
            if (num2 == 0)
            {
                throw new DivideByZeroException("Cannot be divide by zero");
            }
            else
            {
                num3 = num1 / num2;
            }
            return num3;
        }
    }
}
