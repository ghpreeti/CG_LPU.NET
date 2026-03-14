using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers;

public class StudentController : Controller
{
    private readonly ApplicationDbContext _context;

    public StudentController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string? searchTerm, int? departmentId)
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");

        var query = _context.Students
            .Include(s => s.Department)
            .Include(s => s.Course)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(s => s.StudentName.Contains(searchTerm));
        }

        if (departmentId.HasValue)
        {
            query = query.Where(s => s.DepartmentId == departmentId.Value);
        }

        ViewBag.SearchTerm = searchTerm;
        ViewBag.DepartmentId = departmentId;
        ViewBag.DepartmentList = new SelectList(
            await _context.Departments.OrderBy(d => d.DepartmentName).ToListAsync(),
            "DepartmentId",
            "DepartmentName",
            departmentId);

        return View(await query.OrderBy(s => s.StudentName).ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");
        await LoadDropdowns();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Student student)
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");
        if (!ModelState.IsValid)
        {
            await LoadDropdowns(student.DepartmentId, student.CourseId);
            return View(student);
        }

        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");
        if (id is null) return NotFound();

        var student = await _context.Students.FindAsync(id);
        if (student is null) return NotFound();

        await LoadDropdowns(student.DepartmentId, student.CourseId);
        return View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Student student)
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");
        if (id != student.StudentId) return NotFound();

        if (!ModelState.IsValid)
        {
            await LoadDropdowns(student.DepartmentId, student.CourseId);
            return View(student);
        }

        _context.Students.Update(student);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");
        if (id is null) return NotFound();

        var student = await _context.Students
            .Include(s => s.Department)
            .Include(s => s.Course)
            .FirstOrDefaultAsync(s => s.StudentId == id);

        if (student is null) return NotFound();

        return View(student);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");

        var student = await _context.Students.FindAsync(id);
        if (student is not null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task LoadDropdowns(int? departmentId = null, int? courseId = null)
    {
        ViewBag.DepartmentId = new SelectList(
            await _context.Departments.OrderBy(d => d.DepartmentName).ToListAsync(),
            "DepartmentId",
            "DepartmentName",
            departmentId);

        ViewBag.CourseId = new SelectList(
            await _context.Courses.OrderBy(c => c.CourseName).ToListAsync(),
            "CourseId",
            "CourseName",
            courseId);
    }

    private bool IsTeacher() => HttpContext.Session.GetString("Role") == "Teacher";
}