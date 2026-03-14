using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models;

public class Student
{
    [Key]
    public int StudentId { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Student Name")]
    public string StudentName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(150)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Phone]
    [Display(Name = "Phone Number")]
    [StringLength(15)]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(300)]
    public string Address { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Department")]
    public int DepartmentId { get; set; }

    [Required]
    [Display(Name = "Course")]
    public int CourseId { get; set; }

    public Department? Department { get; set; }
    public Course? Course { get; set; }
}