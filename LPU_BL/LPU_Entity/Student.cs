namespace LPU_Entity
{
    public enum CourseType
    {
        Mechanical = 010,
        Electrical = 020,
        Civil = 030,
        CSE = 040,
        IT = 050
    }
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public CourseType Course { get; set; } //PROPERTY OF TYPE enum
    }
}
