using System;
using System.Collections.Generic;
using System.Text;

namespace Day3Demo
{
    internal class Employee
    {
        #region Fields
        int id;
        int age;
        int name;
        #endregion

        public Employee()
        {
            Console.WriteLine("Default Constructor invoked");
        }

        ~Employee()
        {
            Console.WriteLine("Destructor Called invoked");
        }
    }
}
