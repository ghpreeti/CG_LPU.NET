using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models;

public class Department
{
    [Key]
    public int DepartmentId { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Department Name")]
    public string DepartmentName { get; set; } = string.Empty;

    [StringLength(300)]
    public string? Description { get; set; }

    public ICollection<Course> Courses { get; set; } = new List<Course>();
    public ICollection<Student> Students { get; set; } = new List<Student>();
}