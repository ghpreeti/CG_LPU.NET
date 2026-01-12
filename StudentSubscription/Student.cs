using System;
using System.Collections.Generic;


namespace StudentSubscription
{
    public delegate bool IsStudentEligibleForScholship(Student std);
    public class Student
    {
       
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }
        public char SportsGrade { get; set; }
    

    public static string GetEligibleStudents(List<Student> studentList, IsStudentEligibleForScholship isEligible)
        {
            List<string> eligible = new List<string>();
            foreach (Student item in studentList)
            {
                if (isEligible(item))
                {
                    eligible.Add(item.Name);
                }
            }
            return string.Join(", ", eligible);


        }
    }
}
