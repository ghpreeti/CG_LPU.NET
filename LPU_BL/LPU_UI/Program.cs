// See https://aka.ms/new-console-template for more information
using LPU_Entity;
using System;
using LPU_BL;
using LPU_Entity;
using LPU_Exceptions;

namespace LPU_UI
{
    class Program
    {
        static void Menu()
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
        static void Main(string[] args)
        {
            StudentBL sblObj = null;
            sblObj = new StudentBL();
            do
            {
                Menu();
                int choice = 0;
                Console.WriteLine("Please Enter Your Choice : ");
                choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: //Search student by id
                        {
                            int id = 0;
                            try
                            {
                                Console.Write("\tEnter Student Id: ");
                                id = Convert.ToInt32(Console.ReadLine());

                                Student sObj = sblObj.SearchStudentByID(id);
                                if (sObj != null)
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("ID\t| Name\t| Course\t| Address\t");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("=================================");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"{sObj.StudentID}\t|{sObj.Name}\t|{sObj.Course}\t|{sObj.Address}") ;
                                    Console.ForegroundColor = ConsoleColor.White;

                                }
                            }
                            catch (LPUException e)
                            {
                                Console.WriteLine(e.Message);
                            }catch(Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case 2://Show All Stud
                        {
                            try
                            {
                                Console.Write("\tEnter Student Id: ");
                                string name = Console.ReadLine();

                                List<Student> studList = sblObj.SearchStudentByName(name);
                                if (studList != null)
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("ID\t| Name\t| Course\t| Address\t");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("=================================");
                                    foreach (var stud in studList)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine($"{stud.StudentID}\t|{stud.Name}\t|{stud.Course}\t|{stud.Address}");
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }


                                }
                            }
                            catch(LPUException e)
                            {
                                Console.WriteLine("Error");
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine("Error");
                            }

                            break;
                        }
                    case 3://Add details
                        {
                            break;
                        }
                    case 4://Modify dtud detail
                        {
                            break;
                        }
                    case 5://Drop student detail
                        {
                            break;
                        }
                    case 6://exit
                        {
                            return;
                        }
                    default:
                        break;
                }

            } while (true);
        }
    }
}
