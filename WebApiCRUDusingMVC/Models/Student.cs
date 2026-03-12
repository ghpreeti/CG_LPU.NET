namespace WebApiCRUDusingMVC.Models
{
    

    public class Student
    {
        public int StudentId { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public string Status { get; set; } = null!;

        public DateOnly JoinDate { get; set; }

        public DateTime CreatedAt { get; set; }
        public object[] enrollments { get; set; } = new object[0];
        public object[] tblLogs { get; set; } = new object[0];
    }

    }

