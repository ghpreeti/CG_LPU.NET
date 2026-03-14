using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers;

public class CourseController : Controller
{
    private readonly ApplicationDbContext _context;

    public CourseController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");

        var courses = await _context.Courses
            .Include(c => c.Department)
            .OrderBy(c => c.CourseName)
            .ToListAsync();

        return View(courses);
    }

    public async Task<IActionResult> Create()
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");
        await LoadDepartments();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Course course)
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");
        if (!ModelState.IsValid)
        {
            await LoadDepartments(course.DepartmentId);
            return View(course);
        }

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");
        if (id is null) return NotFound();

        var course = await _context.Courses.FindAsync(id);
        if (course is null) return NotFound();

        await LoadDepartments(course.DepartmentId);
        return View(course);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Course course)
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");
        if (id != course.CourseId) return NotFound();

        if (!ModelState.IsValid)
        {
            await LoadDepartments(course.DepartmentId);
            return View(course);
        }

        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");
        if (id is null) return NotFound();

        var course = await _context.Courses
            .Include(c => c.Department)
            .FirstOrDefaultAsync(c => c.CourseId == id);

        if (course is null) return NotFound();

        return View(course);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");

        var hasStudents = await _context.Students.AnyAsync(s => s.CourseId == id);
        if (hasStudents)
        {
            TempData["ErrorMessage"] = "Cannot delete course because students are linked to it.";
            return RedirectToAction(nameof(Index));
        }

        var course = await _context.Courses.FindAsync(id);
        if (course is not null)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task LoadDepartments(int? selectedDepartment = null)
    {
        ViewBag.DepartmentId = new SelectList(
            await _context.Departments.OrderBy(d => d.DepartmentName).ToListAsync(),
            "DepartmentId",
            "DepartmentName",
            selectedDepartment);
    }

    private bool IsTeacher() => HttpContext.Session.GetString("Role") == "Teacher";
}