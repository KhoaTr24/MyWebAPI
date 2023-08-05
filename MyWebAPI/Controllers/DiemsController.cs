using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data.Contexts;
using MyWebAPI.Data.Entities;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiemsController : ControllerBase
    {
        private readonly StudentsDBContext _context;
       
        public DiemsController(StudentsDBContext context)
        {
            _context = context;
        }

        // GET ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diem>>> GetDiem()
        {
            if (_context.Diem == null)
            {
                return NotFound();
            }
            var diems = await _context.Diem.ToListAsync();
            return Ok(diems);
        }
        // GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Diem>> GetDiem(int id)
        {
            var diems = await _context.Diem.FindAsync(id);
            return diems == null ? NotFound() : Ok(diems);
        }
        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiem(int id, Diem diem)
        {
            if (id == diem.Id)
            {
                _context.Diem.Update(diem);
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound(diem);
            }
            return Ok(diem);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Diem>> PostDiem(Diem diem)
        {
          if (_context.Diem == null)
          {
              return Problem("Entity set 'StudentsDBContext.Diem'  is null.");
          }
            _context.Diem.Add(diem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiem", new { id = diem.Id }, diem);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiem(int id)
        {
            var diem = await _context.Diem.FindAsync(id);
            if (_context.Diem == null)
            {
                return NotFound();
            }
            if (diem == null)
            {
                return NotFound();
            }
            _context.Diem.Remove(diem);
            await _context.SaveChangesAsync();
            var d = await _context.Diem.ToListAsync();
            return Ok(d);
        }
    }
}
