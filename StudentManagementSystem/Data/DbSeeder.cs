using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (!await context.Departments.AnyAsync())
        {
            context.Departments.AddRange(
                new Department { DepartmentName = "Computer Science", Description = "Software and computing studies" },
                new Department { DepartmentName = "Electronics", Description = "Electronics and communication studies" },
                new Department { DepartmentName = "Business Administration", Description = "Management and business studies" }
            );

            await context.SaveChangesAsync();
        }

        if (!await context.Courses.AnyAsync())
        {
            var csDept = await context.Departments.FirstAsync(d => d.DepartmentName == "Computer Science");
            var ecDept = await context.Departments.FirstAsync(d => d.DepartmentName == "Electronics");
            var mbaDept = await context.Departments.FirstAsync(d => d.DepartmentName == "Business Administration");

            context.Courses.AddRange(
                new Course
                {
                    CourseName = "ASP.NET Core Development",
                    Duration = "6 Months",
                    Fees = 35000,
                    DepartmentId = csDept.DepartmentId
                },
                new Course
                {
                    CourseName = "Data Structures and Algorithms",
                    Duration = "4 Months",
                    Fees = 28000,
                    DepartmentId = csDept.DepartmentId
                },
                new Course
                {
                    CourseName = "Embedded Systems",
                    Duration = "5 Months",
                    Fees = 32000,
                    DepartmentId = ecDept.DepartmentId
                },
                new Course
                {
                    CourseName = "Marketing Management",
                    Duration = "3 Months",
                    Fees = 25000,
                    DepartmentId = mbaDept.DepartmentId
                }
            );

            await context.SaveChangesAsync();
        }

        if (!await context.Students.AnyAsync())
        {
            var csDept = await context.Departments.FirstAsync(d => d.DepartmentName == "Computer Science");
            var ecDept = await context.Departments.FirstAsync(d => d.DepartmentName == "Electronics");

            var aspnetCourse = await context.Courses.FirstAsync(c => c.CourseName == "ASP.NET Core Development");
            var dsaCourse = await context.Courses.FirstAsync(c => c.CourseName == "Data Structures and Algorithms");
            var embeddedCourse = await context.Courses.FirstAsync(c => c.CourseName == "Embedded Systems");

            context.Students.AddRange(
                new Student
                {
                    StudentName = "Anita Sharma",
                    Email = "anita.student@sms.com",
                    PhoneNumber = "9876543210",
                    Address = "LPU Campus, Punjab",
                    DepartmentId = csDept.DepartmentId,
                    CourseId = aspnetCourse.CourseId
                },
                new Student
                {
                    StudentName = "Rahul Verma",
                    Email = "rahul.student@sms.com",
                    PhoneNumber = "9123456780",
                    Address = "Model Town, Ludhiana",
                    DepartmentId = csDept.DepartmentId,
                    CourseId = dsaCourse.CourseId
                },
                new Student
                {
                    StudentName = "Priya Nair",
                    Email = "priya.student@sms.com",
                    PhoneNumber = "9988776655",
                    Address = "Sector 22, Chandigarh",
                    DepartmentId = ecDept.DepartmentId,
                    CourseId = embeddedCourse.CourseId
                }
            );

            await context.SaveChangesAsync();
        }

        if (!await context.Users.AnyAsync())
        {
            context.Users.AddRange(
                new User
                {
                    FullName = "Teacher Admin",
                    Email = "teacher@sms.com",
                    Password = "Teacher@123",
                    Role = "Teacher"
                },
                new User
                {
                    FullName = "Anita Sharma",
                    Email = "anita.student@sms.com",
                    Password = "Student@123",
                    Role = "Student"
                },
                new User
                {
                    FullName = "Rahul Verma",
                    Email = "rahul.student@sms.com",
                    Password = "Student@123",
                    Role = "Student"
                },
                new User
                {
                    FullName = "Priya Nair",
                    Email = "priya.student@sms.com",
                    Password = "Student@123",
                    Role = "Student"
                }
            );

            await context.SaveChangesAsync();
        }
    }
}
