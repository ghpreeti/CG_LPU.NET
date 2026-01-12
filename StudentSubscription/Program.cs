// See https://aka.ms/new-console-template for more information
using System;
using StudentSubscription;


class Program
{
    public static bool ScholarshipElidibility(Student std)
    {
        return std.Marks > 80 && std.SportsGrade == 'A';
    }
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>
        {
            new Student { RollNo = 1, Name = "Rahul", Marks = 85, SportsGrade = 'A' },
            new Student { RollNo = 2, Name = "Neha", Marks = 78, SportsGrade = 'A' },
            new Student { RollNo = 3, Name = "Amit", Marks = 90, SportsGrade = 'B' },
            new Student { RollNo = 4, Name = "Sneha", Marks = 92, SportsGrade = 'A' }
        };

        // Assign method to delegate

        IsStudentEligibleForScholship del = ScholarshipElidibility;

        string result = Student.GetEligibleStudents(students, del);

        Console.WriteLine(result);
    }
}
