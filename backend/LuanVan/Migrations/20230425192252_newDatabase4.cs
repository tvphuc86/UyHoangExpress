using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class newDatabase4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietTrangThai_TrangThaiDonHang_MaTrangThaiDonVanChuyen",
                table: "ChiTietTrangThai");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrangThaiDonHang",
                table: "TrangThaiDonHang");

            migrationBuilder.RenameTable(
                name: "TrangThaiDonHang",
                newName: "TrangThaiDonVanChuyen");

            migrationBuilder.RenameColumn(
                name: "MaTrangThaiDonHang",
                table: "TrangThaiDonVanChuyen",
                newName: "MaTrangThaiDonVanChuyen");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrangThaiDonVanChuyen",
                table: "TrangThaiDonVanChuyen",
                column: "MaTrangThaiDonVanChuyen");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietTrangThai_TrangThaiDonVanChuyen_MaTrangThaiDonVanChuyen",
                table: "ChiTietTrangThai",
                column: "MaTrangThaiDonVanChuyen",
                principalTable: "TrangThaiDonVanChuyen",
                principalColumn: "MaTrangThaiDonVanChuyen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietTrangThai_TrangThaiDonVanChuyen_MaTrangThaiDonVanChuyen",
                table: "ChiTietTrangThai");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrangThaiDonVanChuyen",
                table: "TrangThaiDonVanChuyen");

            migrationBuilder.RenameTable(
                name: "TrangThaiDonVanChuyen",
                newName: "TrangThaiDonHang");

            migrationBuilder.RenameColumn(
                name: "MaTrangThaiDonVanChuyen",
                table: "TrangThaiDonHang",
                newName: "MaTrangThaiDonHang");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrangThaiDonHang",
                table: "TrangThaiDonHang",
                column: "MaTrangThaiDonHang");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietTrangThai_TrangThaiDonHang_MaTrangThaiDonVanChuyen",
                table: "ChiTietTrangThai",
                column: "MaTrangThaiDonVanChuyen",
                principalTable: "TrangThaiDonHang",
                principalColumn: "MaTrangThaiDonHang");
        }
    }
}
