using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.ViewModels;

namespace StudentManagementSystem.Controllers;

public class StudentDashboardController : Controller
{
    private readonly ApplicationDbContext _context;

    public StudentDashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        if (!IsStudent()) return RedirectToAction("Login", "Account");

        var profile = await GetStudentProfile();
        if (profile is null)
        {
            TempData["ErrorMessage"] = "Student profile not found. Please contact teacher.";
            return View(new StudentProfileViewModel());
        }

        return View(profile);
    }

    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        if (!IsStudent()) return RedirectToAction("Login", "Account");

        var profile = await GetStudentProfile();
        if (profile is null)
        {
            TempData["ErrorMessage"] = "Student profile not found. Please contact teacher.";
            return RedirectToAction(nameof(Index));
        }

        return View(profile);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Profile(StudentProfileViewModel model)
    {
        if (!IsStudent()) return RedirectToAction("Login", "Account");

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var email = HttpContext.Session.GetString("Email");
        var student = await _context.Students.FirstOrDefaultAsync(s => s.Email == email);
        if (student is null)
        {
            TempData["ErrorMessage"] = "Student profile not found.";
            return RedirectToAction(nameof(Index));
        }

        student.PhoneNumber = model.PhoneNumber;
        student.Address = model.Address;

        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Profile updated successfully.";

        return RedirectToAction(nameof(Profile));
    }

    private async Task<StudentProfileViewModel?> GetStudentProfile()
    {
        var email = HttpContext.Session.GetString("Email");
        if (string.IsNullOrEmpty(email)) return null;

        return await _context.Students
            .Where(s => s.Email == email)
            .Select(s => new StudentProfileViewModel
            {
                StudentId = s.StudentId,
                StudentName = s.StudentName,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                Address = s.Address,
                DepartmentName = s.Department != null ? s.Department.DepartmentName : string.Empty,
                CourseName = s.Course != null ? s.Course.CourseName : string.Empty,
                CourseDuration = s.Course != null ? s.Course.Duration : string.Empty,
                CourseFees = s.Course != null ? s.Course.Fees : 0
            })
            .FirstOrDefaultAsync();
    }

    private bool IsStudent() => HttpContext.Session.GetString("Role") == "Student";
}