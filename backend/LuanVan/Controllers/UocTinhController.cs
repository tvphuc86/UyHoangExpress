using LuanVan.Data;
using LuanVan.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuanVan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UocTinhController : ControllerBase
    {
        private readonly MyDbContext _context;

        public UocTinhController(MyDbContext context) {
            _context = context;
        }  
        // GET: api/<UocTinhController>
        [HttpGet()]
        public async Task<IEnumerable<ChiTietCuocPhi>> Get(long maQuanHuyen, float trongLuong)
        {
            var obj = await _context.ChiTietCuocPhis.Include(m => m.CuocPhi.HinhThucVanChuyen).Include(m => m.CuocPhi.TrongLuong).Include(m => m.QuanHuyen.TinhThanhPho)
                .Where(m => m.MaQuanHuyen == maQuanHuyen && m.CuocPhi.TrongLuong.TrongLuongBatDau <= trongLuong && m.CuocPhi.TrongLuong.TrongLuongKetThuc >= trongLuong)
                .ToListAsync();
            if (obj.Count == 0)
            {

              
                obj = new List<ChiTietCuocPhi>();
                var tinh = _context.QuanHuyens.Where(m => m.MaQuanHuyen == maQuanHuyen).SingleOrDefault();
                var duLieuTinhCuoc = _context.DuLieuTinhCuocs.Where(m => m.TinhThanhPho.MaTinhThanhPho == tinh.MaTinhThanhPho).ToList();
                
                foreach (var item in duLieuTinhCuoc)
                {
                    
                    var obj2 = await _context.ChiTietCuocPhis.Include(m => m.CuocPhi.HinhThucVanChuyen).Include(m => m.CuocPhi.TrongLuong).Include(m => m.QuanHuyen.TinhThanhPho)
                  .Where(m=> m.MaQuanHuyen==maQuanHuyen && m.CuocPhi.HinhThucVanChuyen.HinhThucVanCHuyenId== item.MaHinhThucVanChuyen
                  && m.CuocPhi.GiaCuoc == _context.ChiTietCuocPhis.Where(m=>m.MaQuanHuyen==maQuanHuyen && m.CuocPhi.HinhThucVanChuyen.HinhThucVanCHuyenId==item.MaHinhThucVanChuyen).Max(m=>m.CuocPhi.GiaCuoc) )
                  .ToListAsync();
                    foreach(var i in obj2)
                    {
                        i.CuocPhi.GiaCuoc = i.CuocPhi.GiaCuoc + (int)Math.Ceiling((trongLuong - item.TrongLuongBatDau)/item.GiaTriNac) * item.GiaCuocNac;
                        obj.Add(i);
                    }

                }
                
            }
            return obj;
        }

        // GET api/<UocTinhController>/5
        [HttpGet("cuocPhi")]
        public IActionResult Get(long maQuanHuyen,float trongLuong,int maHinhThucVanChuyen)
        {
            if (trongLuong == 0 || maHinhThucVanChuyen==0 || maQuanHuyen==0)
            {
                return Ok(new
                {
                    cuocPhi = 0,
                    thoiGianGiao = ""
                });
            }
            var obj = _context.ChiTietCuocPhis.Include(m => m.CuocPhi).Where(m => m.MaQuanHuyen == maQuanHuyen && m.CuocPhi.MaHinhThucVanChuyen == maHinhThucVanChuyen &&
            m.CuocPhi.TrongLuong.TrongLuongBatDau <= trongLuong && m.CuocPhi.TrongLuong.TrongLuongKetThuc >= trongLuong).SingleOrDefault();
            if (obj != null)
            {
                return Ok(new
                {
                    cuocPhi = obj.CuocPhi.GiaCuoc,
                    thoiGianGiao = obj.CuocPhi.ThoiGianGiao
                });
            }
            else
            {
                if (_context.ChiTietCuocPhis.Where(m => m.MaQuanHuyen == maQuanHuyen).Count() !=0)
                {
                    var tinh = _context.QuanHuyens.Where(m => m.MaQuanHuyen == maQuanHuyen).Include(m => m.TinhThanhPho).SingleOrDefault().TinhThanhPho.MaTinhThanhPho;
                    var duLieu = _context.DuLieuTinhCuocs.Where(m => m.MaTinhThanhPho == tinh && m.MaHinhThucVanChuyen == maHinhThucVanChuyen).FirstOrDefault();
                    var cuocPhiDau = _context.ChiTietCuocPhis.Include(m => m.CuocPhi).Where(m => m.MaQuanHuyen == maQuanHuyen && m.CuocPhi.MaHinhThucVanChuyen == maHinhThucVanChuyen)
                        .Max(m => m.CuocPhi.GiaCuoc);
                    var thoiGianGiao = _context.ChiTietCuocPhis.Include(m => m.CuocPhi).Where(m => m.MaQuanHuyen == maQuanHuyen && m.CuocPhi.MaHinhThucVanChuyen == maHinhThucVanChuyen &&
                    m.CuocPhi.GiaCuoc == cuocPhiDau).SingleOrDefault().CuocPhi.ThoiGianGiao;

                    var cuocPhi = (int)Math.Ceiling((trongLuong - duLieu.TrongLuongBatDau) / duLieu.GiaTriNac) * duLieu.GiaCuocNac + cuocPhiDau;
                    return Ok(new
                    {
                        cuocPhi = cuocPhi,
                        thoiGianGiao = thoiGianGiao
                    });
                }
                else
                {
                    return Ok(
                        false
                    );
                }
            }
        }

        // POST api/<UocTinhController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UocTinhController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UocTinhController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
