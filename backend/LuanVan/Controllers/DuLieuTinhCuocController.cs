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
    public class DuLieuTinhCuocController : ControllerBase
    {
        private readonly MyDbContext _context;

        public DuLieuTinhCuocController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/DuLieuTinhCuoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DuLieuTinhCuoc>>> GetDuLieuTinhCuocs(string filter="", int maHinhThucVanChuyen=0, int maTinhThanhPho = 0, int page=1, int limit=5)
        {
            var list = new List<DuLieuTinhCuoc>();
          if (filter == "" && maHinhThucVanChuyen==0 && maTinhThanhPho==0)
            {
                list = await _context.DuLieuTinhCuocs.Include(m => m.TinhThanhPho).Include(m => m.HinhThucVanChuyen).ToListAsync();
            }
            if (filter == "" && maHinhThucVanChuyen == 0 && maTinhThanhPho != 0)
                list = await _context.DuLieuTinhCuocs.Include(m => m.TinhThanhPho).Include(m => m.HinhThucVanChuyen).Where(m=>m.MaTinhThanhPho==maTinhThanhPho).ToListAsync();
            if (filter == "" && maHinhThucVanChuyen != 0 && maTinhThanhPho == 0)
                list = await _context.DuLieuTinhCuocs.Include(m => m.TinhThanhPho).Include(m => m.HinhThucVanChuyen).Where(m => m.MaHinhThucVanChuyen == maHinhThucVanChuyen).ToListAsync();
            if (filter != "" && maHinhThucVanChuyen == 0 && maTinhThanhPho == 0)
                list = await _context.DuLieuTinhCuocs.Include(m => m.TinhThanhPho).Include(m => m.HinhThucVanChuyen).Where(m => m.TrongLuongBatDau.ToString().Contains(filter)).ToListAsync();
            if (filter != "" && maHinhThucVanChuyen != 0 && maTinhThanhPho == 0)
                list = await _context.DuLieuTinhCuocs.Include(m => m.TinhThanhPho).Include(m => m.HinhThucVanChuyen).Where(m => m.TrongLuongBatDau.ToString().Contains(filter) && m.MaHinhThucVanChuyen == maHinhThucVanChuyen && m.MaHinhThucVanChuyen==maHinhThucVanChuyen).ToListAsync();
            if (filter != "" && maHinhThucVanChuyen == 0 && maTinhThanhPho != 0)
                list = await _context.DuLieuTinhCuocs.Include(m => m.TinhThanhPho).Include(m => m.HinhThucVanChuyen).Where(m => m.TrongLuongBatDau.ToString().Contains(filter) && m.MaHinhThucVanChuyen == maHinhThucVanChuyen && m.MaTinhThanhPho == maTinhThanhPho).ToListAsync();
            if (filter != "" && maHinhThucVanChuyen != 0 && maTinhThanhPho != 0)
                list = await _context.DuLieuTinhCuocs.Include(m => m.TinhThanhPho).Include(m => m.HinhThucVanChuyen).Where(m => m.TrongLuongBatDau.ToString().Contains(filter) && m.MaHinhThucVanChuyen == maHinhThucVanChuyen && m.MaTinhThanhPho == maTinhThanhPho && m.MaHinhThucVanChuyen==maHinhThucVanChuyen).ToListAsync();
            if (filter == "" && maHinhThucVanChuyen != 0 && maTinhThanhPho != 0)
                list = await _context.DuLieuTinhCuocs.Include(m => m.TinhThanhPho).Include(m => m.HinhThucVanChuyen).Where(m => m.MaHinhThucVanChuyen == maHinhThucVanChuyen && m.MaTinhThanhPho == maTinhThanhPho).ToListAsync();
            var result = PaginatedList<DuLieuTinhCuoc>.Create(list, page, limit);
            if (_context.DuLieuTinhCuocs == null)
            {
              return NotFound();
            }
            var obj = new
            {
                result = result,
                totalPage = result.TotalPage,
                totalRecord = list.Count

            };
            return Ok(obj);
        }

        // GET: api/DuLieuTinhCuoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DuLieuTinhCuoc>> GetDuLieuTinhCuoc(int id)
        {
          if (_context.DuLieuTinhCuocs == null)
          {
              return NotFound();
          }
            var duLieuTinhCuoc = await _context.DuLieuTinhCuocs.FindAsync(id);

            if (duLieuTinhCuoc == null)
            {
                return NotFound();
            }

            return duLieuTinhCuoc;
        }

        // PUT: api/DuLieuTinhCuoc/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDuLieuTinhCuoc(int id, DuLieuTinhCuoc duLieuTinhCuoc)
        {
            if (id != duLieuTinhCuoc.MaDuLieuTinhCuoc)
            {
                return BadRequest();
            }

            
            var obj = _context.DuLieuTinhCuocs.Where(m => m.MaHinhThucVanChuyen == duLieuTinhCuoc.MaHinhThucVanChuyen && m.MaTinhThanhPho == duLieuTinhCuoc.MaTinhThanhPho && m.MaDuLieuTinhCuoc!=duLieuTinhCuoc.MaDuLieuTinhCuoc).Any();
            if (obj)
            {
                return Ok(new ResponseModel()
                {
                    Result = false,
                    Data = null,
                    Messgae = "Dữ liệu đã tồn tại"
                });
            }

            _context.DuLieuTinhCuocs.Update(duLieuTinhCuoc);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new ResponseModel()
                {
                    Result = true,
                    Data = null,
                    Messgae = "Cập nhật thành công"
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DuLieuTinhCuocExists(id))
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

        // POST: api/DuLieuTinhCuoc
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DuLieuTinhCuoc>> PostDuLieuTinhCuoc(DuLieuTinhCuoc duLieuTinhCuoc)
        {
          if (_context.DuLieuTinhCuocs == null)
          {
              return Problem("Entity set 'MyDbContext.DuLieuTinhCuocs'  is null.");
          }
            var obj = _context.DuLieuTinhCuocs.Where(m => m.MaHinhThucVanChuyen == duLieuTinhCuoc.MaHinhThucVanChuyen && m.MaTinhThanhPho == duLieuTinhCuoc.MaTinhThanhPho).Any();
          if (obj)
            {
                return Ok (new ResponseModel() {
                    Result = false,
                    Data = null,
                    Messgae="Dữ liệu đã tồn tại"
                });
            }
            _context.DuLieuTinhCuocs.Add(duLieuTinhCuoc);
            await _context.SaveChangesAsync();

            return   Ok(new ResponseModel()
            {
                Result = true,
                Data = null,
                Messgae = "Thêm thành công"
            });
        }

        // DELETE: api/DuLieuTinhCuoc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDuLieuTinhCuoc(int id)
        {
            if (_context.DuLieuTinhCuocs == null)
            {
                return NotFound();
            }
            var duLieuTinhCuoc = await _context.DuLieuTinhCuocs.FindAsync(id);
            if (duLieuTinhCuoc == null)
            {
                return Ok(new ResponseModel()
                {
                    Data = null,
                    Result = false,
                    Messgae = "Không thể xóa"
                });
            }
            _context.DuLieuTinhCuocs.Remove(duLieuTinhCuoc);
            await _context.SaveChangesAsync();

            return Ok(new ResponseModel() { Data = null,
            Result=true,
            Messgae="Xóa thành công"});
            
        }

        private bool DuLieuTinhCuocExists(int id)
        {
            return (_context.DuLieuTinhCuocs?.Any(e => e.MaDuLieuTinhCuoc == id)).GetValueOrDefault();
        }
    }
}
