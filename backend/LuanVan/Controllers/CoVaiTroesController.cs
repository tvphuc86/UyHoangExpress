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
    public class CoVaiTroesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CoVaiTroesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/CoVaiTroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoVaiTro>>> GetCoVaiTros()
        {
          if (_context.CoVaiTros == null)
          {
              return NotFound();
          }
            return await _context.CoVaiTros.ToListAsync();
        }

        // GET: api/CoVaiTroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoVaiTro>> GetCoVaiTro(int id)
        {
          if (_context.CoVaiTros == null)
          {
              return NotFound();
          }
            var coVaiTro = await _context.CoVaiTros.FindAsync(id);

            if (coVaiTro == null)
            {
                return NotFound();
            }

            return coVaiTro;
        }

        // PUT: api/CoVaiTroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoVaiTro(int id, CoVaiTro coVaiTro)
        {
            if (id != coVaiTro.MaVaiTro)
            {
                return BadRequest();
            }

            _context.Entry(coVaiTro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoVaiTroExists(id))
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

        // POST: api/CoVaiTroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CoVaiTro>> PostCoVaiTro(CoVaiTro coVaiTro)
        {
          if (_context.CoVaiTros == null)
          {
              return Problem("Entity set 'MyDbContext.CoVaiTros'  is null.");
          }
            _context.CoVaiTros.Add(coVaiTro);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CoVaiTroExists(coVaiTro.MaVaiTro))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCoVaiTro", new { id = coVaiTro.MaVaiTro }, coVaiTro);
        }

        // DELETE: api/CoVaiTroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoVaiTro(int id)
        {
            if (_context.CoVaiTros == null)
            {
                return NotFound();
            }
            var coVaiTro = await _context.CoVaiTros.FindAsync(id);
            if (coVaiTro == null)
            {
                return NotFound();
            }

            _context.CoVaiTros.Remove(coVaiTro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoVaiTroExists(int id)
        {
            return (_context.CoVaiTros?.Any(e => e.MaVaiTro == id)).GetValueOrDefault();
        }
    }
}
