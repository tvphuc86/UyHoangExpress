using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LuanVan.Data;
using LuanVan.Model;

namespace LuanVan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuyensController : ControllerBase
    {
        private readonly MyDbContext _context;

        public QuyensController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Quyens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quyen>>> GetQuyens()
        {
          if (_context.Quyens == null)
          {
              return NotFound();
          }
            return await _context.Quyens.Include(m=>m.VaiTros).ToListAsync();
        }

        // GET: api/Quyens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quyen>> GetQuyen(int id)
        {
          if (_context.Quyens == null)
          {
              return NotFound();
          }
            var quyen = await _context.Quyens.FindAsync(id);

            if (quyen == null)
            {
                return NotFound();
            }

            return quyen;
        }

        // PUT: api/Quyens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuyen(int id, Quyen quyen)
        {
            if (id != quyen.MaQuyen)
            {
                return BadRequest();
            }

            _context.Entry(quyen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuyenExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Quyens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quyen>> PostQuyen(Quyen quyen)
        {
          if (_context.Quyens == null)
          {
              return Problem("Entity set 'MyDbContext.Quyens'  is null.");
          }
            _context.Quyens.Add(quyen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuyen", new { id = quyen.MaQuyen }, quyen);
        }

        // DELETE: api/Quyens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuyen(int id)
        {
            if (_context.Quyens == null)
            {
                return NotFound();
            }
            var quyen = await _context.Quyens.FindAsync(id);
            if (quyen == null)
            {
                return NotFound();
            }

            _context.Quyens.Remove(quyen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuyenExists(int id)
        {
            return (_context.Quyens?.Any(e => e.MaQuyen == id)).GetValueOrDefault();
        }
    }
}
