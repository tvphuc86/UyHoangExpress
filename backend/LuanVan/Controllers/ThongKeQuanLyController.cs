using LuanVan.Data;
using LuanVan.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuanVan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongKeQuanLyController : ControllerBase
    {
        private readonly MyDbContext _context;
        public ThongKeQuanLyController(MyDbContext context)
        {
            _context= context;  
        }
        // GET: api/<ThongKeQuanLyController>
        [HttpGet("ThongKeDonVanChuyen")]
        public IActionResult Get(string tenKHorNVGH="", string ngayBatDau="" , string ngayKetThuc="")
        {
            var NgayBatDau = DateTime.Parse(ngayBatDau);
            var NgayKetThuc = DateTime.Parse(ngayKetThuc);
            var lables = _context.ChiTietTrangThais.Where(m=>_context.DonVanChuyens.Where(n=>n.MaDonVanChuyen==m.MaDonVanChuyen
            && (m.DonVanChuyen.MaKhachHang.Contains(tenKHorNVGH) || m.DonVanChuyen.MaNhanVienGiaoHang.Contains(tenKHorNVGH)
            ))
            .Single()
            .ChiTietTrangThais
            .Where(m=>m.ThoiGian.Date.CompareTo(NgayBatDau.Date)>= 0 && m.ThoiGian.Date.CompareTo(NgayKetThuc.Date) <= 0)
            .OrderByDescending(m=>m.ThoiGian)
            .First()
            .ThoiGian==m.ThoiGian && m.ThoiGian.Date.CompareTo(NgayBatDau.Date) >= 0 && m.ThoiGian.Date.CompareTo(NgayKetThuc.Date) <= 0
             && (m.DonVanChuyen.MaKhachHang.Contains(tenKHorNVGH) || m.DonVanChuyen.MaNhanVienGiaoHang.Contains(tenKHorNVGH)
            ))
                .Select(m => new {m.MaTrangThaiDonVanChuyen, m.TrangThaiDonHang.TenTrangThai, m.MaDonVanChuyen }).GroupBy(m =>  m.TenTrangThai);

            var datas = new object[lables.Count()+1];
            var tong = 0;
            var i =1;
            var donHoangThanh = 0;
            var donThatBai = 0;
            var donMoi = 0;
            foreach(var lable in lables)
            {
                if(lable.First().MaTrangThaiDonVanChuyen==20 || lable.First().MaTrangThaiDonVanChuyen == 19)
                {
                    donHoangThanh += lable.Count();
                }
                if (lable.First().MaTrangThaiDonVanChuyen == 11)
                {
                    donMoi += lable.Count();
                }
                if (lable.First().MaTrangThaiDonVanChuyen == 24 || lable.First().MaTrangThaiDonVanChuyen == 25)
                {
                    donThatBai += lable.Count();
                }
                var data = new
                {
                    lable = lable.First().TenTrangThai,
                    soDon = lable.Count(),
                };
                tong += lable.Count();
                datas[i] = data;
                i++;
            }
            datas[0] = new
            {
                
                lable = "Tổng đơn",
                soDon = tong
            };
            return Ok(new
            {
                datas = datas,
                donHoangThanh= donHoangThanh,
                donMoi= donMoi,
                donThatBai= donThatBai,
            }
            

            );
        }
        [HttpGet("top5KhachHang")]
        public IActionResult getTop5()
        {
            var khachHangs = _context.TaiKhoans.Where(m => m.VaiTros.Where(m => m.VaiTro.Quyens.Where(m => m.MaQuyen == 2).Any() == true).Any() == true).ToList();
            var listCuocPhi = new List<KhacHangModel>();
            foreach (var khachHang in khachHangs)
            {
                
                listCuocPhi.Add(new KhacHangModel()
                {
                     MaKhachHang= khachHang.MaTaiKhoan,
                    HoTen = khachHang.HoTen,
                    cuocPhi = _context.DonVanChuyens.Where(m => m.MaKhachHang == khachHang.MaTaiKhoan).Count() != 0 ? _context.DonVanChuyens.Include(m=>m.ChiTietTrangThais).Where(m =>m.MaKhachHang == khachHang.MaTaiKhoan 
                    && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().MaTrangThaiDonVanChuyen == 20 && m.NgayThanhToanCuocPhi != null && m.NguoiTraCuoc == false).Sum(m => m.CuocPhi) + _context.DonVanChuyens.Include(m => m.ChiTietTrangThais).Where(m => m.MaKhachHang == khachHang.MaTaiKhoan
                    && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().MaTrangThaiDonVanChuyen == 19 && m.NgayThanhToanCuocPhi != null && m.NguoiTraCuoc == false).Sum(m => m.CuocPhi)*(float)0.5 : 0,
                    tienNo = _context.DonVanChuyens.Where(m => m.MaKhachHang == khachHang.MaTaiKhoan).Count() != 0 ? _context.DonVanChuyens.Include(m => m.ChiTietTrangThais).Where(m =>
                     m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().MaTrangThaiDonVanChuyen == 20 && m.NgayThanhToanCuocPhi == null && m.NguoiTraCuoc == false && m.MaKhachHang==khachHang.MaTaiKhoan).Sum(m => m.CuocPhi) + _context.DonVanChuyens.Include(m => m.ChiTietTrangThais).Where(m =>
                     m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().MaTrangThaiDonVanChuyen == 19 && m.NgayThanhToanCuocPhi == null && m.NguoiTraCuoc == false && m.MaKhachHang==khachHang.MaTaiKhoan).Sum(m => m.CuocPhi)*(float)0.5 : 0 ,
                   
                    tiLe = _context.DonVanChuyens.Where(m=>m.MaKhachHang==khachHang.MaTaiKhoan).Count() != 0 ?
                    100 * ((float)_context.DonVanChuyens.Include(m => m.ChiTietTrangThais).Where(m =>m.MaKhachHang == khachHang.MaTaiKhoan && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().MaTrangThaiDonVanChuyen == 20).Count() 
                    /
                         (float)_context.DonVanChuyens.Where(m=>m.MaKhachHang==khachHang.MaTaiKhoan).Count() )
                    : 0,
                    
                }) ;
                
            }
            return Ok(new
            {
                top5CuocPhi = listCuocPhi.OrderByDescending(m=>m.cuocPhi).Take(5),
                top5No = listCuocPhi.OrderByDescending(m=>m.tienNo).Take(5),
                top5TiLe = listCuocPhi.OrderByDescending(m=>m.tiLe).Take(5),

            });
        }
        [HttpGet("top5NhanVien")]
        public IActionResult getTop5NhanVien()
        {
            var khachHangs = _context.TaiKhoans.Where(m => m.VaiTros.Where(m => m.VaiTro.Quyens.Where(m => m.MaQuyen == 3).Any() == true).Any() == true).ToList();
            var listCuocPhi = new List<KhacHangModel>();
            foreach (var khachHang in khachHangs)
            {

                listCuocPhi.Add(new KhacHangModel()
                {
                    MaKhachHang = khachHang.MaTaiKhoan,
                    HoTen = khachHang.HoTen,
                    luong = (float)_context.DonVanChuyens.Where(m=>m.MaNhanVienGiaoHang==khachHang.MaTaiKhoan && (m.ChiTietTrangThais.OrderByDescending(n=>n.ThoiGian).First().MaTrangThaiDonVanChuyen==19
                    || m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)).Sum(m=>m.PhiNhanVienGiaoHang),
                    tienNo = _context.DonVanChuyens.Where(m => m.MaNhanVienGiaoHang == khachHang.MaTaiKhoan && (
                     m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().MaTrangThaiDonVanChuyen == 20) && m.NgayThanhToanTienThuHo==null).Sum(m => m.TongTienThuHo),
                    tiLe = _context.DonVanChuyens.Where(m => m.MaNhanVienGiaoHang == khachHang.MaTaiKhoan && (m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().MaTrangThaiDonVanChuyen == 19
                    || m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)).Count() == 0 ? 0 
                    : 100*
                   ((float)_context.DonVanChuyens.Where(m => m.MaNhanVienGiaoHang == khachHang.MaTaiKhoan && (m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)).Count()
                    /
                   (float) _context.DonVanChuyens.Where(m => m.MaNhanVienGiaoHang == khachHang.MaTaiKhoan).Count())


                });

            }
            return Ok(new
            {
                top5CuocPhi = listCuocPhi.OrderByDescending(m => m.luong).Take(5),
                top5No = listCuocPhi.OrderByDescending(m => m.tienNo).Take(5),
                top5TiLe = listCuocPhi.OrderByDescending(m => m.tiLe).Take(5),

            });
        }
        [HttpGet("ThongKeDoanhThuThang")]
        public IActionResult getDoanhThuThang()
        {
            var objs = new object[12];
            for(int i = 0; i<= 11; i++)
            {
                var obj = new
                {
                    lable = i + 1,
                tongCuoc = _context.DonVanChuyens.Where(m => m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().MaTrangThaiDonVanChuyen == 19 && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().ThoiGian.Month == i).Sum(m => m.CuocPhi) * (float)0.5 +
                _context.DonVanChuyens.Where(m => m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().MaTrangThaiDonVanChuyen == 20 && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().ThoiGian.Month == i).Sum(m => m.CuocPhi) -
                ( _context.DonVanChuyens.Where(m => m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().MaTrangThaiDonVanChuyen == 19 && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().ThoiGian.Month == i).Sum(m => m.PhiNhanVienGiaoHang)  +
                _context.DonVanChuyens.Where(m => m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().MaTrangThaiDonVanChuyen == 20 && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().ThoiGian.Month == i).Sum(m => m.PhiNhanVienGiaoHang))
                ,
                };
                objs[i] = obj;
            }
            return Ok(objs);
        }
        // GET api/<ThongKeQuanLyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ThongKeQuanLyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ThongKeQuanLyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ThongKeQuanLyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
