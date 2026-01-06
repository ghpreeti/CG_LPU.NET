using System;
using System.Collections.Generic;
using System.Text;

namespace OperatorOverloadingDemo
{
    internal class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public int Salary { get; set; }

        public static Employee operator +(Employee e1, Employee e2)
        {
            Employee temp = new Employee();
            temp.Salary = e1.Salary + e2.Salary;
            return temp;

}
    }
}
