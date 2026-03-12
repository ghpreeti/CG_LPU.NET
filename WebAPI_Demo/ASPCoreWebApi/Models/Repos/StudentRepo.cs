using System.Linq;

namespace ASPCoreWebApi.Models.Repos
{
    public class StudentRepo : IRepo<Student>
    {
        public static List<Student> students = null;
        public StudentRepo()
        {
            if (students == null)
            {
                students = new List<Student>();
                students.Add(new Student() { RollNo = 1, Name = "John Doe", City = "New York", PhoneNo = "1234567890" });
                students.Add(new Student() { RollNo = 2, Name = "Jane Smith", City = "Los Angeles", PhoneNo = "9876543210" });
                students.Add(new Student() { RollNo = 3, Name = "Alice Johnson", City = "Chicago", PhoneNo = "5555555555" });
                students.Add(new Student() { RollNo = 4, Name = "Bob Brown", City = "Houston", PhoneNo = "1111111111" });
                students.Add(new Student() { RollNo = 5, Name = "Charlie Davis", City = "Phoenix", PhoneNo = "2222222222" });
            }
        }
        public bool Add(Student item)
        {
            bool flag = false;
            if(item != null)
            {
                students.Add(item);
                flag = true;
            }
            return flag;
        }

        public bool Delete(int id)
        {
            bool flag = false;
            var student = students.Find(s => s.RollNo == id);
            if (student != null)
            {
                students.Remove(student);
                flag = true;
            }
            return flag;
        }

        public Student Get(int id)
        {
           var student = students.Find(s => s.RollNo == id);
            return student;
        }

        public ICollection<Student> GetAll()
        {
            return students;
        }

        public bool Update(int id, Student item)
        {
            bool flag = false;
            var student = students.Find(s => s.RollNo == id);
            if (student != null && item != null)
            {
                student.Name = item.Name;
                student.City = item.City; 
                student.PhoneNo = item.PhoneNo;
                flag = true;
            }
            return flag;
        }
    }
}
