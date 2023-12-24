using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class addLoaiMathang1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrongLuongKetThuc",
                table: "BaoHiemDonVanChuyen",
                newName: "GiaTriKetThuc");

            migrationBuilder.RenameColumn(
                name: "TrongLuongBatDau",
                table: "BaoHiemDonVanChuyen",
                newName: "GiaTriBatDau");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GiaTriKetThuc",
                table: "BaoHiemDonVanChuyen",
                newName: "TrongLuongKetThuc");

            migrationBuilder.RenameColumn(
                name: "GiaTriBatDau",
                table: "BaoHiemDonVanChuyen",
                newName: "TrongLuongBatDau");
        }
    }
}
