
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ_Assignment_BoilerPlateCode.Repos;
using LINQ_Assignment_BoilerPlateCode.DTOs;
using LINQ_Assignment_BoilerPlateCode.Models;

namespace LINQ_Assignment_BoilerPlateCode
{
    class Program
    {
        static void Main(string[] args)
        {
            // =======================
            // SAMPLE DATA
            // =======================
            var employees = EmployeeRepo.SeedEmployees();
            var projects = ProjectRepo. SeedProjects();

            //Console.WriteLine("LINQ Scenario Boilerplate Loaded\n");
            //Console.WriteLine("===============SECTION 1================");
            //List<Employee> highEarners = GetHighEarningEmployees(employees);
            //foreach(var emp in highEarners)
            //{
            //    Console.WriteLine($"{emp.Name} : {emp.Salary}");
            //}
            //Console.WriteLine("---------------");
            //List<string> empNames = GetEmployeeNames(employees);
            //foreach (var emp in highEarners)
            //{
            //    Console.WriteLine($"{emp.Name}");
            //}
            //Console.WriteLine("---------------");
            //bool hasHR = HasHREmployees(employees);
            //Console.WriteLine($"Any HR Employees: {hasHR}\n");


            //Console.WriteLine("===============SECTION 2================");
            //List<DepartmentCount> deptCounts = GetDepartmentWiseCount(employees);
            //foreach(var dept in deptCounts)
            //{
            //    Console.WriteLine($"{dept.Department} : {dept.Count}");
            //}
            //Console.WriteLine("---------------");
            //Employee highestPaid = GetHighestPaidEmployee(employees);
            //Console.WriteLine($"Highest Paid Employee: {highestPaid.Name} : {highestPaid.Salary}");
            //Console.WriteLine("---------------");
            //List<Employee> sortedEmployees = SortEmployeesBySalaryAndName(employees);
            //foreach(var emp in sortedEmployees)
            //{
            //    Console.WriteLine($"{emp.Name} : {emp.Salary}");
            //}


            //Console.WriteLine("===============SECTION 3================");
            //List<Employee> unassignedEmployees = GetUnassignedEmployees(employees, projects);   
            //foreach(var emp in unassignedEmployees)
            //{
            //    Console.WriteLine($"{emp.Name}");
            //}
            //Console.WriteLine("---------------");
            //List<string> uniqueSkills = GetAllUniqueSkills(employees);
            //foreach(var skill in uniqueSkills)
            //{
            //    Console.WriteLine($"{skill}");
            //}

            Console.WriteLine("===============SECTION 4================");
            List<DepartmentTopEmployees> topEarnersByDept = GetTopEarnersByDepartment(employees);
            foreach(var dept in topEarnersByDept)
            {
                Console.WriteLine($"Department: {dept.Department}");
                foreach(var emp in dept.TopEmployees)
                {
                    Console.WriteLine($" {emp.Name} salary: {emp.Salary}");
                }
            }
            Console.WriteLine("---------------");
            List<Employee> nonDuplicateEmployees = RemoveDuplicateEmployees(employees);
            foreach(var emp in nonDuplicateEmployees)
            {
                Console.WriteLine($"{emp.Id} : {emp.Name}");
            }   




        }

        // =====================================================
        // 🟢 SECTION 1 – HR ANALYTICS
        // =====================================================

        // TODO 1.1: Get employees earning more than 60,000
        static List<Employee> GetHighEarningEmployees(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            List<Employee> empList = new List<Employee>();
            var query1_1 = employees.Where(e => e.Salary > 60000).ToList();
            foreach (var emp in query1_1)
            {
                empList.Add(emp);
            }
            return empList;
            //throw new NotImplementedException();
        }

        // TODO 1.2: Get list of employee names only
        static List<string> GetEmployeeNames(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            List<string> empNames = new List<string>();
            var query1_2 = employees.Select(n=>n.Name).ToList();
            foreach (var name in query1_2)
            {
                empNames.Add(name);
            }
            return empNames;
            //throw new NotImplementedException();
        }

        // TODO 1.3: Check if any employee belongs to HR department
        static bool HasHREmployees(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            bool flag = false;
            var query1_3 = employees.Any(d => d.Department == "HR");
            if (query1_3)
            {
                flag = true;
            }
            return flag;
            
            //throw new NotImplementedException();
        }

        // =====================================================
        // 🟡 SECTION 2 – MANAGEMENT INSIGHTS
        // =====================================================

        // TODO 2.1: Get department-wise employee count
        static List<DepartmentCount> GetDepartmentWiseCount(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            List<DepartmentCount> empDeptCount = new List<DepartmentCount>();
            var query2_1 = employees.GroupBy(d=>d.Department).ToList();
            foreach(var group in query2_1)
            {
                empDeptCount.Add(new DepartmentCount{ Department = group.Key , Count = group.Count()});
            }
            return empDeptCount; 
            //throw new NotImplementedException();
        }

        // TODO 2.2: Find the highest paid employee
        static Employee GetHighestPaidEmployee(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            var query2_2 = employees.OrderByDescending(s => s.Salary).FirstOrDefault();
            return query2_2;
            //throw new NotImplementedException();
        }

        // TODO 2.3: Sort employees by Salary (DESC), then Name (ASC)
        static List<Employee> SortEmployeesBySalaryAndName(List<Employee> employees)
        {
            // TODO: Write LINQ query here
           return employees.OrderByDescending(s => s.Salary).ThenBy(n => n.Name).ToList();
            //throw new NotImplementedException();
        }

        // =====================================================
        // 🔵 SECTION 3 – PROJECT & SKILL INTELLIGENCE
        // =====================================================

        // TODO 3.1: Join employees with projects
        //static List<EmployeeProject> GetEmployeeProjectMappings(
        //    List<Employee> employees,
        //    List<Project> projects)
        //{
        //    // TODO: Write LINQ query here
        //    List<EmployeeProject> empProj = new List<EmployeeProject>();

        //    var query3_1 = employees.Join(projects,e=>e.Id,projects.Where(p=>p.ProjectId),).ToList();
            
        //     return empProj;
        //    //throw new NotImplementedException();
        //}

        // TODO 3.2: Find employees who are NOT assigned to any project
        static List<Employee> GetUnassignedEmployees(
            List<Employee> employees,
            List<Project> projects)
        {
            // TODO: Write LINQ query here
            List<Employee> benchEmp = new List<Employee>();
            var query3_2 = employees.Where(e => !projects.Any(p => p.EmployeeId == e.Id)).ToList();
            foreach(var emp in query3_2)
            {
                benchEmp.Add(emp);
            }
            return benchEmp;
            //throw new NotImplementedException();
        }

        // TODO 3.3: Get all unique skills across the organization
        static List<string> GetAllUniqueSkills(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            
             return employees.SelectMany(s=>s.Skills).Distinct().ToList();
            //throw new NotImplementedException();
        }

        // =====================================================
        // 🔴 SECTION 4 – ADVANCED WORKFORCE ANALYTICS
        // =====================================================

        // TODO 4.1: Get top 3 highest-paid employees per department
        static List<DepartmentTopEmployees> GetTopEarnersByDepartment(
            List<Employee> employees)
        {
            // TODO: Write LINQ query here
            List<DepartmentTopEmployees> highPaidEmp = new List<DepartmentTopEmployees>();
            var query4_1 = employees.GroupBy(d => d.Department).ToList();
            
            foreach(var group in query4_1)
            {
                var top = group.OrderByDescending(s => s.Salary).Take(3).ToList();
                
               
                    highPaidEmp.Add( new DepartmentTopEmployees { Department = group.Key, TopEmployees = top });
                
            }
            return highPaidEmp;
            //throw new NotImplementedException();
        }

        // TODO 4.2: Remove duplicate employees based on Id
        static List<Employee> RemoveDuplicateEmployees(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            List<Employee> nonRetundentEmp = new List<Employee>();
            var query4_2 = employees.GroupBy(i => i.Id).Distinct();
            
            foreach(var e in query4_2)
            {
                nonRetundentEmp.Add(e.First());
            }
            return nonRetundentEmp;
            //throw new NotImplementedException();
        }

        // TODO 4.3: Implement pagination
        //static List<Employee> GetEmployeesByPage(
        //    List<Employee> employees,
        //    int pageNumber,
        //    int pageSize = 5)
        //{
        //    // TODO: Write LINQ query here
        //    List<Employee> page = new List<Employee>();
        //    var query4_3 = employees.Where(e=>e.).Take(pageSize).ToList();
        //    //throw new NotImplementedException();
        //}


    }
}
