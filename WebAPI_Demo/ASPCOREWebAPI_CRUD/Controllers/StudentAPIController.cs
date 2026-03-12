using ASPCOREWebAPI_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace ASPCOREWebAPI_CRUD.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly StudentPortalDbContext _context;

        public StudentAPIController(StudentPortalDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var students = await _context.Students.ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student stud)
        {
            await _context.Students.AddAsync(stud);
            await _context.SaveChangesAsync();
            return Ok(stud);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudentById(int id, Student stud)
        {
            if (id != stud.StudentId)
            {
                return BadRequest();
            }
            _context.Entry(stud).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(stud);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudentById(int id)
        {
            var std = await _context.Students.FindAsync(id);
            if (std == null) { 
              return NotFound();
            }
            _context.Students.Remove(std);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
