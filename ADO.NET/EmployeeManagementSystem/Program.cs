using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    internal class Program
    {

        static void Main(string[] args)
        {
            EmployeeDAL dal = new EmployeeDAL();
            int choice;

            do
            {
                Console.WriteLine("\n---- Employee Management ----");
                Console.WriteLine("1. Insert Employee");
                Console.WriteLine("2. Show Employees");
                Console.WriteLine("3. Update Employee Salary (+1000)");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Employee emp = new Employee();

                        Console.Write("Enter Id: ");
                        emp.Id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        emp.Name = Console.ReadLine();

                        Console.Write("Enter Department: ");
                        emp.Department = Console.ReadLine();

                        Console.Write("Enter Salary: ");
                        emp.Salary = Convert.ToInt32(Console.ReadLine());

                        bool inserted = dal.InsertEmployee(emp);
                        Console.WriteLine(inserted ? "Inserted Successfully" : "Insert Failed");
                        break;

                    case 2:
                        List<Employee> list = dal.ShowEmployee();
                        if (list != null)
                        {
                            foreach (var e in list)
                            {
                                Console.WriteLine($"{e.Id} | {e.Name} | {e.Department} | {e.Salary}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Records Found");
                        }
                        break;

                    case 3:
                        Console.Write("Enter Id to Update: ");
                        int uid = Convert.ToInt32(Console.ReadLine());
                        bool updated = dal.UpdateEmployee(uid);
                        Console.WriteLine(updated ? "Updated Successfully" : "Update Failed");
                        break;

                    case 4:
                        Console.Write("Enter Id to Delete: ");
                        int did = Convert.ToInt32(Console.ReadLine());
                        bool deleted = dal.DeleteEmployee(did);
                        Console.WriteLine(deleted ? "Deleted Successfully" : "Delete Failed");
                        break;

                    case 5:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            } while (choice != 5);
        }

    }
}

