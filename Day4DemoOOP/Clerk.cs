using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4DemoOOP
{
    class Clerk : Employee
    {
        public int ClrkId { get; set; }
        public int Bonus { get; set; }

        public override int CalculateSal(int sal)
        {
            int mySal = 0;
            mySal = sal + 35000 + 15000 + 4500 - 8500; // Sal+ DA + HRA + TA - PF
            return mySal;
        }
    }
}
