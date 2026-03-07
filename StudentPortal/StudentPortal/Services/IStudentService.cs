using StudentPortal.Models;

namespace StudentPortal.Services
{
    public interface IStudentService
    {
       Task<List<Student>> SearchAsync(string q = null);
        Task<Student?> SearchByIdAsync(int id);
        public Task AddAsync(Student student);
        public Task UpdateAsync(Student student);

        public Task DeleteAsync(int id);

    }
}
