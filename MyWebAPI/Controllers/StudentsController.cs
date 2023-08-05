using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data.Contexts;
using MyWebAPI.Data.Entities;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsDBContext _context;

        public StudentsController(StudentsDBContext context)
        {
            _context = context;
        }

        // GET ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Students>>> GetStudents()
        {
          if (_context.Students == null)
          {
              return NotFound();
          }
            return await _context.Students.ToListAsync();
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Students>> GetStudents(int id)
        {
            var students = await _context.Students.FindAsync(id);
            return students == null?NotFound():Ok(students);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudents(int id, Students students)
        {
            if (id == students.Id)
            {
                _context.Students.Update(students);
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound(students);
            }
            return Ok(students);

        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Students>> PostStudents(Students students)
        {
          if (_context.Students == null)
          {
              return Problem("Entity set 'StudentsDBContext.Students'  is null.");
          }
            _context.Students.Add(students);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudents", new { id = students.Id }, students);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudents(int id)
        {
            var studentDelete = await _context.Students.FindAsync(id);
            if (_context.Students == null)
            {
                return NotFound();
            }
            if (studentDelete == null)
            {
                return NotFound();
            }
            _context.Students.Remove(studentDelete);
            await _context.SaveChangesAsync();
            var x = await _context.Students.ToListAsync();
            return Ok(x);
        }
    }
}
