using LuanVan.Data;
using LuanVan.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuanVan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoanhThuController : ControllerBase

    {
        private readonly MyDbContext _context;
        public DoanhThuController(MyDbContext context)
        {
            _context = context;
        }
        // GET: api/<DoanhThuController>
        [HttpGet("DoanhThuCongTy")]
        public IActionResult Get(string NgayBatDau, string NgayKetThuc)
        {
            var Bd = DateTime.Parse(NgayBatDau);
            var Kt = DateTime.Parse(NgayKetThuc);
            float TienThuVao = 0;
            float TienLuongNhanVienChuaThanhToan = 0;
            float TienChuaChuyenKhoanChoKhach = 0;
            float TienDaChuyenKhoanChoKhach = 0;
            float TienLuongNhanVienDaThanhToan = 0;
            float TienNhanVienConNo = 0;
            float TienKhachHangConNo = 0;
            float DoanhThu = 0;
            
            foreach(var item in _context.DonVanChuyens.Include(m=>m.ChiTietTrangThais).Where(m=> m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First()
            .ThoiGian.Date.CompareTo(Bd)>=0 && m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().ThoiGian.Date.CompareTo(Kt)<=0&& (m.ChiTietTrangThais.Where(x=>x.MaDonVanChuyen==m.MaDonVanChuyen).OrderByDescending(x=>x.ThoiGian).First().MaTrangThaiDonVanChuyen == 19
                || m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)).ToList()
                ){
                if(item.ChiTietTrangThais.OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)
                {
                    DoanhThu += item.CuocPhi - (float)item.PhiNhanVienGiaoHang;
                }
                else
                {
                    DoanhThu += item.CuocPhi * (float)0.5 - (float)item.PhiNhanVienGiaoHang;
                }
               if(item.ChiTietTrangThais.OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)
                {
                    if(item.NguoiTraCuoc==false)
                    {
                        if (item.NgayThanhToanCuocPhi == null)
                            TienKhachHangConNo += item.CuocPhi;
                        else TienThuVao += item.CuocPhi;
                        if (item.NgayThanhToanTienThuHo == null)
                            TienNhanVienConNo += item.TongTienThuHo;
                        else TienThuVao += item.TongTienThuHo;
                    }
                    else
                    {
                        if (item.NgayThanhToanTienThuHo == null)
                            TienNhanVienConNo += item.TongTienThuHo;
                        else
                            TienThuVao += item.TongTienThuHo - item.CuocPhi;
                    }
                    if (item.NgayThanhToanPhiNhanVienGiaoHang == null)
                        TienLuongNhanVienChuaThanhToan += (float)item.PhiNhanVienGiaoHang;
                    else
                        TienLuongNhanVienDaThanhToan += (float)item.PhiNhanVienGiaoHang;
                    if (item.NgayThanhToanTienThuHoKh == null)
                    {
                        if (item.NguoiTraCuoc == true)
                        {
                            TienChuaChuyenKhoanChoKhach += item.TongTienThuHo - item.CuocPhi;
                        }
                        else
                        {
                            TienChuaChuyenKhoanChoKhach += item.TongTienThuHo;
                        }    
                       
                    }
                    else
                    {
                        if (item.NguoiTraCuoc == false)
                        {
                            TienDaChuyenKhoanChoKhach += item.TongTienThuHo - item.CuocPhi;
                        }
                        else
                        {
                            TienDaChuyenKhoanChoKhach += item.TongTienThuHo;
                        }
                    }
                }
                else
                {
                        if (item.NgayThanhToanCuocPhi == null)
                            TienKhachHangConNo += item.CuocPhi * (float)0.5;
                        else TienThuVao += item.CuocPhi * (float)0.5;
                    if (item.NgayThanhToanPhiNhanVienGiaoHang == null)
                            TienLuongNhanVienChuaThanhToan += (float)item.PhiNhanVienGiaoHang;
                        else
                            TienLuongNhanVienDaThanhToan += (float)item.PhiNhanVienGiaoHang;
                }
            }

            return Ok(new
            {
                TienThuVao = TienThuVao,
                TienChuaChuyenKhoanChoKhach = TienChuaChuyenKhoanChoKhach,
                TienDaChuyenKhoanChoKhach = TienDaChuyenKhoanChoKhach,
                TienKhachHangConNo = TienKhachHangConNo,
                TienNhanVienConNo = TienNhanVienConNo,
                TienLuongNhanVienDaThanhToan = TienLuongNhanVienDaThanhToan,
                TienLuongNhanVienChuaThanhToan = TienLuongNhanVienChuaThanhToan,
                DoanhThu = DoanhThu
            });
        }
        [HttpGet("Thu")]
        public IActionResult TongThu(string NgayBatDau, string NgayKetThuc)
        {
            var Bd = DateTime.Parse(NgayBatDau);
            var Kt = DateTime.Parse(NgayKetThuc);
            float TienThuVao = 0;
            var ghiChu = "";
            var ThanhToan = false;
            var objs = new List<Object>();
            foreach (var item in _context.DonVanChuyens.Include(m => m.ChiTietTrangThais).Where(m => m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First()
           .ThoiGian.Date.CompareTo(Bd) >= 0 && m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().ThoiGian.Date.CompareTo(Kt) <= 0 && (m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 19
               || m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)).ToList()
               )
            {
                if (item.ChiTietTrangThais.OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)
                {

                    if (item.NguoiTraCuoc == false)
                    {

                        if (item.NgayThanhToanCuocPhi != null)
                        {
                            ghiChu = "Cước phí vận chuyển";
                            ThanhToan = true;
                            TienThuVao = item.CuocPhi;
                            objs.Add(new
                            {
                                maDonHang = item.MaVanDon,
                                thanhToan = ThanhToan,
                                soTien = TienThuVao,
                                ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                                ghiChu = ghiChu
                            });
                        }
                        else
                        {
                            ghiChu = "Cước phí vận chuyển";
                            ThanhToan = false;
                            TienThuVao = item.CuocPhi;
                            objs.Add(new
                            {
                                maDonHang = item.MaVanDon,
                                thanhToan = ThanhToan,
                                soTien = TienThuVao,
                                ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                                ghiChu = ghiChu
                            });
                        }
                        if (item.NgayThanhToanTienThuHo != null)
                        {
                            ghiChu = "Tiền thu hộ đơn vận chuyển";
                            ThanhToan = true;
                            TienThuVao = item.TongTienThuHo;
                            objs.Add(new
                            {
                                maDonHang = item.MaVanDon,
                                thanhToan = ThanhToan,
                                soTien = TienThuVao,
                                ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                                ghiChu = ghiChu
                            });
                        }
                        else
                        {
                            ThanhToan = false;
                            ghiChu = "Tiền thu hộ đơn vận chuyển";
                            TienThuVao = item.TongTienThuHo;
                            objs.Add(new
                            {
                                maDonHang = item.MaVanDon,
                                thanhToan = ThanhToan,
                                soTien = TienThuVao,
                                ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                                ghiChu = ghiChu
                            });
                        }
                    }
                    else
                    {


                        if (item.NgayThanhToanTienThuHo != null)
                        {
                            ghiChu = "Tiền thu hộ đơn vận chuyển";
                            ThanhToan = true;
                            TienThuVao = item.TongTienThuHo - item.CuocPhi;
                            objs.Add(new
                            {
                                maDonHang = item.MaVanDon,
                                thanhToan = ThanhToan,
                                soTien = TienThuVao,
                                ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                                ghiChu = ghiChu
                            });
                        }
                        else
                        {
                            ThanhToan = false;
                            ghiChu = "Tiền thu hộ đơn vận chuyển";
                            TienThuVao = item.TongTienThuHo - item.CuocPhi;
                            objs.Add(new
                            {
                                maDonHang = item.MaVanDon,
                                thanhToan = ThanhToan,
                                soTien = TienThuVao,
                                ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                                ghiChu = ghiChu
                            });
                        }


                    }
                }



                else
                {
                    ghiChu = "Cước phí hoàn đơn";
                    if (item.NgayThanhToanCuocPhi == null)
                    {
                        ThanhToan = false;
                        TienThuVao = item.CuocPhi * (float)0.5;
                    }
                    else
                    {
                        ThanhToan = true;
                        TienThuVao = item.CuocPhi * (float)0.5;
                    }
                    objs.Add(new
                    {
                        maDonHang = item.MaVanDon,
                        thanhToan = ThanhToan,
                        soTien = TienThuVao,
                        ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                        ghiChu = ghiChu
                    });
                }
             
            }
            return Ok(objs);
        }
           
               
        
        [HttpGet("Chi")]
        public IActionResult TongChi(string NgayBatDau, string NgayKetThuc)
        {
            var Bd = DateTime.Parse(NgayBatDau);
            var Kt = DateTime.Parse(NgayKetThuc);
            float tienChi = 0;
            var ThanhToan = false;
            var ghiChu = "";
            var objs = new List<Object>();
            foreach (var item in _context.DonVanChuyens.Include(m => m.ChiTietTrangThais).Where(m => m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First()
           .ThoiGian.Date.CompareTo(Bd) >= 0 && m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().ThoiGian.Date.CompareTo(Kt) <= 0 && (m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 19
               || m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)).ToList()
               )
            {
                if (item.ChiTietTrangThais.OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)
                {



                    if (item.NgayThanhToanPhiNhanVienGiaoHang == null)
                    {
                        ghiChu = "Phí giao hàng";
                        tienChi = (float)item.PhiNhanVienGiaoHang;
                        ThanhToan = false;
                        objs.Add(new
                        {
                            maDonHang = item.MaVanDon,
                            thanhToan = ThanhToan,
                            soTien = tienChi,
                            ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                            ghiChu = ghiChu
                        });
                    }
                    else
                    {
                        ghiChu = "Phí giao hàng";
                        tienChi = (float)item.PhiNhanVienGiaoHang;
                        ThanhToan = true;
                        objs.Add(new
                        {
                            maDonHang = item.MaVanDon,
                            thanhToan = ThanhToan,
                            soTien = tienChi,
                            ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                            ghiChu = ghiChu
                        });
                    }
                   
                    if (item.NgayThanhToanTienThuHoKh == null)
                    {
                        if(item.NguoiTraCuoc == false)
                        {
                            ThanhToan = false;
                            ghiChu = "Tiền thu hộ khách hàng";
                            tienChi = item.TongTienThuHo;
                            objs.Add(new
                            {
                                maDonHang = item.MaVanDon,
                                thanhToan = ThanhToan,
                                soTien = tienChi,
                                ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                                ghiChu = ghiChu
                            });
                        }
                        else
                        {
                            ThanhToan = false;
                            ghiChu = "Tiền thu hộ khách hàng";
                            tienChi = item.TongTienThuHo - item.CuocPhi;
                            objs.Add(new
                            {
                                maDonHang = item.MaVanDon,
                                thanhToan = ThanhToan,
                                soTien = tienChi,
                                ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                                ghiChu = ghiChu
                            });
                        }
                    }
                    else
                    {
                        if(item.NguoiTraCuoc == false)
                        {
                            ThanhToan = true;
                            ghiChu = "Tiền thu hộ khách hàng";
                            tienChi = item.TongTienThuHo ;
                            objs.Add(new
                            {
                                maDonHang = item.MaVanDon,
                                thanhToan = ThanhToan,
                                soTien = tienChi,
                                ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                                ghiChu = ghiChu
                            });
                        }
                        else
                        {
                            ThanhToan = true;
                            ghiChu = "Tiền thu hộ khách hàng";
                            tienChi = item.TongTienThuHo - item.CuocPhi;
                            objs.Add(new
                            {
                                maDonHang = item.MaVanDon,
                                thanhToan = ThanhToan,
                                soTien = tienChi,
                                ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                                ghiChu = ghiChu
                            });
                        }
                       
                    }
                }
                else
                {

                    if (item.NgayThanhToanPhiNhanVienGiaoHang == null)
                    {
                        ghiChu = "Phí hoàn đơn";
                        tienChi = (float)item.PhiNhanVienGiaoHang;
                        ThanhToan = false;
                        objs.Add(new
                        {
                            maDonHang = item.MaVanDon,
                            thanhToan = ThanhToan,
                            soTien = tienChi,
                            ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                            ghiChu = ghiChu
                        });
                    }
                    else
                    {
                        ghiChu = "Phí hoàn đơn";
                        tienChi = (float)item.PhiNhanVienGiaoHang;
                        ThanhToan = true;
                        objs.Add(new
                        {
                            maDonHang = item.MaVanDon,
                            thanhToan = ThanhToan,
                            soTien = tienChi,
                            ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                            ghiChu = ghiChu
                        });
                    }

                }
            }
            return Ok(objs);
        }
        // GET api/<DoanhThuController>/5
        [HttpGet("TienThuVao")]
        public IActionResult GetTienThuvao(string NgayBatDau, string NgayKetThuc)
        {
            var Bd = DateTime.Parse(NgayBatDau);
            var Kt = DateTime.Parse(NgayKetThuc);
            float tienChi = 0;
            var ThanhToan = false;
            var ghiChu = "";
            var objs = new List<Object>();
            foreach (var item in _context.DonVanChuyens.Include(m => m.ChiTietTrangThais).Where(m => m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First()
           .ThoiGian.Date.CompareTo(Bd) >= 0 && m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().ThoiGian.Date.CompareTo(Kt) <= 0 && (m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 19
               || m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)).ToList()
               )
            {
                if (item.ChiTietTrangThais.OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)
                {


                    if (item.NgayThanhToanTienThuHo != null)
                    {
                        ghiChu = "Tiền thu hộ đơn vận chuyển";
                        tienChi = item.TongTienThuHo ;
                        objs.Add(new
                        {
                            maDonHang = item.MaVanDon,
                            thanhToan = ThanhToan,
                            soTien = tienChi,
                            ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                            ghiChu = ghiChu
                        });
                    }
                    if (item.NguoiTraCuoc == false)
                    {
                        if (item.NgayThanhToanCuocPhi != null)
                        {
                            ghiChu = "Cước phí đơn vận chuyển";
                            tienChi = (float)item.CuocPhi ;
                            ThanhToan = false;
                            objs.Add(new
                            {
                                maDonHang = item.MaVanDon,
                                thanhToan = ThanhToan,
                                soTien = tienChi,
                                ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                                ghiChu = ghiChu
                            });
                        }
                    }
                  
                   
                }
                else
                {
                    if (item.NguoiTraCuoc==false)
                    {
                        if (item.NgayThanhToanCuocPhi != null)
                        {
                            ghiChu = "Cước phí đơn vận chuyển";
                            tienChi = (float)item.CuocPhi * (float)0.5;
                            ThanhToan = false;
                            objs.Add(new
                            {
                                maDonHang = item.MaVanDon,
                                thanhToan = ThanhToan,
                                soTien = tienChi,
                                ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                                ghiChu = ghiChu
                            });
                        }
                    }
                   
                }
            }
            return Ok(objs);
        }
        [HttpGet("TienChuaChuyenChoKhachHang")]
        public IActionResult GetTienChuaChuyenChoKhachHang(string NgayBatDau, string NgayKetThuc)
        {
            var Bd = DateTime.Parse(NgayBatDau);
            var Kt = DateTime.Parse(NgayKetThuc);
            float tienChi = 0;
            var ThanhToan = false;
            var ghiChu = "";
            var objs = new List<Object>();
            foreach (var item in _context.DonVanChuyens.Include(m => m.ChiTietTrangThais).Where(m => m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First()
           .ThoiGian.Date.CompareTo(Bd) >= 0 && m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().ThoiGian.Date.CompareTo(Kt) <= 0 && (m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 19
               || m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)).ToList()
               )
            {
                if (item.ChiTietTrangThais.OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)
                {

                    if (item.NgayThanhToanTienThuHoKh == null)
                    {
                        if(item.NguoiTraCuoc == true)
                        {
                            ThanhToan = false;
                            ghiChu = "Tiền thu hộ khách hàng";
                            tienChi = item.TongTienThuHo - item.CuocPhi;
                          
                        }
                        else
                        {
                            ThanhToan = false;
                            ghiChu = "Tiền thu hộ khách hàng";
                            tienChi = item.TongTienThuHo;
                        }
                        objs.Add(new
                        {
                            maDonHang = item.MaVanDon,
                            thanhToan = ThanhToan,
                            soTien = tienChi,
                            ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                            ghiChu = ghiChu
                        });
                    }

                }
                
            }
            return Ok(objs);
        }
        [HttpGet("TienKhachHangConNo")]
        public IActionResult TienKhachHangConNo(string NgayBatDau, string NgayKetThuc)
        {
            var Bd = DateTime.Parse(NgayBatDau);
            var Kt = DateTime.Parse(NgayKetThuc);
            float TienThuVao = 0;
            var ghiChu = "";
            var ThanhToan = false;
            var objs = new List<Object>();
            foreach (var item in _context.DonVanChuyens.Include(m => m.ChiTietTrangThais).Where(m => m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First()
           .ThoiGian.Date.CompareTo(Bd) >= 0 && m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().ThoiGian.Date.CompareTo(Kt) <= 0 && (m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 19
               || m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)).ToList()
               )
            {
                if (item.ChiTietTrangThais.OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20 && item.NgayThanhToanCuocPhi == null)
                {

                    if (item.NguoiTraCuoc == false)
                    {
                        ghiChu = "Cước phí vận chuyển";
                        if (item.NgayThanhToanCuocPhi == null)
                        {
                            TienThuVao = item.CuocPhi;
                        }

                        objs.Add(new
                        {
                            maDonHang = item.MaVanDon,
                            thanhToan = ThanhToan,
                            soTien = TienThuVao,
                            ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                            ghiChu = ghiChu
                        });

                    }



                }
                else if(item.NgayThanhToanCuocPhi == null)
                {
                    ghiChu = "Cước phí hoàn đơn";
                    if (item.NguoiTraCuoc == false)
                    {
                        if (item.NgayThanhToanCuocPhi == null)
                        {
                            ThanhToan = false;
                            TienThuVao = item.CuocPhi * (float)0.5;
                        }

                        objs.Add(new
                        {
                            maDonHang = item.MaVanDon,
                            thanhToan = ThanhToan,
                            soTien = TienThuVao,
                            ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                            ghiChu = ghiChu
                        });
                    }
                }
            }
            return Ok(objs);
        }
        [HttpGet("TienLuongNhanVienChuaThanhToan")]
        public IActionResult TienLuongNhanVienChuaThanhToan(string NgayBatDau, string NgayKetThuc)
        {
            var Bd = DateTime.Parse(NgayBatDau);
            var Kt = DateTime.Parse(NgayKetThuc);
            float tienChi = 0;
            var ThanhToan = false;
            var ghiChu = "";
            var objs = new List<Object>();
            foreach (var item in _context.DonVanChuyens.Include(m => m.ChiTietTrangThais).Where(m => m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First()
           .ThoiGian.Date.CompareTo(Bd) >= 0 && m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().ThoiGian.Date.CompareTo(Kt) <= 0 && (m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 19
               || m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)).ToList()
               )
            {
                if (item.ChiTietTrangThais.OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)
                {



                    if (item.NgayThanhToanPhiNhanVienGiaoHang == null)
                    {
                        ghiChu = "Phí giao hàng";
                        tienChi = (float)item.PhiNhanVienGiaoHang;
                        ThanhToan = false;
                        objs.Add(new
                        {
                            maDonHang = item.MaVanDon,
                            thanhToan = ThanhToan,
                            soTien = tienChi,
                            ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                            ghiChu = ghiChu
                        });
                    }
                }

                else
                {

                    if (item.NgayThanhToanPhiNhanVienGiaoHang == null)
                    {
                        ghiChu = "Phí hoàn đơn nhân viên giao hàng ";
                        tienChi = (float)item.PhiNhanVienGiaoHang;
                        ThanhToan = false;
                        objs.Add(new
                        {
                            maDonHang = item.MaVanDon,
                            thanhToan = ThanhToan,
                            soTien = tienChi,
                            ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                            ghiChu = ghiChu
                        });
                    }


                }
                

            }
            return Ok(objs);
        }
        [HttpGet("TienLuongNhanVienDaThanhToan")]
        public IActionResult TienLuongNhanVienDaThanhToan(string NgayBatDau, string NgayKetThuc)
        {
            var Bd = DateTime.Parse(NgayBatDau);
            var Kt = DateTime.Parse(NgayKetThuc);
            float tienChi = 0;
            var ThanhToan = false;
            var ghiChu = "";
            var objs = new List<Object>();
            foreach (var item in _context.DonVanChuyens.Include(m => m.ChiTietTrangThais).Where(m => m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First()
           .ThoiGian.Date.CompareTo(Bd) >= 0 && m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().ThoiGian.Date.CompareTo(Kt) <= 0 && (m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 19
               || m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)).ToList()
               )
            {
                if (item.ChiTietTrangThais.OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)
                {



                    if (item.NgayThanhToanPhiNhanVienGiaoHang != null)
                    {
                        ghiChu = "Phí giao hàng";
                        tienChi = (float)item.PhiNhanVienGiaoHang;
                        ThanhToan = false;
                        objs.Add(new
                        {
                            maDonHang = item.MaVanDon,
                            thanhToan = ThanhToan,
                            soTien = tienChi,
                            ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                            ghiChu = ghiChu
                        });
                    }
                }

                else
                {

                    if (item.NgayThanhToanPhiNhanVienGiaoHang != null)
                    {
                        ghiChu = "Phí hoàn đơn nhân viên giao hàng ";
                        tienChi = (float)item.PhiNhanVienGiaoHang;
                        ThanhToan = false;
                        objs.Add(new
                        {
                            maDonHang = item.MaVanDon,
                            thanhToan = ThanhToan,
                            soTien = tienChi,
                            ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                            ghiChu = ghiChu
                        });
                    }


                }


            }
            return Ok(objs);
        }
        [HttpGet("TienNhanVienGiaoHangConNo")]
        public IActionResult TienNhanVienGiaoHangConNo(string NgayBatDau, string NgayKetThuc)
        {
            var Bd = DateTime.Parse(NgayBatDau);
            var Kt = DateTime.Parse(NgayKetThuc);
            float TienThuVao = 0;
            var ghiChu = "";
            var ThanhToan = false;
            var objs = new List<Object>();
            foreach (var item in _context.DonVanChuyens.Include(m => m.ChiTietTrangThais).Where(m => m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First()
           .ThoiGian.Date.CompareTo(Bd) >= 0 && m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().ThoiGian.Date.CompareTo(Kt) <= 0 && (m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 19
               || m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)).ToList()
               )
            {
                if (item.ChiTietTrangThais.OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)
                {

                  
                    
                        ghiChu = "Tiền thu hộ đơn vận chuyển";
                        if (item.NgayThanhToanTienThuHo == null)
                        {
                            TienThuVao = item.TongTienThuHo;
                        }

                        objs.Add(new
                        {
                            maDonHang = item.MaVanDon,
                            thanhToan = ThanhToan,
                            soTien = TienThuVao,
                            ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                            ghiChu = ghiChu
                        });

                    
                  



                }
            }
            return Ok(objs);
        }
        [HttpGet("TienDaChuyenChoKhachHang")]
        public IActionResult GetTienDaChuyenChoKhachHang(string NgayBatDau, string NgayKetThuc)
        {
            var Bd = DateTime.Parse(NgayBatDau);
            var Kt = DateTime.Parse(NgayKetThuc);
            float TienThuVao = 0;
            var ghiChu = "";
            var ThanhToan = false;
            var objs = new List<Object>();
            foreach (var item in _context.DonVanChuyens.Include(m => m.ChiTietTrangThais).Where(m => m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First()
           .ThoiGian.Date.CompareTo(Bd) >= 0 && m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().ThoiGian.Date.CompareTo(Kt) <= 0 && (m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 19
               || m.ChiTietTrangThais.Where(x => x.MaDonVanChuyen == m.MaDonVanChuyen).OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)).ToList()
               )
            {
                if (item.ChiTietTrangThais.OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20 && item.NgayThanhToanTienThuHoKh!=null)
                {

                    if (item.NguoiTraCuoc == false)
                    {
                        ghiChu = "Tiền thu hộ đơn vận chuyển";
                       
                            TienThuVao = item.TongTienThuHo;
                        

                        objs.Add(new
                        {
                            maDonHang = item.MaVanDon,
                            thanhToan = ThanhToan,
                            soTien = TienThuVao,
                            ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                            ghiChu = ghiChu
                        });

                    }
                    else if (item.ChiTietTrangThais.OrderByDescending(x => x.ThoiGian).First().MaTrangThaiDonVanChuyen == 20)
                    {
                        ghiChu = "Tiền thu hộ đơn vận chuyển";
                       
                            TienThuVao = item.TongTienThuHo - item.CuocPhi;
                        

                        objs.Add(new
                        {
                            maDonHang = item.MaVanDon,
                            thanhToan = ThanhToan,
                            soTien = TienThuVao,
                            ngayThuVao = item.ChiTietTrangThais.OrderByDescending(m => m.ThoiGian).First().ThoiGian,
                            ghiChu = ghiChu
                        });
                    }

                }
               
            }
            return Ok(objs);
        }

        // POST api/<DoanhThuController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DoanhThuController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DoanhThuController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
