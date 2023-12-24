using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class addDoanhThu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoanhThuCongTy",
                columns: table => new
                {
                    MaDoanhThuCongTy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoanhThu = table.Column<float>(type: "real", nullable: false),
                    MaDonVanChuyen = table.Column<int>(type: "int", nullable: false),
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
                    ThanhToan = table.Column<bool>(type: "bit", nullable: false),
                    MaDonVanChuyen = table.Column<int>(type: "int", nullable: false),
                    MaKhachHang = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    DoanhTHu = table.Column<float>(type: "real", nullable: false),
                    ngayThem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoanhThuCongTy");

            migrationBuilder.DropTable(
                name: "DoanhThuKhachHang");
        }
    }
}
