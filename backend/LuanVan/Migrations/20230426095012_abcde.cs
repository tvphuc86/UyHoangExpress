using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class abcde : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietTrangThai",
                table: "ChiTietTrangThai");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietTrangThai",
                table: "ChiTietTrangThai",
                columns: new[] { "MaDonVanChuyen", "MaTrangThaiDonVanChuyen", "ThoiGian" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietTrangThai",
                table: "ChiTietTrangThai");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietTrangThai",
                table: "ChiTietTrangThai",
                columns: new[] { "MaDonVanChuyen", "MaTrangThaiDonVanChuyen" });
        }
    }
}
