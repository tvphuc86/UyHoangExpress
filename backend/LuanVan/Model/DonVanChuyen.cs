using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("DonVanChuyen")]
    public class DonVanChuyen
    {
        [Key]
        public int MaDonVanChuyen { get; set; }
        [MaxLength(20)]
        public string? MaVanDon { get; set; }
        public int MaHinhThucVanChuyen { get; set; }

        public long MaXaPhuong { get; set; }
        public virtual XaPhuong? XaPhuong { get; set; }
        [Required]
        [MaxLength(50)]
        public string TenNguoiNhan { get; set; }
        [Required]
        [MaxLength(200)]
        public string DiaChiNguoiNhan { get; set; }
        [Required]
        [MaxLength(50)]
        public string TenNguoiGui { get; set; }
        [Required]
        [MaxLength(200)]
        public string   DiaChiNguoiGui { get; set; }
        [Required]
         public string SoDienThoaiNguoiGui { get;set; }
        [Required]
        public string SoDienThoaiNguoiNhan { get;set; }
        [Required]
        [MaxLength(20)]
        public string MaKhachHang { get; set; }
        public virtual TaiKhoan? KhachHang { get;set; }
        [MaxLength(20)]
        public string? MaNhanVienGiaoHang { get; set; }
        public virtual TaiKhoan? NhanVienGiaoHang { get; set; }
        [MaxLength(20)]
        public string? MaQuanLy { get; set; }
        public virtual TaiKhoan? QuanLy { get; set; }
        public float TongTrongLuong { get; set; }
        public float TongTienThuHo { get; set; }
        public float CuocPhi { get; set; }
        public bool NguoiTraCuoc { get; set; }
        public string ThoiGianGiao { get;set; }
        public bool YeuCauLayHang { get; set; }
        public DateTime NgayTao { get; set; }

        public DateTime? NgayThanhToanCuocPhi { get; set; }

        public DateTime? NgayThanhToanTienThuHo { get; set; }

        public DateTime? NgayThanhToanTienThuHoKh { get; set; }

        public float? PhiNhanVienGiaoHang { get; set; }

        public DateTime? NgayThanhToanPhiNhanVienGiaoHang { get; set; }
        public string? GhiChu { get; set; }
        public virtual List<ChiTietDonVanChuyen>? ChiTietDonVanChuyens { get; set; }
        public virtual List<ChiTietTrangThai>? ChiTietTrangThais { get; set; }

        public int MaBaoHiemDonVanChuyen { get; set; }

        [ForeignKey("MaBaoHiemDonVanChuyen")]
        public BaoHiemDonVanChuyen? BaoHiemDonVanChuyen { get; set; }


    }
}
