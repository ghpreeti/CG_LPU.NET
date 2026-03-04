using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;

namespace StudentPortal.Repository
{
    public class StudentRepository : IStudentRepository
    {
       private readonly StudentPortalDbContext _db;
        public StudentRepository(StudentPortalDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Student student)
        {
            if(student != null)
            {
                var entry = _db.Students.Add(student);
                await _db.SaveChangesAsync();

            }
        }

        public async Task DeleteAsync(int id)
        {
            var query = await _db.Students.FindAsync(id);
            if (query!=null)
            {
                _db.Students.Remove(query);
                await _db.SaveChangesAsync();

            }
        }

        public async Task<bool> EmailExistsAsync(string email, int? ignoreStudentId = null)
        {
            var query = _db.Students.AsQueryable();
            if(!string.IsNullOrEmpty(email))
            {
                query = query.Where(s => s.Email == email && s.StudentId != ignoreStudentId);
            }

            return await query.AnyAsync();
        }

        public async Task<List<Student>> GetAllAsync(string p = null)
        {
            var query = _db.Students.AsQueryable();

            if (!string.IsNullOrEmpty(p))
            {
                query = query.Where(s =>
                    s.FullName.Contains(p) ||
                    s.Email.Contains(p) ||
                    s.Status.Contains(p)
                );
            }
            return await query.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            var query = await _db.Students.FindAsync(id);
            return query;
        }

        public async Task UpdateAsync(Student student)
        {
            _db.Students.Update(student);
            await _db.SaveChangesAsync();
        }
    }
}
