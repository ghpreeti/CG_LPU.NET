using System;
using System.Collections.Generic;
using System.Text;

namespace LINQConsoleApp
{
    public class StudentRepo
    {
        static List<Student> studList = null;
        public StudentRepo()
        {
            if(studList == null)
            {
                studList = new List<Student>()
                {
                    new Student(){ RollNo=1, Name="Alok", Marks=80,Gender="M",Fees=1500},
                    new Student(){ RollNo=2, Name="Riya", Marks=90,Gender="F",Fees=4500},
                    new Student(){ RollNo=3, Name="Ayush", Marks=75,Gender="M",Fees = 8900},
                    new Student(){ RollNo=4, Name="Yash", Marks=85,Gender="M",Fees=7800},
                    new Student(){ RollNo=5, Name="Ram", Marks=95,Gender="M",Fees=3400},
                };
            }
            
        }

        public List<Student> GetAllStudents()
        {
            return studList;
        }

    }
}
