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
    public class ChiTietVaiTroesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ChiTietVaiTroesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/ChiTietVaiTroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietVaiTro>>> GetChiTietVaiTros()
        {
          if (_context.ChiTietVaiTros == null)
          {
              return NotFound();
          }
            return await _context.ChiTietVaiTros.ToListAsync();
        }

        // GET: api/ChiTietVaiTroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietVaiTro>> GetChiTietVaiTro(int id)
        {
          if (_context.ChiTietVaiTros == null)
          {
              return NotFound();
          }
            var chiTietVaiTro = await _context.ChiTietVaiTros.FindAsync(id);

            if (chiTietVaiTro == null)
            {
                return NotFound();
            }

            return chiTietVaiTro;
        }

        // PUT: api/ChiTietVaiTroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietVaiTro(int id, ChiTietVaiTro chiTietVaiTro)
        {
            if (id != chiTietVaiTro.MaQuyen)
            {
                return BadRequest();
            }

            _context.Entry(chiTietVaiTro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietVaiTroExists(id))
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

        // POST: api/ChiTietVaiTroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietVaiTro>> PostChiTietVaiTro(ChiTietVaiTro chiTietVaiTro)
        {
          if (_context.ChiTietVaiTros == null)
          {
              return Problem("Entity set 'MyDbContext.ChiTietVaiTros'  is null.");
          }
            _context.ChiTietVaiTros.Add(chiTietVaiTro);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietVaiTroExists(chiTietVaiTro.MaQuyen))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChiTietVaiTro", new { id = chiTietVaiTro.MaQuyen }, chiTietVaiTro);
        }

        // DELETE: api/ChiTietVaiTroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietVaiTro(int id,int quyen)
        {
            if (_context.ChiTietVaiTros == null)
            {
                return NotFound();
            }
            var chiTietVaiTro = await _context.ChiTietVaiTros.Where(m=>m.MaQuyen==quyen && m.MaVaiTro==id).SingleAsync();
            if (chiTietVaiTro == null)
            {
                return NotFound();
            }

            _context.ChiTietVaiTros.Remove(chiTietVaiTro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietVaiTroExists(int id)
        {
            return (_context.ChiTietVaiTros?.Any(e => e.MaQuyen == id)).GetValueOrDefault();
        }
    }
}
