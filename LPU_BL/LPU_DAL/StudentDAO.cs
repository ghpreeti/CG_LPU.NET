using System;
using LPU_Common;
using LPU_Entity;
using LPU_Exceptions;

namespace LPU_DAL
{
    /// <summary>
    /// student DAO class is used for CRUD operation
    /// </summary>
    public class StudentDAO : IStudentCRUD
    {
        static List<Student> studentList = null;

        public StudentDAO()
        {
            //Collection Init
            studentList = new List<Student>()
            {
               
                new Student(){ StudentID = 101, Name = "Alok",   Course = CourseType.CSE, Address = "Chandigarh" },
                new Student(){ StudentID = 102, Name = "Preeti", Course = CourseType.IT,  Address = "Delhi" },
                new Student(){ StudentID = 103, Name = "Rahul",  Course = CourseType.CSE, Address = "Noida" },
                new Student(){ StudentID = 104, Name = "Sneha",  Course = CourseType.CSE, Address = "Pune" },
                new Student(){ StudentID = 105, Name = "Amit",   Course = CourseType.Civil,  Address = "Jaipur" },
                new Student(){ StudentID = 106, Name = "Neha",   Course = CourseType.IT,  Address = "Bangalore" }

            };
        }





        public bool DropStudentDetails(int id)
        {
            throw new NotImplementedException();
        }

        public bool EnrollStudent(Student sObj)
        {
            bool flag = false;
            if(sObj != null)
            {
                studentList.Add(sObj);
                flag = true;
            }
            return flag;
        }

        public Student SearchStudentByID(int rollNo)
        {
            
            Student myStud = null;
            if (rollNo != 0)
            {
                myStud = studentList.Find(s => s.StudentID == rollNo);
                if (myStud == null)
                {
                    throw new LPUException("student not found");
                }
            }
            else
            {
                throw new LPUException("Error Generated...");
            }

            return myStud;
        }

        public List<Student> SearchStudentByName(string name)
        {
            List<Student> data = studentList.FindAll(p => p.Name == name);
            return data;
        }

        public bool UpdateStudentDetail(int id, Student newObj)
        {
            throw new NotImplementedException();
        }
    }
}
