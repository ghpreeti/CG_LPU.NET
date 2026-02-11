using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace University_Course_Registration_System
{
     // =========================
    // Program (Menu-Driven)
    // =========================
    class Program
    {
        static void Main()
        {
            UniversitySystem system = new UniversitySystem();
            bool exit = false;

            Console.WriteLine("Welcome to University Course Registration System");

            while (!exit)
            {
                Console.WriteLine("\n1. Add Course");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Register Student for Course");
                Console.WriteLine("4. Drop Student from Course");
                Console.WriteLine("5. Display All Courses");
                Console.WriteLine("6. Display Student Schedule");
                Console.WriteLine("7. Display System Summary");
                Console.WriteLine("8. Exit");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                try
                {
                    // TODO:
                    // Implement menu handling logic using switch-case
                    // Prompt user inputs
                    // Call appropriate UniversitySystem methods

                    switch(choice){

                        case "1":
                            Console.Write("Course Code: ");
                            string code = Console.ReadLine();
                            Console.Write("Course Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Credits: ");
                            int credits = int.Parse(Console.ReadLine());

                            system.AddCourse(code, name, credits);
                            break;

                        case "2":
                            option2(system);
                            break;

                        case "3":
                            option3(system);
                            break;

                        case "4":
                            Console.Write("Student ID: ");
                            string dropStudentId = Console.ReadLine();
                            Console.Write("Course Code: ");
                            string dropCourseCode = Console.ReadLine();
                            if(system.DropStudentFromCourse(dropStudentId, dropCourseCode))
                                Console.WriteLine("Drop successful.");
                            else
                                Console.WriteLine("Drop failed.");
                            break;

                        case "5":
                            system.DisplayAllCourses();
                            break;

                        case "6":
                            Console.Write("Student ID: ");
                            string scheduleStudentId = Console.ReadLine();
                            system.DisplayStudentSchedule(scheduleStudentId);
                            break;

                        case "7":
                            system.DisplaySystemSummary();
                            break;

                        case "8":
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private static void option2(UniversitySystem system)
        {
            Console.Write("Student ID: ");
            string id = Console.ReadLine();
            Console.Write("Student Name: ");
            string studentName = Console.ReadLine();
            Console.Write("Major: ");
            string major = Console.ReadLine();
            system.AddStudent(id, studentName, major);
            return;
        }

        private static void option3(UniversitySystem system)
        {
            Console.Write("Student ID: ");
            string studentId = Console.ReadLine();
            Console.Write("Course Code: ");
            string courseCode = Console.ReadLine();
            if (system.RegisterStudentForCourse(studentId, courseCode))
                Console.WriteLine("Registration successful.");
            else
                Console.WriteLine("Registration failed.");
        }
    }
}

