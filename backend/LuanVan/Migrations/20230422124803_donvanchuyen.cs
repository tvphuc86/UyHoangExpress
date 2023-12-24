using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class donvanchuyen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SoDienThoaiNguoiNhanCap3",
                table: "NguoiNhanCap3",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SoDienThoaiCaNhan",
                table: "NguoiNhanCaNhan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "GiaTri",
                table: "MatHangCaNhan",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "DonVanChuyen",
                columns: table => new
                {
                    MaDonVanChuyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaVanDon = table.Column<int>(type: "int", nullable: false),
                    MaHinhThucVanChuyen = table.Column<int>(type: "int", nullable: false),
                    MaXaPhuong = table.Column<long>(type: "bigint", nullable: false),
                    XaPhuongMaXaPhuong = table.Column<long>(type: "bigint", nullable: false),
                    TenNguoiNhan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChiNguoiNhan = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TenNguoiGui = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChiNguoiGui = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SoDienThoaiNguoiGui = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoaiNguoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaKhachHang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaNhanVienGiaoHang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaQuanLy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TongTrongLuong = table.Column<float>(type: "real", nullable: false),
                    TongTienThuHo = table.Column<float>(type: "real", nullable: false),
                    CuocPhi = table.Column<float>(type: "real", nullable: false),
                    NguoiTraCuoc = table.Column<bool>(type: "bit", nullable: false),
                    ThoiGianGiao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YeuCauLayHang = table.Column<bool>(type: "bit", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonVanChuyen", x => x.MaDonVanChuyen);
                    table.ForeignKey(
                        name: "FK_DonVanChuyen_TaiKhoan_MaKhachHang",
                        column: x => x.MaKhachHang,
                        principalTable: "TaiKhoan",
                        principalColumn: "MaTaiKhoan");
                    table.ForeignKey(
                        name: "FK_DonVanChuyen_TaiKhoan_MaNhanVienGiaoHang",
                        column: x => x.MaNhanVienGiaoHang,
                        principalTable: "TaiKhoan",
                        principalColumn: "MaTaiKhoan");
                    table.ForeignKey(
                        name: "FK_DonVanChuyen_TaiKhoan_MaQuanLy",
                        column: x => x.MaQuanLy,
                        principalTable: "TaiKhoan",
                        principalColumn: "MaTaiKhoan");
                    table.ForeignKey(
                        name: "FK_DonVanChuyen_XaPhuong_XaPhuongMaXaPhuong",
                        column: x => x.XaPhuongMaXaPhuong,
                        principalTable: "XaPhuong",
                        principalColumn: "MaXaPhuong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonVanChuyen",
                columns: table => new
                {
                    MaChiTietDonVanChuyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHangHoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChieuCao = table.Column<float>(type: "real", nullable: false),
                    ChieuRong = table.Column<float>(type: "real", nullable: false),
                    ChieuDai = table.Column<float>(type: "real", nullable: false),
                    GiaTri = table.Column<float>(type: "real", nullable: false),
                    TrongLuong = table.Column<float>(type: "real", nullable: false),
                    MaDonVanChuyen = table.Column<int>(type: "int", nullable: false),
                    DonVanChuyenMaDonVanChuyen = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonVanChuyen", x => x.MaChiTietDonVanChuyen);
                    table.ForeignKey(
                        name: "FK_ChiTietDonVanChuyen_DonVanChuyen_DonVanChuyenMaDonVanChuyen",
                        column: x => x.DonVanChuyenMaDonVanChuyen,
                        principalTable: "DonVanChuyen",
                        principalColumn: "MaDonVanChuyen");
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiDonHang",
                columns: table => new
                {
                    MaTrangThaiDonHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DonVanChuyenMaDonVanChuyen = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThaiDonHang", x => x.MaTrangThaiDonHang);
                    table.ForeignKey(
                        name: "FK_TrangThaiDonHang_DonVanChuyen_DonVanChuyenMaDonVanChuyen",
                        column: x => x.DonVanChuyenMaDonVanChuyen,
                        principalTable: "DonVanChuyen",
                        principalColumn: "MaDonVanChuyen");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonVanChuyen_DonVanChuyenMaDonVanChuyen",
                table: "ChiTietDonVanChuyen",
                column: "DonVanChuyenMaDonVanChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_DonVanChuyen_MaKhachHang",
                table: "DonVanChuyen",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DonVanChuyen_MaNhanVienGiaoHang",
                table: "DonVanChuyen",
                column: "MaNhanVienGiaoHang");

            migrationBuilder.CreateIndex(
                name: "IX_DonVanChuyen_MaQuanLy",
                table: "DonVanChuyen",
                column: "MaQuanLy");

            migrationBuilder.CreateIndex(
                name: "IX_DonVanChuyen_XaPhuongMaXaPhuong",
                table: "DonVanChuyen",
                column: "XaPhuongMaXaPhuong");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiDonHang_DonVanChuyenMaDonVanChuyen",
                table: "TrangThaiDonHang",
                column: "DonVanChuyenMaDonVanChuyen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDonVanChuyen");

            migrationBuilder.DropTable(
                name: "TrangThaiDonHang");

            migrationBuilder.DropTable(
                name: "DonVanChuyen");

            migrationBuilder.DropColumn(
                name: "SoDienThoaiNguoiNhanCap3",
                table: "NguoiNhanCap3");

            migrationBuilder.DropColumn(
                name: "SoDienThoaiCaNhan",
                table: "NguoiNhanCaNhan");

            migrationBuilder.DropColumn(
                name: "GiaTri",
                table: "MatHangCaNhan");
        }
    }
}
