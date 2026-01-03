using System;
using System.Collections.Generic;

namespace CollectionsDemo
{
    public class Program
    {
        public static void ArrayDemoFuncPrimitive()
        {
            string[] array = { "John", "lily", "akash", "ruhi" };
            Array.Sort(array);

            Console.WriteLine("Sorted String Array:");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        public static void ListDemoFuncCustom()
        {
            EmployeeRepo empRepo = new EmployeeRepo();

            Employee[] empArray = empRepo.GetEmployeeArray();

            Array.Sort(empArray);

            Console.WriteLine("\nSorted Employee Array (by ID):");
            foreach (var emp in empArray)
            {
                Console.WriteLine($"{emp.ID} | {emp.Name} | {emp.Salary} | {emp.Exp}");
            }
        }

        public static void DemoFuncForIEnumerable()
        {
            Player p1 = new Player();
            p1.Name = "Gill";
            p1.MySkill = new Skill[]
            {
                new Skill(){ SkillID=1, SkillName="Batsman"},
                new Skill(){ SkillID=2, SkillName="Bowler"},
                new Skill(){ SkillID=3, SkillName="Fielder"}
            };

            Console.WriteLine("\nPlayer Skills:");
            foreach (var skill in p1)
            {
                Console.WriteLine($"{skill.SkillID} - {skill.SkillName}");
            }
        }

        static void Main()
        {
            //ArrayDemoFuncPrimitive();
            //ListDemoFuncCustom();
            DemoFuncForIEnumerable();

            Dictionary<int, Employee> empDictionary = new Dictionary<int, Employee>();
            empDictionary.Add(1, new Employee() { ID = 1, Name = "abc", Salary = 12000, Exp = 3 });

            Employee emp1 = new Employee() { ID = 2, Name = "xyz", Salary = 15000, Exp = 4 };
            Employee emp2 = new Employee() { ID = 3, Name = "pqr", Salary = 18000, Exp = 5 };

            empDictionary.Add(emp1.ID, emp1);
            empDictionary.Add(emp2.ID, emp2);

            Console.WriteLine("\nDictionary Data:");
            foreach (var item in empDictionary)
            {
                Console.WriteLine($"{item.Key} => {item.Value.Name}");
            }
        }
    }
}
