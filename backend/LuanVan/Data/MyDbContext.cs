using LuanVan.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LuanVan.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options) { }
       
        public DbSet<HinhThucVanChuyen> HinhThucVanChuyens { get; set; }
        public DbSet<TinhThanhPho> TinhThanhPhos { get; set; }
        
        public DbSet<QuanHuyen> QuanHuyens { get; set;}

        public DbSet<XaPhuong> XaPhuongs { get; set; }

        public DbSet<CuocPhi> CuocPhis { get; set;}
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<VaiTro>    VaiTros { get; set; }
        public DbSet<CoVaiTro> CoVaiTros { get; set; }
        public DbSet<Quyen> Quyens { get; set; }
        public DbSet<ChiTietVaiTro> ChiTietVaiTros { get; set; }
        public DbSet<ChiTietCuocPhi> ChiTietCuocPhis { get; set; }
        public DbSet<DuLieuTinhCuoc> DuLieuTinhCuocs { get; set; }
        public DbSet<TrongLuong> TrongLuongs { get; set; }
        public DbSet<NguoiNhanCap3> NguoiNhanCap { get; set; }
        public DbSet<NguoiNhanCaNhan> NguoiNhanCaNhans { get; set; }
        public DbSet<MatHangCaNhan> MatHangCaNhans { get; set; }
        public DbSet<DonVanChuyen> DonVanChuyens { get; set; }
        public DbSet<ChiTietDonVanChuyen> ChiTietDonVanChuyens { get; set; }
        public DbSet<TrangThaiDonHang> TrangThaiDonHangs { get; set; }
        public DbSet<ChiTietTrangThai> ChiTietTrangThais { get; set; }
        public DbSet<SoDiaChi> SoDiaChis { get; set; }
        public DbSet<ThongBao> ThongBaos { get; set; }

        public DbSet<BaoHiemDonVanChuyen> BaoHiemDonVanChuyens { get; set; }

        public DbSet<LoaiMatHang> LoaiMatHangs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoVaiTro>(e =>
            {
                e.HasKey(m => new { m.MaVaiTro, m.MaTaiKhoan });
            });
            modelBuilder.Entity<ChiTietVaiTro>(e =>
            {
                e.HasKey(o => new { o.MaQuyen, o.MaVaiTro });
            });
            modelBuilder.Entity<ChiTietCuocPhi>(e =>
            {
                e.HasKey(o => new { o.MaCuocPhi, o.MaQuanHuyen });
            });
            modelBuilder.Entity<ChiTietTrangThai>(e =>
            {
                e.HasKey(o => new { o.MaDonVanChuyen, o.MaTrangThaiDonVanChuyen, o.ThoiGian });
            });
            modelBuilder.Entity<ChiTietCuocPhi>()
                .HasOne(m => m.QuanHuyen)
                .WithMany(m => m.ChiTietCuocPhis)
                .HasForeignKey(m => m.MaQuanHuyen).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<ChiTietCuocPhi>()
              .HasOne(m => m.CuocPhi)
              .WithMany(m => m.ChiTietCuocPhis)
              .HasForeignKey(m => m.MaCuocPhi).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<NguoiNhanCap3>()
              .HasOne(m => m.XaPhuong)
              .WithMany(m => m.NguoiNhanCap3s)
              .HasForeignKey(m => m.MaXaPhuong).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<NguoiNhanCap3>()
              .HasOne(m => m.NguoiNhanCaNhan)
              .WithMany(m => m.NguoiNhanCap3s)
              .HasForeignKey(m => m.MaNguoiNhan).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<DonVanChuyen>()
                .HasOne(m=>m.QuanLy)
                .WithMany(m=>m.DonDuyets)
                .HasForeignKey(m=>m.MaQuanLy).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<DonVanChuyen>()
              .HasOne(m => m.NhanVienGiaoHang)
              .WithMany(m => m.DonNhanGiaos)
              .HasForeignKey(m => m.MaNhanVienGiaoHang).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<DonVanChuyen>()
              .HasOne(m => m.KhachHang)
              .WithMany(m => m.DonVanChuyens)
              .HasForeignKey(m => m.MaKhachHang).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<ChiTietTrangThai>()
             .HasOne(m => m.DonVanChuyen)
             .WithMany(m => m.ChiTietTrangThais)
             .HasForeignKey(m => m.MaDonVanChuyen).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<ChiTietTrangThai>()
             .HasOne(m => m.TrangThaiDonHang)
             .WithMany(m => m.ChiTietTrangThais)
             .HasForeignKey(m => m.MaTrangThaiDonVanChuyen).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
