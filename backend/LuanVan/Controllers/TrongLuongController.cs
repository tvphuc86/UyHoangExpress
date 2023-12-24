using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LuanVan.Data;
using LuanVan.Model;
using NuGet.Protocol.Core.Types;

namespace LuanVan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrongLuongController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TrongLuongController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/TrongLuong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrongLuong>>> GetTrongLuongs(string filter="",int page=1, int limit=5)
        {
            try
            {
               var list = await _context.TrongLuongs.Where(m=>m.TrongLuongKetThuc.ToString().Contains(filter) || m.TrongLuongBatDau.ToString().Contains(filter)).ToListAsync();
                var result = PaginatedList<TrongLuong>.Create(list, page, limit);
                var obj = new
                {
                    result = result,
                    totalPage = result.TotalPage,
                    totalRecord = list.Count

                };
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/TrongLuong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrongLuong>> GetTrongLuong(int id)
        {
          if (_context.TrongLuongs == null)
          {
              return NotFound();
          }
            var trongLuong = await _context.TrongLuongs.FindAsync(id);

            if (trongLuong == null)
            {
                return NotFound();
            }

            return trongLuong;
        }

        // PUT: api/TrongLuong/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrongLuong(int id, TrongLuong trongLuong)
        {
            if (id != trongLuong.MaTrongLuong)
            {
                return BadRequest();
            }
            var TrongLuongExit = _context.TrongLuongs.Where(m => m.MaTrongLuong == trongLuong.MaTrongLuong).Single();
            if (TrongLuongExit.TrongLuongBatDau==trongLuong.TrongLuongBatDau && TrongLuongExit.TrongLuongKetThuc == trongLuong.TrongLuongKetThuc)
            {
                return Ok(new ResponseModel()
                {
                    Data = trongLuong,
                    Result = true,
                    Messgae = "Cập nhật thành công"
                });
            }
            
            if(!_context.TrongLuongs.Where(m=>m.TrongLuongKetThuc > trongLuong.TrongLuongKetThuc).Any())
            {
                _context.TrongLuongs.Update(trongLuong);
                await _context.SaveChangesAsync();

                return Ok(new ResponseModel()
                {
                    Data = trongLuong,
                    Result = true,
                    Messgae = "Cập nhật thành công"
                });
            }
            var TrongLuong = _context.TrongLuongs.Where(m=>m.MaTrongLuong!=trongLuong.MaTrongLuong).ToList();
            var result = true;
            var b = trongLuong.TrongLuongBatDau;
            var c = trongLuong.TrongLuongKetThuc;
            foreach (var m in TrongLuong)
            {
                var a = m.TrongLuongBatDau;
                var d = m.TrongLuongKetThuc;
                if (b > d) { result = true; }
                else if(d==c && b > a) { result = true; }
                if (
                    (b >= a && b <= d && c >= a && c <= d) ||
                    (b <= a && d >= a) ||
                    (c >= d && b <= c) ||
                    (c == d && b == a)
                    )
                {
                    result = false;
                }
            }
            if (result)
            {
                _context.TrongLuongs.Update(trongLuong);
                await _context.SaveChangesAsync();

                return Ok(new ResponseModel()
                {
                    Data = trongLuong,
                    Result = true,
                    Messgae = "Cập nhật thành công"
                });
            }
            else
            {
                return Ok(new ResponseModel()
                {
                    Data = null,
                    Result = false,
                    Messgae = "Khoảng trọng lượng này đã tồn tại"
                });
            }
        }

        // POST: api/TrongLuong
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostTrongLuong(TrongLuong trongLuong)
        {
          if (_context.TrongLuongs == null)
          {
              return Problem("Entity set 'MyDbContext.TrongLuongs'  is null.");
          }
            var TrongLuong =  _context.TrongLuongs.ToList();
            var result = true;
            var b = trongLuong.TrongLuongBatDau ;
            var c = trongLuong.TrongLuongKetThuc;
            foreach (var m in TrongLuong)
            {
                var a = m.TrongLuongBatDau;
                var d = m.TrongLuongKetThuc;
                if (b > d) { result = true; }
                else
                if (
                    (b >= a && b <= d && c >= a && c <= d) ||
                    (b <= a && d >= a) ||
                    (c >= d && b <= c) ||
                    (c == d && b == a)
                    )
                {
                    result = false;
                }
            }
            if (result)
            {
                _context.TrongLuongs.Add(trongLuong);
                await _context.SaveChangesAsync();

                return Ok(new ResponseModel()
                {
                    Data = trongLuong,
                    Result = true,
                    Messgae = "Thêm thành công trọng lượng"
                });
            }
            else
            {
                return Ok(new ResponseModel()
                {
                    Data = null,
                    Result = false,
                    Messgae = "Khoảng trọng lượng này đã tồn tại"
                });
            }

        }

        // DELETE: api/TrongLuong/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrongLuong(int id)
        {
            if (_context.TrongLuongs == null)
            {
                return NotFound();
            }
            var trongLuong = await _context.TrongLuongs.FindAsync(id);
            if (trongLuong == null)
            {
                return NotFound();
            }
            if (_context.CuocPhis.Where(m => m.MaTrongLuong == id).Any())
            {
                return Ok(new ResponseModel()
                {
                    Data = trongLuong,
                    Result = false,
                    Messgae = "Không thể xóa"
                });
            }
            _context.TrongLuongs.Remove(trongLuong);
            await _context.SaveChangesAsync();

            return   Ok(new ResponseModel()
            {
                Data = trongLuong,
                Result = true,
                Messgae = "Xóa thành công"
            });
        }

        private bool TrongLuongExists(int id)
        {
            return (_context.TrongLuongs?.Any(e => e.MaTrongLuong == id)).GetValueOrDefault();
        }
    }
}
