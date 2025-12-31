// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using LPU_BL;
using LPU_Entity;
using LPU_Exceptions;

namespace LPU_UI
{
    class Program
    {
        static void MainMenu()
        {
            Console.WriteLine("\n====== MAIN MENU ======");
            Console.WriteLine("1. Student Management System");
            Console.WriteLine("2. Book Management System");
            Console.WriteLine("3. Exit");
        }

        static void StudentMenu()
        {
             Console.WriteLine("    Student Management System    ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1.Search Student by ID");
            Console.WriteLine("2.Show All Students");
            Console.WriteLine("3.Add Student Detail");
            Console.WriteLine("4.Update Student Details");
            Console.WriteLine("5.Drop Student Details");
            Console.WriteLine("6.Exit");
        }

        static void StudentSystem()
        {
            StudentBL sblObj = new StudentBL();

            while (true)
            {
                StudentMenu();
                Console.Write("Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1: // Search by ID
                            Console.Write("Enter Student ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Student s = sblObj.SearchStudentByID(id);
                            Console.WriteLine($"{s.StudentID} | {s.Name} | {s.Course} | {s.Address}");
                            break;

                        case 2: // Search by Name
                            Console.Write("Enter Student Name: ");
                            string name = Console.ReadLine();
                            List<Student> list = sblObj.SearchStudentByName(name);
                            foreach (var stud in list)
                            {
                                Console.WriteLine($"{stud.StudentID} | {stud.Name} | {stud.Course} | {stud.Address}");
                            }
                            break;

                        case 3: // Add Student
                            Student newStud = new Student();
                            Console.Write("ID: ");
                            newStud.StudentID = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Name: ");
                            newStud.Name = Console.ReadLine();
                            Console.Write("Course: ");
                            newStud.Course = (CourseType)Enum.Parse(typeof(CourseType), Console.ReadLine());
                            Console.Write("Address: ");
                            newStud.Address = Console.ReadLine();

                            sblObj.EnrollStudent(newStud);
                            Console.WriteLine("Student Added Successfully");
                            break;

                        case 4: // Update Student
                            Console.Write("Enter Student ID to Update: ");
                            int uid = Convert.ToInt32(Console.ReadLine());

                            Student upd = new Student();
                            Console.Write("New Name: ");
                            upd.Name = Console.ReadLine();
                            Console.Write("New Course: ");
                            upd.Course = (CourseType)Enum.Parse(typeof(CourseType), Console.ReadLine());
                            Console.Write("New Address: ");
                            upd.Address = Console.ReadLine();

                            sblObj.UpdateStudentDetail(uid, upd);
                            Console.WriteLine("Student Updated");
                            break;

                        case 5: // Drop Student
                            Console.Write("Enter Student ID to Delete: ");
                            int did = Convert.ToInt32(Console.ReadLine());
                            sblObj.DropStudentDetails(did);
                            Console.WriteLine("Student Deleted");
                            break;

                        case 6:
                            return;
                    }
                }
                catch (LPUException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        static void BookMenu()
        {
            Console.WriteLine("    Book Management System    ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Show All Books");
            Console.WriteLine("2. Search Book by ISBN");
            Console.WriteLine("3. Add Book");
            Console.WriteLine("4. Update Book");
            Console.WriteLine("5. Delete Book");
            Console.WriteLine("6. Exit");
        }


        static void BookSystem()
        {
            BookBL bblObj = new BookBL();

            while (true)
            {
                BookMenu();
                Console.Write("Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1: // Show All Books
                            List<Book> books = bblObj.ShowAll();
                            Console.WriteLine("ISBN | Title | Author | Price");
                            Console.WriteLine("=================================");
                            foreach (var b in books)
                            {
                                Console.WriteLine($"{b.ISBNNo} | {b.Title} | {b.Author} | {b.Price}");
                            }
                            break;

                        case 2: // Search by ISBN
                            Console.Write("Enter ISBN No: ");
                            int isbn = Convert.ToInt32(Console.ReadLine());
                            Book book = bblObj.ShowDetailsByID(isbn);
                            Console.WriteLine($"{book.ISBNNo} | {book.Title} | {book.Author} | {book.Price}");
                            break;

                        case 3: // Add Book
                            Book newBook = new Book();
                            Console.Write("ISBN No: ");
                            newBook.ISBNNo = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Title: ");
                            newBook.Title = Console.ReadLine();
                            Console.Write("Author: ");
                            newBook.Author = Console.ReadLine();
                            Console.Write("Price: ");
                            newBook.Price = float.Parse(Console.ReadLine());

                            bblObj.AddDetails(newBook);
                            Console.WriteLine("Book Added Successfully");
                            break;

                        case 4: // Update Book
                            Console.Write("Enter ISBN No to Update: ");
                            int uid = Convert.ToInt32(Console.ReadLine());

                            Book updBook = new Book();
                            Console.Write("New Title: ");
                            updBook.Title = Console.ReadLine();
                            Console.Write("New Author: ");
                            updBook.Author = Console.ReadLine();
                            Console.Write("New Price: ");
                            updBook.Price = float.Parse(Console.ReadLine());

                            bblObj.UpdateDetails(uid, updBook);
                            Console.WriteLine("Book Updated Successfully");
                            break;

                        case 5: // Delete Book
                            Console.Write("Enter ISBN No to Delete: ");
                            int did = Convert.ToInt32(Console.ReadLine());
                            bblObj.DeleteDetails(did);
                            Console.WriteLine("Book Deleted Successfully");
                            break;

                        case 6:
                            return;
                    }
                }
                catch (BookException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        static void Main(string[] args)
        {
            while (true)
            {
                MainMenu();
                Console.Write("Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        StudentSystem();
                        break;

                    case 2:
                        BookSystem();
                        break;

                    case 3:
                        return;
                }
            }
        }
    }
}
