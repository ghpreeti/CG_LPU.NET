using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4DemoOOP
{
    abstract class Employee//we can create its multiple chils but not the objects
    {
        #region Properties
        public int EmployeeId { get; set; }
        //public string Name { get; set; }
        public int BasicSal { get; set; }
        #endregion

        public abstract int CalculateSal(int sal);//abstract classses atleast have one abstract method
        //public virtual int CalculateSal(int sal)//use virtual to allow overriding in derived classes
        //{
        //    int mySal = 0;
        //    mySal = sal + 15000 + 3000 + 1500 - 2500; // Sal+ DA + HRA + TA - PF
        //    return mySal;
        //}
    }
}
