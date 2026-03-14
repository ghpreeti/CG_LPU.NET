using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers;

public class DepartmentController : Controller
{
    private readonly ApplicationDbContext _context;

    public DepartmentController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");
        return View(await _context.Departments.OrderBy(d => d.DepartmentName).ToListAsync());
    }

    public IActionResult Create()
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Department department)
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");
        if (!ModelState.IsValid) return View(department);

        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");
        if (id is null) return NotFound();

        var department = await _context.Departments.FindAsync(id);
        if (department is null) return NotFound();

        return View(department);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Department department)
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");
        if (id != department.DepartmentId) return NotFound();
        if (!ModelState.IsValid) return View(department);

        _context.Departments.Update(department);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");
        if (id is null) return NotFound();

        var department = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == id);
        if (department is null) return NotFound();

        return View(department);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (!IsTeacher()) return RedirectToAction("Login", "Account");

        var hasDependencies = await _context.Courses.AnyAsync(c => c.DepartmentId == id) ||
                              await _context.Students.AnyAsync(s => s.DepartmentId == id);
        if (hasDependencies)
        {
            TempData["ErrorMessage"] = "Cannot delete department because it is linked with courses or students.";
            return RedirectToAction(nameof(Index));
        }

        var department = await _context.Departments.FindAsync(id);
        if (department is not null)
        {
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool IsTeacher() => HttpContext.Session.GetString("Role") == "Teacher";
}