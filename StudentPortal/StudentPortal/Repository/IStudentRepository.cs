using Microsoft.AspNetCore.Mvc;
using StudentPortal.Controllers;
using StudentPortal.Models;
using StudentPortal.Services;

namespace StudentPortal.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync(string p = null);
        Task<Student?> GetByIdAsync(int id);
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
        Task<bool> EmailExistsAsync(string email, int? ignoreStudentId = null);
    }
}

