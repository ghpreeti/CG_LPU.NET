using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Models;

public class Course
{
    [Key]
    public int CourseId { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Course Name")]
    public string CourseName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    [Display(Name = "Course Duration")]
    public string Duration { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0, 999999)]
    [Display(Name = "Course Fees")]
    public decimal Fees { get; set; }

    [Required]
    [Display(Name = "Department")]
    public int DepartmentId { get; set; }

    public Department? Department { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();
}