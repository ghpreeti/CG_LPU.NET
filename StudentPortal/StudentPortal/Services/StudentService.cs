using StudentPortal.Models;
using StudentPortal.Repository;

namespace StudentPortal.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Student>> SearchAsync(string q = null) => _repo.GetAllAsync(q);

        public Task<Student?> SearchByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Student student) => _repo.AddAsync(student);

        public Task UpdateAsync(Student student)=> _repo.UpdateAsync(student);

        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);   




    }
}
