using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ourReactProject.Models;


namespace ourReactProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        // Database connection
        private readonly StudentDBContext _context;

        // Constructor
        public StudentController(StudentDBContext context)
        {
            _context = context;
        }

        // GET - Get all students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }


        // POST - Add new student
        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return Ok("Student added successfully!");
        }
        [HttpPatch("(id)")]
        public async Task<ActionResult> UpdateStudent(int id,Student student)
        {
            var existingstudent = await _context.Students.FindAsync(id);
            if (existingstudent == null)
                return NotFound();

            existingstudent.Name = student.Name;
            existingstudent.Course = student.Course;

            await _context.SaveChangesAsync();

            return Ok(existingstudent);
        }
        [HttpDelete("(id)")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return Ok("Deleted Successfully");
        }
        [HttpPatch("(name)")]
        public async Task<ActionResult> UdateStudent(String name ,Student student)
        {
            var existingstudent = await _context.Students.FirstOrDefaultAsync(s=> s.Name == name);
            if (existingstudent == null)
                return NotFound();

            existingstudent.Name= student.Name;
            existingstudent.Course = student.Course;

            await _context.SaveChangesAsync();

            return Ok(existingstudent);
        }
        [HttpDelete("(name/{name})")]
        public async Task<ActionResult> DeleteStudentByName(string name)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Name == name);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return Ok("Deleted Successfully");
        }
    }
}
