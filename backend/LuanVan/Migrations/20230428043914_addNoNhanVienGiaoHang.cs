using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class addNoNhanVienGiaoHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoNhanVienGiaoHang",
                columns: table => new
                {
                    MaNoNhanVienGiaoHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhiNo = table.Column<float>(type: "real", nullable: false),
                    ThanhToan = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaNhanVienGiaoHang = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    MaDonVanChuyen = table.Column<int>(type: "int", nullable: false),
                    NgayThem = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_NoNhanVienGiaoHang_MaDonVanChuyen",
                table: "NoNhanVienGiaoHang",
                column: "MaDonVanChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_NoNhanVienGiaoHang_MaNhanVienGiaoHang",
                table: "NoNhanVienGiaoHang",
                column: "MaNhanVienGiaoHang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoNhanVienGiaoHang");
        }
    }
}
