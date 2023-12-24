using LuanVan.Data;
using LuanVan.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuanVan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonVanChuyenController : ControllerBase
    {
        private readonly MyDbContext _context;

        public DonVanChuyenController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/<DonVanChuyenController>
        [HttpGet("quan-ly/duyet-don")]
        public IActionResult Get()
        {
            return Ok(_context.DonVanChuyens.Include(m => m.ChiTietDonVanChuyens).Include(m=>m.ChiTietTrangThais)
                .Where(m => m.MaQuanLy == null && !m.ChiTietTrangThais.Where(n=>n.MaTrangThaiDonVanChuyen==13).Any())
                .ToList()
                .Select(m =>
                new {
                    m.SoDienThoaiNguoiGui,
                    m.SoDienThoaiNguoiNhan,
                    m.TenNguoiGui,
                    m.TenNguoiNhan,
                    m.ChiTietDonVanChuyens,
                    m.TongTienThuHo,
                    m.CuocPhi,
                    m.NgayTao,
                    m.DiaChiNguoiGui,
                    m.DiaChiNguoiNhan,
                    m.MaDonVanChuyen
                })

                );
        }
        [HttpGet("nhan-vien-giao-hang/nhan-don-hang")]
        public IActionResult GetNVGh()
        {
            return Ok(_context.DonVanChuyens.Include(m => m.ChiTietDonVanChuyens).Include(m => m.ChiTietTrangThais)
                .Where(m => m.MaNhanVienGiaoHang == null && m.ChiTietTrangThais.Where(n => n.MaTrangThaiDonVanChuyen == 12 
                && n.ThoiGian.CompareTo(_context.ChiTietTrangThais.Where(a => a.MaDonVanChuyen == m.MaDonVanChuyen).Max(n => n.ThoiGian))==0).Any())
                .ToList()
                .Select(m =>
                new {
                    m.SoDienThoaiNguoiGui,
                    m.SoDienThoaiNguoiNhan,
                    m.TenNguoiGui,
                    m.ChiTietTrangThais.First().MaTrangThaiDonVanChuyen,
                    m.TenNguoiNhan,
                    m.ChiTietDonVanChuyens,
                    m.TongTienThuHo,
                    m.CuocPhi,
                    m.NgayTao,
                    m.DiaChiNguoiGui,
                    m.DiaChiNguoiNhan,
                    m.MaDonVanChuyen
                })

                );
        }
        [HttpGet("trangThai/{id}")]
        public IActionResult TheoDoiTrangThai(int id)
        {
            return Ok(_context.ChiTietTrangThais.Include(m => m.TrangThaiDonHang).Include(m => m.DonVanChuyen).Where(n => n.MaDonVanChuyen == id)
                .ToList().OrderBy(m=>m.ThoiGian)
                .Select(x => new
                {
                    x.TrangThaiDonHang.TenTrangThai,
                    x.DiaChi,
                    x.ThoiGian
                }));
        }
        [HttpGet("khach-hang/quan-ly-don-van-chuyen")]
        public IActionResult GetKhachHang(string MaKhachHang)
        {
            return Ok(_context.DonVanChuyens.Include(m => m.ChiTietTrangThais).Include(m => m.ChiTietDonVanChuyens).Include(m=>m.NhanVienGiaoHang)
                .Where(m => m.MaKhachHang == MaKhachHang)
                .ToList()
                .Select(m =>
                new {
                    m.MaNhanVienGiaoHang,
                    m.SoDienThoaiNguoiGui,
                    m.SoDienThoaiNguoiNhan,
                    m.TenNguoiGui,
                    m.TenNguoiNhan,
                    maTrangThai =m.ChiTietTrangThais.Where(x=>x.ThoiGian.CompareTo(_context.ChiTietTrangThais.Where(a=>a.MaDonVanChuyen==m.MaDonVanChuyen).Max(n=>n.ThoiGian))==0).Single().MaTrangThaiDonVanChuyen,
                    m.ChiTietDonVanChuyens,
                    m.TongTienThuHo,
                    m.CuocPhi,
                    m.NgayTao,
                    m.DiaChiNguoiGui,
                    m.DiaChiNguoiNhan,
                    m.MaVanDon,
                    m.MaDonVanChuyen
                })

                );
        }
        [HttpGet("nhan-vien-giao-hang/quan-ly-don-van-chuyen")]
        public IActionResult GetNhanVienGiaoHang(string maNhanVien)
        {
            return Ok(_context.DonVanChuyens.Include(m => m.ChiTietTrangThais).Include(m => m.ChiTietDonVanChuyens).Include(m => m.NhanVienGiaoHang)
                .Where(m => m.MaNhanVienGiaoHang == maNhanVien)
                .ToList()
                .Select(m =>
                new {
                    m.MaNhanVienGiaoHang,
                    m.SoDienThoaiNguoiGui,
                    m.SoDienThoaiNguoiNhan,
                    m.TenNguoiGui,
                    m.TenNguoiNhan,
                    maTrangThai = m.ChiTietTrangThais.Where(x => x.ThoiGian.CompareTo(_context.ChiTietTrangThais.Where(a => a.MaDonVanChuyen == m.MaDonVanChuyen).Max(n => n.ThoiGian)) == 0).Single().MaTrangThaiDonVanChuyen,
                    m.ChiTietDonVanChuyens,
                    m.TongTienThuHo,
                    m.CuocPhi,
                    m.NgayTao,
                    m.DiaChiNguoiGui,
                    m.DiaChiNguoiNhan,
                    m.MaVanDon,
                    m.MaKhachHang,
                    m.MaDonVanChuyen
                })

                );
        }
        [HttpGet("quan-ly/quan-ly-don-van-chuyen")]
        public IActionResult getQuanLY()
        {
            return Ok(_context.DonVanChuyens.Include(m => m.ChiTietTrangThais).Include(m => m.ChiTietDonVanChuyens).Include(m => m.NhanVienGiaoHang)
                .Where(m => m.ChiTietTrangThais.OrderByDescending(n=>n.ThoiGian).First().MaTrangThaiDonVanChuyen != 13)
                .ToList()
                .Select(m =>
                new {
                    daLayHang = m.ChiTietTrangThais.Where(n=>n.MaDonVanChuyen== m.MaDonVanChuyen && n.MaTrangThaiDonVanChuyen==15).Any(),
                    m.MaNhanVienGiaoHang,
                    m.SoDienThoaiNguoiGui,
                    m.SoDienThoaiNguoiNhan,
                    m.TenNguoiGui,
                    hinhThucVanChuyen = _context.HinhThucVanChuyens.Find(m.MaHinhThucVanChuyen).Ten,
                    m.TenNguoiNhan,
                    maTrangThai = m.ChiTietTrangThais.Where(x => x.ThoiGian.CompareTo(_context.ChiTietTrangThais.Where(a => a.MaDonVanChuyen == m.MaDonVanChuyen).Max(n => n.ThoiGian)) == 0).Single().MaTrangThaiDonVanChuyen,
                    m.ChiTietDonVanChuyens,
                    m.TongTienThuHo,
                    m.CuocPhi,
                    m.NgayTao,
                    m.MaDonVanChuyen,
                    m.DiaChiNguoiGui,
                    m.DiaChiNguoiNhan,
                    m.MaVanDon
                })

                );
        }
        [HttpPost("cap-nhat-don/{id}")]
        public IActionResult CapNhatTrangThai(int id,int maTrangThai,string ghiChu="")
        {
            AddTrangThai(maTrangThai, id, DateTime.Now, ghiChu);
            if (maTrangThai == 16)
            {
                AddTrangThai(17, id, DateTime.Now, "");
            }
            var DonHang = _context.DonVanChuyens.Include(m => m.XaPhuong.QuanHuyen.TinhThanhPho).Where(m => m.MaDonVanChuyen == id).Single();

            // Giao hàng thành công
            if (maTrangThai == 20) {
                //Khách hàng trả cước


                if (_context.TrongLuongs.Where(m=>m.TrongLuongBatDau <= DonHang.TongTrongLuong && m.TrongLuongKetThuc >= DonHang.TongTrongLuong).Any())
                {
                    DonHang.PhiNhanVienGiaoHang =  _context.TrongLuongs.Where(m => m.TrongLuongBatDau <= DonHang.TongTrongLuong && m.TrongLuongKetThuc >= DonHang.TongTrongLuong).Single().PhiNhanVienGiaoHang;
                }
                else
                {
                    var dulieu =_context.DuLieuTinhCuocs.Where(m => m.MaHinhThucVanChuyen == DonHang.MaHinhThucVanChuyen && m.MaTinhThanhPho == DonHang.XaPhuong.QuanHuyen.TinhThanhPho.MaTinhThanhPho)
                        .Single();
                    DonHang.PhiNhanVienGiaoHang = (float)(Math.Ceiling(DonHang.TongTrongLuong - dulieu.TrongLuongBatDau) / dulieu.GiaTriNac) * dulieu.PhiTangNhanVienGiaoHang;
                }
                
                

            }
            //chuyển hoàn thành công
            if (maTrangThai == 19)
            {

                //Khách hàng trả cước


                if (_context.TrongLuongs.Where(m => m.TrongLuongBatDau <= DonHang.TongTrongLuong && m.TrongLuongKetThuc >= DonHang.TongTrongLuong).Any())
                {
                    DonHang.PhiNhanVienGiaoHang = _context.TrongLuongs.Where(m => m.TrongLuongBatDau <= DonHang.TongTrongLuong && m.TrongLuongKetThuc >= DonHang.TongTrongLuong).Single().PhiNhanVienGiaoHang * (float)0.5;
                }
                else
                {
                    var dulieu = _context.DuLieuTinhCuocs.Where(m => m.MaHinhThucVanChuyen == DonHang.MaHinhThucVanChuyen && m.MaTinhThanhPho == DonHang.XaPhuong.QuanHuyen.TinhThanhPho.MaTinhThanhPho)
                        .Single();
                    DonHang.PhiNhanVienGiaoHang =(float)0.5 * (float)Math.Ceiling(DonHang.TongTrongLuong - dulieu.TrongLuongBatDau) / dulieu.GiaTriNac * dulieu.PhiTangNhanVienGiaoHang;
                }



            }
            _context.DonVanChuyens.Update(DonHang);
            _context.SaveChanges();

            return Ok(new
            {
                message = "Đã cập nhật",
                result = true,
            });

        }
        [HttpPost("huy-don/{id}")]
        public IActionResult HuyDon(int id)
        {

            AddTrangThai(13, id, DateTime.Now, "");
            return Ok(new
            {
                message = "Đã hủy",
                result = true,
            });

        }
        [HttpPost("{id}")]
        public IActionResult DuyetDon (int id, string maQuanLy)
        {
            var DonVanChuyen = _context.DonVanChuyens.Where(m => m.MaDonVanChuyen == id).Single();
            DonVanChuyen.MaQuanLy = maQuanLy;
            _context.DonVanChuyens.Update(DonVanChuyen);
            _context.SaveChanges();
            AddTrangThai(12, DonVanChuyen.MaDonVanChuyen, DateTime.Now,"");
            return Ok(new
            {
                message = "Đã duyệt",
                result = true,
            });
            
        }
        [HttpPost("nhan-don/{id}")]
        public IActionResult NhanDon(int id, string maNVGH)
        {
            var DonVanChuyen = _context.DonVanChuyens.Where(m => m.MaDonVanChuyen == id).Single();
            DonVanChuyen.MaVanDon = "VD"+ DateTime.Now.ToString("yymmssfff");
            DonVanChuyen.MaNhanVienGiaoHang = maNVGH;
            _context.DonVanChuyens.Update(DonVanChuyen);
            _context.SaveChanges();
            AddTrangThai(23, DonVanChuyen.MaDonVanChuyen, DateTime.Now,"");
            return Ok(new
            {
                message = "Đã nhận đơn hàng",
                result = true,
            });

        }
        // GET api/<DonVanChuyenController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id=6)
        {
            return Ok(_context.DonVanChuyens.ToList());
        }
       
        [NonAction]
        public void AddChiTiet(ChiTietDonVanChuyen newRecord)
        {
            _context.ChiTietDonVanChuyens.Add(newRecord);
            _context.SaveChanges();
        }
       
        [NonAction]
        private void AddTrangThai (int MaTrangThai, int MaVanChuyen, DateTime NgayTao,string DiaChi)
        {
            var newTT = new ChiTietTrangThai();
            newTT.ThoiGian = NgayTao;
            newTT.DiaChi = DiaChi;
            newTT.MaTrangThaiDonVanChuyen = MaTrangThai;
            newTT.MaDonVanChuyen = MaVanChuyen;
            _context.ChiTietTrangThais.Add(newTT);
            _context.SaveChanges() ;    
        }
        // POST api/<DonVanChuyenController>
        [HttpPost]
        public IActionResult Post( DonVanChuyen newRecord, string VatPham)
        {
            newRecord.NgayTao = DateTime.Now;
            newRecord.MaBaoHiemDonVanChuyen = 1;
                _context.DonVanChuyens.Add(newRecord);
                _context.SaveChanges();

            AddTrangThai(11, newRecord.MaDonVanChuyen, newRecord.NgayTao,"");
               

                if (VatPham.Contains('/'))
                {
                    var list = new List<ChiTietDonVanChuyen>();
                    var VatPhams = VatPham.Split('/');
                    foreach (var v in VatPhams)
                    {
                        var newVatPhamArray = v.Split(',');
                        var newVatPham = new ChiTietDonVanChuyen();
                        newVatPham.TenHangHoa = newVatPhamArray[0];
                        newVatPham.MaLoaiMatHang =int.Parse(newVatPhamArray[1]);
                        newVatPham.ChieuCao = float.Parse(newVatPhamArray[2]);
                        newVatPham.ChieuDai = float.Parse(newVatPhamArray[3]);
                        newVatPham.ChieuRong = float.Parse(newVatPhamArray[4]);
                        newVatPham.TrongLuong = float.Parse(newVatPhamArray[5]);
                        newVatPham.GiaTri = float.Parse(newVatPhamArray[6]);
                        newVatPham.SoLuong = int.Parse(newVatPhamArray[7]);
                        newVatPham.MaDonVanChuyen = newRecord.MaDonVanChuyen;
                       AddChiTiet(newVatPham);
                    }

                }
                else
                {
                    var newVatPhamArray = VatPham.Split(',');
                    var newVatPham = new ChiTietDonVanChuyen();
                newVatPham.TenHangHoa = newVatPhamArray[0];
                newVatPham.MaLoaiMatHang = int.Parse(newVatPhamArray[1]);
                newVatPham.ChieuCao = float.Parse(newVatPhamArray[2]);
                newVatPham.ChieuDai = float.Parse(newVatPhamArray[3]);
                newVatPham.ChieuRong = float.Parse(newVatPhamArray[4]);
                newVatPham.TrongLuong = float.Parse(newVatPhamArray[5]);
                newVatPham.GiaTri = float.Parse(newVatPhamArray[6]);
                newVatPham.SoLuong = int.Parse(newVatPhamArray[7]);
                newVatPham.MaDonVanChuyen = newRecord.MaDonVanChuyen;
                AddChiTiet(newVatPham);

                }
                return Ok(true);
 
            
        }
        [HttpGet("traCuuVanDon/{maVanDon}")]
        public IActionResult TraCuuVanDon (string maVanDon)
        {
            var DonVanChuyen = _context.DonVanChuyens.Where(m => m.MaVanDon == maVanDon).SingleOrDefault();
            
            if (DonVanChuyen == null) return Ok(false);
            else
            {
                var TrangThaiDon = _context.ChiTietTrangThais.Where(m => m.MaDonVanChuyen == DonVanChuyen.MaDonVanChuyen).Include(m => m.TrangThaiDonHang).ToList().OrderBy(n=>n.ThoiGian);
                var ChiTietDon = _context.ChiTietDonVanChuyens.Where(m => m.MaDonVanChuyen == DonVanChuyen.MaDonVanChuyen).ToList();
                return Ok(new {
                   DonVanChuyen,
                   TrangThaiDon,
                   ChiTietDon,
                
                });
            }
            
        }

        // PUT api/<DonVanChuyenController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DonVanChuyenController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _context.ChiTietTrangThais.RemoveRange(_context.ChiTietTrangThais.Where(m => m.MaDonVanChuyen == _context.DonVanChuyens.Find(id).MaDonVanChuyen));
            _context.SaveChanges();
            _context.ChiTietDonVanChuyens.RemoveRange(_context.ChiTietDonVanChuyens.Where(m => m.MaDonVanChuyen == _context.DonVanChuyens.Find(id).MaDonVanChuyen));
            _context.SaveChanges();
            _context.DonVanChuyens.Remove(_context.DonVanChuyens.Find(id));
            _context.SaveChanges();
            return Ok(true);
        }
    }
}
