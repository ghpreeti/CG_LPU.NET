using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.ViewModels;

public class StudentProfileViewModel
{
    public int StudentId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    [Required]
    [Phone]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;

    public string DepartmentName { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public string CourseDuration { get; set; } = string.Empty;
    public decimal CourseFees { get; set; }
}