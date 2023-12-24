using LuanVan.Data;
using LuanVan.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuanVan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanLyNguoiDungController : ControllerBase
    {
        private readonly MyDbContext _context;
        public QuanLyNguoiDungController(MyDbContext context)
        {
            _context = context;
        }
        // GET: api/<QuanLyNguoiDungController>
        [HttpGet("khachhang")]
        public IActionResult Get()

        {
            var objs = new List<Object>();
            var KhachHangs = _context.TaiKhoans.Where(m=>m.VaiTros.Where(m=>m.VaiTro.Quyens.Where(m=>m.MaQuyen==2).Any() == true).Any()==true).ToList();
            var DonVanChuyens = _context.DonVanChuyens.Include(m=>m.ChiTietTrangThais).Where(m => m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 20
            || m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 19).ToList();
            foreach (var khach in KhachHangs)
            {
                var cuoc1 = DonVanChuyens.Where(m => m.MaKhachHang == khach.MaTaiKhoan && m.NguoiTraCuoc == false && m.NgayThanhToanCuocPhi == null && m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 20).Sum(m => m.CuocPhi);
                var cuoc2 = DonVanChuyens.Where(m => m.MaKhachHang == khach.MaTaiKhoan && m.NguoiTraCuoc == false && m.NgayThanhToanCuocPhi == null && m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 19).Sum(m => m.CuocPhi) * (float)0.5;
                objs.Add(new
                {
                    maKhachHang = khach.MaTaiKhoan,
                    tenKhachHang = khach.HoTen,
                    soDienThoai = khach.SDT,
                    cuocConNo = cuoc1 + cuoc2,
                    cuocDaTra = DonVanChuyens.Where(m => m.MaKhachHang == khach.MaTaiKhoan && m.NguoiTraCuoc == false && m.NgayThanhToanCuocPhi != null).Sum(m => m.CuocPhi),
                    soDonHang = DonVanChuyens.Where(m => m.MaKhachHang == khach.MaTaiKhoan).Count(),
                    tienThuHo = DonVanChuyens.Where(m => m.MaKhachHang == khach.MaTaiKhoan && m.NguoiTraCuoc == false&& m.NgayThanhToanTienThuHoKh == null  && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)
                    .Sum(m => m.TongTienThuHo)
                    +
                    (DonVanChuyens.Where(m => m.MaKhachHang == khach.MaTaiKhoan && m.NguoiTraCuoc == true&& m.NgayThanhToanTienThuHoKh == null && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)
                    .Sum(m => m.TongTienThuHo)
                    - 
                    DonVanChuyens.Where(m => m.MaKhachHang == khach.MaTaiKhoan && m.NguoiTraCuoc == true&& m.NgayThanhToanTienThuHoKh == null && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)
                    .Sum(m => m.CuocPhi))
                }) ;
            }
            return Ok(objs);
        }
        [HttpGet("donHoanThanhKH/{maTaiKhoan}")]
        public IActionResult getdonKhachhang(string maTaiKhoan)
        {
            var DonVanChuyens = _context.DonVanChuyens.Where(m => m.MaKhachHang == maTaiKhoan && (m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 20
           || m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 19)).Select(m => new
           {
               m.MaVanDon,
               m.DiaChiNguoiNhan,
               m.SoDienThoaiNguoiNhan,
               m.ChiTietTrangThais.OrderByDescending(m=>m.ThoiGian).First().TrangThaiDonHang.TenTrangThai,
               m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
               m.TenNguoiNhan,
               m.ChiTietDonVanChuyens,
               m.ChiTietTrangThais,
               m.DiaChiNguoiGui,
               m.CuocPhi,
               m.MaDonVanChuyen
           });
            return Ok(DonVanChuyens);
        }
        [HttpGet("donNhanVien/{maTaiKhoan}")]
        public IActionResult getDonNhanVien(string maTaiKhoan)
        {
            var DonVanChuyens = _context.DonVanChuyens.Where(m => m.MaNhanVienGiaoHang == maTaiKhoan && (m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 20
           || m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 19)).Select(m => new
           {
               m.MaVanDon,
               m.DiaChiNguoiNhan,
               m.SoDienThoaiNguoiNhan,
               m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().TrangThaiDonHang.TenTrangThai,
               m.TenNguoiNhan,
               m.ChiTietDonVanChuyens,
               m.ChiTietTrangThais,
               m.DiaChiNguoiGui,
               m.CuocPhi,
               m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
               m.MaDonVanChuyen
           });
            return Ok(DonVanChuyens);
        }
        [HttpGet("cuocConNo/{maTaiKhoan}")]
        public IActionResult cuocConNo(string maTaiKhoan)
        {
            var DonVanChuyens = _context.DonVanChuyens.Where(m => m.MaKhachHang == maTaiKhoan && m.NguoiTraCuoc==false && m.NgayThanhToanCuocPhi ==null && (m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 20
           || m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 19)).Select(m => new
           {
               m.MaVanDon,
               m.DiaChiNguoiNhan,
               m.SoDienThoaiNguoiNhan,
               m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().TrangThaiDonHang.TenTrangThai,
               m.TenNguoiNhan,
               m.ChiTietDonVanChuyens,
               m.ChiTietTrangThais,
               m.DiaChiNguoiGui,
               m.MaDonVanChuyen,
                m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen,
               m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
               cuocPhi = m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 19 ? (m.CuocPhi* (float)0.5) : m.CuocPhi,
               m.MaKhachHang,
               m.KhachHang.HoTen
           });
            return Ok(DonVanChuyens);
        }
        [HttpGet("tienNoThuHo/{maTaiKhoan}")]
        public IActionResult tienNoThuHo(string maTaiKhoan)
        {
            var DonVanChuyens = _context.DonVanChuyens.Where(m => m.MaNhanVienGiaoHang == maTaiKhoan && m.NgayThanhToanTienThuHo == null && m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 20
          ).Select(m => new
           {
               m.MaVanDon,
               m.DiaChiNguoiNhan,
               m.SoDienThoaiNguoiNhan,
               m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().TrangThaiDonHang.TenTrangThai,
               m.TenNguoiNhan,
               m.ChiTietDonVanChuyens,
               m.ChiTietTrangThais,
               m.DiaChiNguoiGui,
               m.MaDonVanChuyen,
               m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen,
               m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
               tienThuHo = m.TongTienThuHo,
               m.CuocPhi,
              thanhToan = m.NgayThanhToanTienThuHo == null ? false : true,
              m.MaNhanVienGiaoHang,
               m.NhanVienGiaoHang.HoTen
           });
            return Ok(DonVanChuyens);
        }
        [HttpGet("tienNoThuHoKh/{maTaiKhoan}")]
        public IActionResult tienNoThuHoKh(string maTaiKhoan)
        {
            var DonVanChuyens = _context.DonVanChuyens.Include(m=>m.KhachHang).Where(m => m.MaKhachHang == maTaiKhoan  && m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 20
          ).Select(m => new
          {
              m.MaVanDon,
              m.DiaChiNguoiNhan,
              m.SoDienThoaiNguoiNhan,
              thanhToan = m.NgayThanhToanTienThuHoKh == null ? false : true,
              m.TenNguoiNhan,
              m.ChiTietDonVanChuyens,
              m.ChiTietTrangThais,
              m.DiaChiNguoiGui,
              m.MaDonVanChuyen,
              m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen,
              m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
              tienThuHo = m.NguoiTraCuoc == false ? m.TongTienThuHo : (m.TongTienThuHo - m.CuocPhi),
              m.CuocPhi,
              m.KhachHang.HoTen,
              m.MaKhachHang,
             
          });
            return Ok(DonVanChuyens);
        }
        [HttpGet("getCuocPhiKhachHang/{maKhachHang}")]
        public IActionResult getCuocPhiKhachhang(string maKhachHang,string ngayBatDau="", string ngayKetThuc="")
        {
            var BD = DateTime.Parse(ngayBatDau).Date;
            var KT = DateTime.Parse(ngayKetThuc).Date;
            var thanhToan  = (float)0;
            var chuaThanhToan = (float)0;
            var tongCuoc = (float)0;
            var KhachHang = _context.TaiKhoans.Find(maKhachHang);
            var objs = new List<object>();
            var DonVanChuyen = _context.DonVanChuyens.Include(m => m.ChiTietTrangThais).Where(m => m.MaKhachHang == maKhachHang && m.NguoiTraCuoc ==false && (m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().MaTrangThaiDonVanChuyen == 19
            || m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().MaTrangThaiDonVanChuyen == 20) && m.ChiTietTrangThais.OrderByDescending(n=>n.ThoiGian).First().ThoiGian.Date.CompareTo(BD) >= 0 && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().ThoiGian.Date.CompareTo(KT) <= 0).ToList();
            foreach(var don in DonVanChuyen)
            {
                
                if (don.ChiTietTrangThais.OrderByDescending(n=>n.ThoiGian).First().MaTrangThaiDonVanChuyen == 19)
                {
                    if(don.NgayThanhToanCuocPhi == null)
                    {
                        chuaThanhToan += don.NguoiTraCuoc == false ? don.CuocPhi * (float)0.5 : 0;
                    }
                    else
                    {
                        thanhToan += don.NguoiTraCuoc == false ? don.CuocPhi * (float)0.5 : 0;
                    }
                }
                else
                {
                    if (don.NgayThanhToanCuocPhi == null)
                    {
                        chuaThanhToan += don.NguoiTraCuoc == false ? don.CuocPhi  : 0;
                    }
                    else
                    {
                        thanhToan += don.NguoiTraCuoc == false ? don.CuocPhi  : 0;
                    }
                }

                objs.Add(new
                {
                    maDonVanChuyen = don.MaVanDon,
                    thanhToan = don.NgayThanhToanCuocPhi == null ? false : true,
                    cuocPhi = don.ChiTietTrangThais.OrderByDescending(m=>m.ThoiGian).First().MaTrangThaiDonVanChuyen == 19 ?
                    don.CuocPhi * (float)0.5
                    :
                    don.CuocPhi
                    ,
                    ngayThanhToan = don.NgayThanhToanCuocPhi != null ? don.NgayThanhToanCuocPhi : null,
                    ngayThem = _context.ChiTietTrangThais.Where(m=>m.MaDonVanChuyen==don.MaDonVanChuyen).OrderByDescending(m=>m.ThoiGian).First().ThoiGian,
                    don.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen 
                }) ;
            }
            return Ok(new
            {
                data = objs,
                thanhToan = thanhToan,
                chuaThanhToan = chuaThanhToan,
                tongCuoc = thanhToan + chuaThanhToan,
            }) ;
        }
        [HttpPost("noCuoc/thanhtoan/{id}")]
        public IActionResult thanhToanCuoc(string id, string ngayBatDau = "", string ngayKetThuc = "")
        {
            var BD = DateTime.Parse(ngayBatDau).Date;
            var KT = DateTime.Parse(ngayKetThuc).Date;
            var DonVanChuyens = _context.DonVanChuyens.Where(m => m.MaKhachHang == id && m.NgayThanhToanCuocPhi == null &&( m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 20
            || m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 19) && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().ThoiGian.Date.CompareTo(BD) >= 0 && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().ThoiGian.Date.CompareTo(KT) <= 0
       ).ToList();
            foreach (var don in DonVanChuyens)
            {
                don.NgayThanhToanCuocPhi = DateTime.Now;
            }
            _context.DonVanChuyens.UpdateRange(DonVanChuyens);
            _context.SaveChanges();
            return Ok("Đã thanh toán!");
        }
        [HttpPost("noTienThuHo/xacNhanThanhToan/{id}")]
        public IActionResult thanhToanTienThuHoKh(string id, string ngayBatDau = "", string ngayKetThuc = "")
        {
            var BD = DateTime.Parse(ngayBatDau).Date;
            var KT = DateTime.Parse(ngayKetThuc).Date;
            var DonVanChuyens = _context.DonVanChuyens.Where(m => m.MaKhachHang == id && m.NgayThanhToanTienThuHoKh == null && m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 20
        && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().ThoiGian.Date.CompareTo(BD) >= 0 && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().ThoiGian.Date.CompareTo(KT) <= 0
       ).ToList();
            foreach (var don in DonVanChuyens)
            {
                don.NgayThanhToanTienThuHoKh = DateTime.Now;
            }
            _context.DonVanChuyens.UpdateRange(DonVanChuyens);
            _context.SaveChanges();
            return Ok("Đã thanh toán!");
        }
        [HttpPost("noTienThuHoNV/xacNhanThanhToan/{id}")]
        public IActionResult thanhToanTienThuHoNV(string id, string ngayBatDau = "", string ngayKetThuc = "")
        {
            var BD = DateTime.Parse(ngayBatDau).Date;
            var KT = DateTime.Parse(ngayKetThuc).Date;
            var DonVanChuyens = _context.DonVanChuyens.Where(m => m.MaNhanVienGiaoHang == id && m.NgayThanhToanTienThuHo == null && m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 20
        && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().ThoiGian.Date.CompareTo(BD) >= 0 && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().ThoiGian.Date.CompareTo(KT) <= 0
       ).ToList();
            foreach (var don in DonVanChuyens)
            {
                don.NgayThanhToanTienThuHo = DateTime.Now;
            }
            _context.DonVanChuyens.UpdateRange(DonVanChuyens);
            _context.SaveChanges();
            return Ok("Đã thanh toán!");
        }
        [HttpPost("noCuocKh/xacNhanThanhToan/{id}")]
        public IActionResult thanhToanNoCuoc(string id, string ngayBatDau = "", string ngayKetThuc = "")
        {
            var BD = DateTime.Parse(ngayBatDau).Date;
            var KT = DateTime.Parse(ngayKetThuc).Date;
            var DonVanChuyens = _context.DonVanChuyens.Where(m => m.MaKhachHang == id && m.NgayThanhToanCuocPhi == null &&( m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 20
        || m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 19) && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().ThoiGian.Date.CompareTo(BD) >= 0 && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().ThoiGian.Date.CompareTo(KT) <= 0
       ).ToList();
            foreach (var don in DonVanChuyens)
            {
                don.NgayThanhToanCuocPhi = DateTime.Now;
            }
            _context.DonVanChuyens.UpdateRange(DonVanChuyens);
            _context.SaveChanges();
            return Ok("Đã thanh toán!");
        }
        [HttpGet("nhanvien")]
        public IActionResult Ge1t()

        {
             var objs = new List<Object>();
            var KhachHangs = _context.TaiKhoans.Where(m => m.VaiTros.Where(m => m.VaiTro.Quyens.Where(m => m.MaQuyen == 3).Any() == true).Any() == true).ToList();
            var DonVanChuyens = _context.DonVanChuyens.Include(m=>m.ChiTietTrangThais).Where(m => m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 20
             || m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 19).ToList();
            foreach (var khach in KhachHangs)
            {
                objs.Add(new
                {
                    maNhanVien = khach.MaTaiKhoan,
                    tenNhanVien = khach.HoTen,
                    soDienThoai = khach.SDT,
                    luong = DonVanChuyens.Where(m => m.MaNhanVienGiaoHang == khach.MaTaiKhoan).Sum(m => m.PhiNhanVienGiaoHang),
                    tongTienThuHo = DonVanChuyens.Where(m => m.MaNhanVienGiaoHang == khach.MaTaiKhoan).Sum(m => m.TongTienThuHo),
                    soDonHang = DonVanChuyens.Where(m => m.MaNhanVienGiaoHang == khach.MaTaiKhoan).Count(),
                    tienNo = DonVanChuyens.Where(m => m.MaNhanVienGiaoHang == khach.MaTaiKhoan && m.NgayThanhToanTienThuHo == null && m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 20).Sum(m => m.TongTienThuHo),
                });
            }
            return Ok(objs);

        }

        // GET api/<QuanLyNguoiDungController>/5
        [HttpGet("luongNhanVien/{id}")]
        public IActionResult Get(string id)
        {
           var objs =  _context.DonVanChuyens.Where(m => m.MaNhanVienGiaoHang == id && (m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 19 || m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 20))
                .Select(m=> new
                {
                    m.MaVanDon,
                    m.NhanVienGiaoHang.HoTen,
                    m.MaNhanVienGiaoHang,
                    m.PhiNhanVienGiaoHang,
                    m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                    m.ChiTietDonVanChuyens,
                    m.DiaChiNguoiNhan,
                    m.SoDienThoaiNguoiNhan,
                    m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().TrangThaiDonHang.TenTrangThai,
                    m.TenNguoiNhan,
                    m.DiaChiNguoiGui,
                    m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen,
                    cuocPhi = m.NguoiTraCuoc == false ? m.TongTienThuHo : (m.TongTienThuHo - m.CuocPhi),
                    m.MaKhachHang,
                    m.NgayThanhToanPhiNhanVienGiaoHang
                });
            return Ok(objs);
        }
        [HttpPost("luongNhanVien/xacNhanThanhToan/{id}")]
        public IActionResult thanhToanLuongNhanVien(string id, string ngayBatDau = "", string ngayKetThuc = "")
        {
            var BD = DateTime.Parse(ngayBatDau).Date;
            var KT = DateTime.Parse(ngayKetThuc).Date;
            var DonVanChuyens = _context.DonVanChuyens.Where(m => m.MaNhanVienGiaoHang == id && m.NgayThanhToanPhiNhanVienGiaoHang == null && (m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 20
        || m.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().MaTrangThaiDonVanChuyen == 19) && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().ThoiGian.Date.CompareTo(BD) >= 0 && m.ChiTietTrangThais.OrderByDescending(n => n.ThoiGian).First().ThoiGian.Date.CompareTo(KT) <= 0
       ).ToList();
            foreach (var don in DonVanChuyens)
            {
                don.NgayThanhToanPhiNhanVienGiaoHang = DateTime.Now;
            }
            _context.DonVanChuyens.UpdateRange(DonVanChuyens);
            _context.SaveChanges();
            return Ok("Đã thanh toán!");
        }
        // POST api/<QuanLyNguoiDungController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<QuanLyNguoiDungController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QuanLyNguoiDungController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
