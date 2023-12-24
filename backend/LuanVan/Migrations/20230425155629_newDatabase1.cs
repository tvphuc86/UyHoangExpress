using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class newDatabase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhiNhanVienGiaoHang",
                columns: table => new
                {
                    MaPhiNhanVienGiaoHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phi = table.Column<float>(type: "real", nullable: false),
                    ngayThem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaNhanVienGiaoHang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ThanhToan = table.Column<bool>(type: "bit", nullable: false),
                    MaDonVanChuyen = table.Column<int>(type: "int", nullable: false),
                    DonVanChuyenMaDonVanChuyen = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_PhiNhanVienGiaoHang_DonVanChuyenMaDonVanChuyen",
                table: "PhiNhanVienGiaoHang",
                column: "DonVanChuyenMaDonVanChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_PhiNhanVienGiaoHang_MaNhanVienGiaoHang",
                table: "PhiNhanVienGiaoHang",
                column: "MaNhanVienGiaoHang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhiNhanVienGiaoHang");
        }
    }
}
