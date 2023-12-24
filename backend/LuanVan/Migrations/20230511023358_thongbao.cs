using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class thongbao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoanhThuCongTy");

            migrationBuilder.DropTable(
                name: "DoanhThuKhachHang");

            migrationBuilder.DropTable(
                name: "NoKhachHang");

            migrationBuilder.DropTable(
                name: "NoNhanVienGiaoHang");

            migrationBuilder.DropTable(
                name: "PhiNhanVienGiaoHang");

            migrationBuilder.AddColumn<float>(
                name: "PhiNhanVienGiaoHang",
                table: "TrongLuong",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PhiTangNhanVienGiaoHang",
                table: "DuLieuTinhCuoc",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayThanhToanCuocPhi",
                table: "DonVanChuyen",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayThanhToanPhiNhanVienGiaoHang",
                table: "DonVanChuyen",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayThanhToanTienThuHo",
                table: "DonVanChuyen",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "PhiNhanVienGiaoHang",
                table: "DonVanChuyen",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "ThongBao",
                columns: table => new
                {
                    MaThongBao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaTaiKhoan = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    DaXem = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBao", x => x.MaThongBao);
                    table.ForeignKey(
                        name: "FK_ThongBao_TaiKhoan_MaTaiKhoan",
                        column: x => x.MaTaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "MaTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThongBao_MaTaiKhoan",
                table: "ThongBao",
                column: "MaTaiKhoan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThongBao");

            migrationBuilder.DropColumn(
                name: "PhiNhanVienGiaoHang",
                table: "TrongLuong");

            migrationBuilder.DropColumn(
                name: "PhiTangNhanVienGiaoHang",
                table: "DuLieuTinhCuoc");

            migrationBuilder.DropColumn(
                name: "NgayThanhToanCuocPhi",
                table: "DonVanChuyen");

            migrationBuilder.DropColumn(
                name: "NgayThanhToanPhiNhanVienGiaoHang",
                table: "DonVanChuyen");

            migrationBuilder.DropColumn(
                name: "NgayThanhToanTienThuHo",
                table: "DonVanChuyen");

            migrationBuilder.DropColumn(
                name: "PhiNhanVienGiaoHang",
                table: "DonVanChuyen");

            migrationBuilder.CreateTable(
                name: "DoanhThuCongTy",
                columns: table => new
                {
                    MaDoanhThuCongTy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDonVanChuyen = table.Column<int>(type: "int", nullable: false),
                    DoanhThu = table.Column<float>(type: "real", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayThem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoanhThuCongTy", x => x.MaDoanhThuCongTy);
                    table.ForeignKey(
                        name: "FK_DoanhThuCongTy_DonVanChuyen_MaDonVanChuyen",
                        column: x => x.MaDonVanChuyen,
                        principalTable: "DonVanChuyen",
                        principalColumn: "MaDonVanChuyen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoanhThuKhachHang",
                columns: table => new
                {
                    MaDoanhThu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDonVanChuyen = table.Column<int>(type: "int", nullable: false),
                    MaKhachHang = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    DoanhTHu = table.Column<float>(type: "real", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThanhToan = table.Column<bool>(type: "bit", nullable: false),
                    ngayThem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoanhThuKhachHang", x => x.MaDoanhThu);
                    table.ForeignKey(
                        name: "FK_DoanhThuKhachHang_DonVanChuyen_MaDonVanChuyen",
                        column: x => x.MaDonVanChuyen,
                        principalTable: "DonVanChuyen",
                        principalColumn: "MaDonVanChuyen",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoanhThuKhachHang_TaiKhoan_MaKhachHang",
                        column: x => x.MaKhachHang,
                        principalTable: "TaiKhoan",
                        principalColumn: "MaTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoKhachHang",
                columns: table => new
                {
                    MaNoKhacHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDonVanChuyen = table.Column<int>(type: "int", nullable: false),
                    MaKhachHang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ThanhToan = table.Column<bool>(type: "bit", nullable: false),
                    cuocPhi = table.Column<float>(type: "real", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ngayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ngayThem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoKhachHang", x => x.MaNoKhacHang);
                    table.ForeignKey(
                        name: "FK_NoKhachHang_DonVanChuyen_MaDonVanChuyen",
                        column: x => x.MaDonVanChuyen,
                        principalTable: "DonVanChuyen",
                        principalColumn: "MaDonVanChuyen",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoKhachHang_TaiKhoan_MaKhachHang",
                        column: x => x.MaKhachHang,
                        principalTable: "TaiKhoan",
                        principalColumn: "MaTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoNhanVienGiaoHang",
                columns: table => new
                {
                    MaNoNhanVienGiaoHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDonVanChuyen = table.Column<int>(type: "int", nullable: false),
                    MaNhanVienGiaoHang = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayThem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhiNo = table.Column<float>(type: "real", nullable: false),
                    ThanhToan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoNhanVienGiaoHang", x => x.MaNoNhanVienGiaoHang);
                    table.ForeignKey(
                        name: "FK_NoNhanVienGiaoHang_DonVanChuyen_MaDonVanChuyen",
                        column: x => x.MaDonVanChuyen,
                        principalTable: "DonVanChuyen",
                        principalColumn: "MaDonVanChuyen",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoNhanVienGiaoHang_TaiKhoan_MaNhanVienGiaoHang",
                        column: x => x.MaNhanVienGiaoHang,
                        principalTable: "TaiKhoan",
                        principalColumn: "MaTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhiNhanVienGiaoHang",
                columns: table => new
                {
                    MaPhiNhanVienGiaoHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonVanChuyenMaDonVanChuyen = table.Column<int>(type: "int", nullable: true),
                    MaNhanVienGiaoHang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaDonVanChuyen = table.Column<int>(type: "int", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phi = table.Column<float>(type: "real", nullable: false),
                    ThanhToan = table.Column<bool>(type: "bit", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ngayThem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhiNhanVienGiaoHang", x => x.MaPhiNhanVienGiaoHang);
                    table.ForeignKey(
                        name: "FK_PhiNhanVienGiaoHang_DonVanChuyen_DonVanChuyenMaDonVanChuyen",
                        column: x => x.DonVanChuyenMaDonVanChuyen,
                        principalTable: "DonVanChuyen",
                        principalColumn: "MaDonVanChuyen");
                    table.ForeignKey(
                        name: "FK_PhiNhanVienGiaoHang_TaiKhoan_MaNhanVienGiaoHang",
                        column: x => x.MaNhanVienGiaoHang,
                        principalTable: "TaiKhoan",
                        principalColumn: "MaTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoanhThuCongTy_MaDonVanChuyen",
                table: "DoanhThuCongTy",
                column: "MaDonVanChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_DoanhThuKhachHang_MaDonVanChuyen",
                table: "DoanhThuKhachHang",
                column: "MaDonVanChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_DoanhThuKhachHang_MaKhachHang",
                table: "DoanhThuKhachHang",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_NoKhachHang_MaDonVanChuyen",
                table: "NoKhachHang",
                column: "MaDonVanChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_NoKhachHang_MaKhachHang",
                table: "NoKhachHang",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_NoNhanVienGiaoHang_MaDonVanChuyen",
                table: "NoNhanVienGiaoHang",
                column: "MaDonVanChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_NoNhanVienGiaoHang_MaNhanVienGiaoHang",
                table: "NoNhanVienGiaoHang",
                column: "MaNhanVienGiaoHang");

            migrationBuilder.CreateIndex(
                name: "IX_PhiNhanVienGiaoHang_DonVanChuyenMaDonVanChuyen",
                table: "PhiNhanVienGiaoHang",
                column: "DonVanChuyenMaDonVanChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_PhiNhanVienGiaoHang_MaNhanVienGiaoHang",
                table: "PhiNhanVienGiaoHang",
                column: "MaNhanVienGiaoHang");
        }
    }
}
