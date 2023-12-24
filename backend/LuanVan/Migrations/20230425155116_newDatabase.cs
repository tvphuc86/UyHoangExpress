using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class newDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrangThaiDonHang_DonVanChuyen_MaDonVanChuyen",
                table: "TrangThaiDonHang");

            migrationBuilder.DropIndex(
                name: "IX_TrangThaiDonHang_MaDonVanChuyen",
                table: "TrangThaiDonHang");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "TrangThaiDonHang");

            migrationBuilder.DropColumn(
                name: "MaDonVanChuyen",
                table: "TrangThaiDonHang");

            migrationBuilder.RenameColumn(
                name: "TrangThai",
                table: "TrangThaiDonHang",
                newName: "TenTrangThai");

            migrationBuilder.CreateTable(
                name: "ChiTietTrangThai",
                columns: table => new
                {
                    MaTrangThaiThaiDonHang = table.Column<int>(type: "int", nullable: false),
                    MaDonVanChuyen = table.Column<int>(type: "int", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietTrangThai", x => new { x.MaDonVanChuyen, x.MaTrangThaiThaiDonHang });
                    table.ForeignKey(
                        name: "FK_ChiTietTrangThai_DonVanChuyen_MaDonVanChuyen",
                        column: x => x.MaDonVanChuyen,
                        principalTable: "DonVanChuyen",
                        principalColumn: "MaDonVanChuyen");
                    table.ForeignKey(
                        name: "FK_ChiTietTrangThai_TrangThaiDonHang_MaTrangThaiThaiDonHang",
                        column: x => x.MaTrangThaiThaiDonHang,
                        principalTable: "TrangThaiDonHang",
                        principalColumn: "MaTrangThaiDonHang");
                });

            migrationBuilder.CreateTable(
                name: "NoKhachHang",
                columns: table => new
                {
                    MaNoKhacHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKhachHang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaDonVanChuyen = table.Column<int>(type: "int", nullable: false),
                    ThanhToan = table.Column<bool>(type: "bit", nullable: false),
                    cuocPhi = table.Column<float>(type: "real", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietTrangThai_MaTrangThaiThaiDonHang",
                table: "ChiTietTrangThai",
                column: "MaTrangThaiThaiDonHang");

            migrationBuilder.CreateIndex(
                name: "IX_NoKhachHang_MaDonVanChuyen",
                table: "NoKhachHang",
                column: "MaDonVanChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_NoKhachHang_MaKhachHang",
                table: "NoKhachHang",
                column: "MaKhachHang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietTrangThai");

            migrationBuilder.DropTable(
                name: "NoKhachHang");

            migrationBuilder.RenameColumn(
                name: "TenTrangThai",
                table: "TrangThaiDonHang",
                newName: "TrangThai");

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "TrangThaiDonHang",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaDonVanChuyen",
                table: "TrangThaiDonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiDonHang_MaDonVanChuyen",
                table: "TrangThaiDonHang",
                column: "MaDonVanChuyen");

            migrationBuilder.AddForeignKey(
                name: "FK_TrangThaiDonHang_DonVanChuyen_MaDonVanChuyen",
                table: "TrangThaiDonHang",
                column: "MaDonVanChuyen",
                principalTable: "DonVanChuyen",
                principalColumn: "MaDonVanChuyen",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
