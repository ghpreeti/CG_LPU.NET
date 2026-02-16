using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConArchDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentDAL sObj = new StudentDAL();
            //List<Student> stu = sObj.ShowAllStudent();

            List<Student> stu = sObj.ShowStudentbyName("Aliya");

            foreach (Student s in stu) { 
             Console.WriteLine($"{s.Name} : {s.RollNo} : {s.Address} : {s.PhoneNo} ");
            }

        }
    }
}
