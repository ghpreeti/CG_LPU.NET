using System.Collections.Generic;

namespace CollectionsDemo
{
    public class EmployeeRepo
    {
        static List<Employee> empList = null;

        public EmployeeRepo()
        {
            empList = new List<Employee>()
            {
                new Employee { ID = 101, Name = "Amit",  Salary = 50000, Exp = 3 },
                new Employee { ID = 102, Name = "Neha",  Salary = 65000, Exp = 5 },
                new Employee { ID = 103, Name = "Ravi",  Salary = 45000, Exp = 2 },
                new Employee { ID = 104, Name = "Sneha", Salary = 80000, Exp = 7 },
                new Employee { ID = 105, Name = "Pooja", Salary = 55000, Exp = 4 }
            };
        }

        public Employee[] GetEmployeeArray()
        {
            return empList.ToArray();
        }
    }
}
