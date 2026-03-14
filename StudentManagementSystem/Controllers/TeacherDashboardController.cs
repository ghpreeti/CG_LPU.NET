using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;

namespace StudentManagementSystem.Controllers;

public class TeacherDashboardController : Controller
{
    private readonly ApplicationDbContext _context;

    public TeacherDashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        if (HttpContext.Session.GetString("Role") != "Teacher")
        {
            return RedirectToAction("Login", "Account");
        }

        ViewBag.DepartmentCount = await _context.Departments.CountAsync();
        ViewBag.CourseCount = await _context.Courses.CountAsync();
        ViewBag.StudentCount = await _context.Students.CountAsync();

        ViewBag.StudentsPerDepartment = await _context.Departments
            .Select(d => new
            {
                DepartmentName = d.DepartmentName,
                StudentCount = d.Students.Count
            })
            .OrderBy(x => x.DepartmentName)
            .ToListAsync();

        return View();
    }
}