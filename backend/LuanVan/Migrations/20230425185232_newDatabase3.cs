using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class newDatabase3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietTrangThai_TrangThaiDonHang_MaTrangThaiThaiDonHang",
                table: "ChiTietTrangThai");

            migrationBuilder.RenameColumn(
                name: "MaTrangThaiThaiDonHang",
                table: "ChiTietTrangThai",
                newName: "MaTrangThaiDonVanChuyen");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietTrangThai_MaTrangThaiThaiDonHang",
                table: "ChiTietTrangThai",
                newName: "IX_ChiTietTrangThai_MaTrangThaiDonVanChuyen");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietTrangThai_TrangThaiDonHang_MaTrangThaiDonVanChuyen",
                table: "ChiTietTrangThai",
                column: "MaTrangThaiDonVanChuyen",
                principalTable: "TrangThaiDonHang",
                principalColumn: "MaTrangThaiDonHang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietTrangThai_TrangThaiDonHang_MaTrangThaiDonVanChuyen",
                table: "ChiTietTrangThai");

            migrationBuilder.RenameColumn(
                name: "MaTrangThaiDonVanChuyen",
                table: "ChiTietTrangThai",
                newName: "MaTrangThaiThaiDonHang");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietTrangThai_MaTrangThaiDonVanChuyen",
                table: "ChiTietTrangThai",
                newName: "IX_ChiTietTrangThai_MaTrangThaiThaiDonHang");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietTrangThai_TrangThaiDonHang_MaTrangThaiThaiDonHang",
                table: "ChiTietTrangThai",
                column: "MaTrangThaiThaiDonHang",
                principalTable: "TrangThaiDonHang",
                principalColumn: "MaTrangThaiDonHang");
        }
    }
}
