using System;
using System.Collections.Generic;
using System.Text;

namespace Day3Demo
{
    internal class Person
    {
        #region Fields
        int id;
        int age;
        int name;
        #endregion

        public Person()
        {
            Console.WriteLine("Default Constructor invoked");
        }

        ~Person()
        {
            Console.WriteLine("Destructor Called invoked");
        }

        /// <summary>
        /// Display method for Demo Purpose
        ///</summary>

        public void Display(object o)
        {
            Console.WriteLine(o.ToString());
        }

    }
}
