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
    public class VaiTroesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public VaiTroesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/VaiTroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaiTro>>> GetVaiTros()
        {
          if (_context.VaiTros == null)
          {
              return NotFound();
          }
            return await _context.VaiTros.ToListAsync();
        }

        // GET: api/VaiTroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VaiTro>> GetVaiTro(int id)
        {
          if (_context.VaiTros == null)
          {
              return NotFound();
          }
            var vaiTro = await _context.VaiTros.FindAsync(id);

            if (vaiTro == null)
            {
                return NotFound();
            }

            return vaiTro;
        }

        // PUT: api/VaiTroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaiTro(int id, VaiTro vaiTro)
        {
            if (id != vaiTro.MaVaiTro)
            {
                return BadRequest();
            }

            _context.Entry(vaiTro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaiTroExists(id))
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

        // POST: api/VaiTroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VaiTro>> PostVaiTro(VaiTro vaiTro)
        {
          if (_context.VaiTros == null)
          {
              return Problem("Entity set 'MyDbContext.VaiTros'  is null.");
          }
            _context.VaiTros.Add(vaiTro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVaiTro", new { id = vaiTro.MaVaiTro }, vaiTro);
        }

        // DELETE: api/VaiTroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaiTro(int id)
        {
            if (_context.VaiTros == null)
            {
                return NotFound();
            }
            var vaiTro = await _context.VaiTros.FindAsync(id);
            if (vaiTro == null)
            {
                return NotFound();
            }

            _context.VaiTros.Remove(vaiTro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VaiTroExists(int id)
        {
            return (_context.VaiTros?.Any(e => e.MaVaiTro == id)).GetValueOrDefault();
        }
    }
}
