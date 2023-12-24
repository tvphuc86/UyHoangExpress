using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LuanVan.Data;
using LuanVan.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LuanVan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuocPhiController : ControllerBase
    {
        private readonly MyDbContext _context;
        

        public CuocPhiController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/CuocPhi
        [HttpGet]
        public async Task<ActionResult> GetCuocPhis(int page = 1, int limit = 5, string filter = "")
        {
            var list = new List<ChiTietCuocPhi>();

            if (filter != "")
            {
                list = _context.ChiTietCuocPhis.Include(m => m.CuocPhi.HinhThucVanChuyen).Include(m => m.QuanHuyen.TinhThanhPho).Include(m=>m.CuocPhi.TrongLuong)
                    .Where(m => m.QuanHuyen.TenQuanHuyen.Contains(filter) || m.QuanHuyen.TinhThanhPho.TenTinhThanhPho.Contains(filter)
                    || m.CuocPhi.TrongLuong.TrongLuongBatDau.ToString().Contains(filter) || m.CuocPhi.TrongLuong.TrongLuongKetThuc.ToString().Contains(filter)
                    || m.CuocPhi.GiaCuoc.ToString().Contains(filter)
                    || m.CuocPhi.ThoiGianGiao.Contains(filter)
                    || m.CuocPhi.HinhThucVanChuyen.Ten.Contains(filter))
                    .ToList();
            }
            else list = _context.ChiTietCuocPhis.Include(m => m.CuocPhi.HinhThucVanChuyen).Include(m=>m.CuocPhi.TrongLuong).Include(m => m.QuanHuyen.TinhThanhPho).ToList();
            var result = PaginatedList<ChiTietCuocPhi>.Create(list, page, limit);
            var obj = new
            {
                result = result,
                totalPage = result.TotalPage,
                totalRecord = list.Count

            };
            return Ok(obj);
        }

        // GET: api/CuocPhi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CuocPhi>> GetCuocPhi(int id)
        {
          if (_context.CuocPhis == null)
          {
              return NotFound();
          }
            var cuocPhi = await _context.CuocPhis.FindAsync(id);

            if (cuocPhi == null)
            {
                return NotFound();
            }

            return cuocPhi;
        }
        [NonAction]
        public bool CheckDuplicate(CuocPhi cuocPhi)
        {
            //var CuocPhis = _context.CuocPhis.Where(m=>m.MaHinhThucVanChuyen==cuocPhi.MaHinhThucVanChuyen && m.MaQuanHuyen == cuocPhi.MaQuanHuyen).ToList();
            //var result = true;
            //var b = cuocPhi.TrongLuongBatDau;
            //var c = cuocPhi.TrongLuongKetThuc;
            //foreach (var m in CuocPhis)
            //{
            //    var a = m.TrongLuongBatDau;
            //    var d = m.TrongLuongKetThuc;
            //    if (b>=d) { result = true; }
            //    else
            //    if (
            //        (b>a && b<d && c>a && c<d) ||
            //        (b < a && d > a) ||
            //        (c > d && b < c)||
            //        (c==d && b+1==a)
            //        )
            //    {
            //        result = false;
            //    }
                
            //}
            return true;
        }

        // PUT: api/CuocPhi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public  IActionResult PutCuocPhi(int id)
        {
            return Ok(_context.CuocPhis.ToList());
        }
        [NonAction]
        public void addChiTiet (string maQuanHuyen,long maCuocPhi)
        {

            if (maQuanHuyen.Contains(",")) {

                var maQuanHuyens = maQuanHuyen.Split(',');

                foreach (var i in maQuanHuyens)
                {
                    var obj = new ChiTietCuocPhi();
                    obj.MaCuocPhi = maCuocPhi;
                    obj.MaQuanHuyen = int.Parse(i);
                    _context.ChiTietCuocPhis.Add(obj);

                    _context.SaveChanges();
                } }
            else
            {
                var obj = new ChiTietCuocPhi();
                obj.MaCuocPhi = maCuocPhi;
                obj.MaQuanHuyen = int.Parse(maQuanHuyen);
                _context.ChiTietCuocPhis.Add(obj);
                _context.SaveChanges();
            }
            

        }
        // POST: api/CuocPhi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult PostCuocPhi(CuocPhi cuocPhi, string maQuanHuyen)
        {
            if (_context.CuocPhis == null)
            {
                return Problem("Entity set 'MyDbContext.CuocPhis'  is null.");
            }
            if (_context.CuocPhis.Where(m => m.MaHinhThucVanChuyen == cuocPhi.MaHinhThucVanChuyen &&
            m.MaTrongLuong == cuocPhi.MaTrongLuong && m.GiaCuoc == cuocPhi.GiaCuoc && m.ThoiGianGiao == cuocPhi.ThoiGianGiao).Any())
            {
                addChiTiet(maQuanHuyen, _context.CuocPhis.Where(m => m.MaHinhThucVanChuyen == cuocPhi.MaHinhThucVanChuyen &&
            m.MaTrongLuong == cuocPhi.MaTrongLuong && m.GiaCuoc == cuocPhi.GiaCuoc && m.ThoiGianGiao == cuocPhi.ThoiGianGiao).Single().MaCuocPhi);

                return Ok(new ResponseModel()
                {
                    Data = null,
                    Result = true,
                    Messgae = "Thêm thành công"
                });
            }
            else
            {
                _context.CuocPhis.Add(cuocPhi);
                _context.SaveChanges();

                addChiTiet(maQuanHuyen, cuocPhi.MaCuocPhi);

                return Ok(new ResponseModel()
                {
                    Data = null,
                    Result = true,
                    Messgae = "Thêm thành công"
                });
            }
        }

        // DELETE: api/CuocPhi/5
        [HttpDelete]
        public async Task<IActionResult> DeleteCuocPhi(int id,long quanHuyen)
        {
            if (_context.CuocPhis == null)
            {
                return NotFound();
            }
            var cuocPhi = await _context.ChiTietCuocPhis.Include(m=>m.CuocPhi).Where(m=>m.MaCuocPhi==id && m.MaQuanHuyen==quanHuyen).SingleAsync();
            if (cuocPhi == null)
            {
                return NotFound();
            }


                _context.ChiTietCuocPhis.Remove(cuocPhi);
            

            await _context.SaveChangesAsync();

            return Ok(true);
        }

        private bool CuocPhiExists(int id)
        {
            return (_context.CuocPhis?.Any(e => e.MaCuocPhi == id)).GetValueOrDefault();
        }
    }
}
