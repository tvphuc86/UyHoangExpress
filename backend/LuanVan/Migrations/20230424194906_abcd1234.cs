using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class abcd1234 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrangThaiDonHang_DonVanChuyen_DonVanChuyenMaDonVanChuyen",
                table: "TrangThaiDonHang");

            migrationBuilder.DropIndex(
                name: "IX_TrangThaiDonHang_DonVanChuyenMaDonVanChuyen",
                table: "TrangThaiDonHang");

            migrationBuilder.DropColumn(
                name: "DonVanChuyenMaDonVanChuyen",
                table: "TrangThaiDonHang");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrangThaiDonHang_DonVanChuyen_MaDonVanChuyen",
                table: "TrangThaiDonHang");

            migrationBuilder.DropIndex(
                name: "IX_TrangThaiDonHang_MaDonVanChuyen",
                table: "TrangThaiDonHang");

            migrationBuilder.DropColumn(
                name: "MaDonVanChuyen",
                table: "TrangThaiDonHang");

            migrationBuilder.AddColumn<int>(
                name: "DonVanChuyenMaDonVanChuyen",
                table: "TrangThaiDonHang",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiDonHang_DonVanChuyenMaDonVanChuyen",
                table: "TrangThaiDonHang",
                column: "DonVanChuyenMaDonVanChuyen");

            migrationBuilder.AddForeignKey(
                name: "FK_TrangThaiDonHang_DonVanChuyen_DonVanChuyenMaDonVanChuyen",
                table: "TrangThaiDonHang",
                column: "DonVanChuyenMaDonVanChuyen",
                principalTable: "DonVanChuyen",
                principalColumn: "MaDonVanChuyen");
        }
    }
}
