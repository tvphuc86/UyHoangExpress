using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class abcdfgh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(

                name: "NgayThanhToan",
                table: "PhiNhanVienGiaoHang",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayThanhToan",
                table: "NoNhanVienGiaoHang",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ngayThanhToan",
                table: "NoKhachHang",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayThanhToan",
                table: "DoanhThuKhachHang",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgayThanhToan",
                table: "PhiNhanVienGiaoHang");

            migrationBuilder.DropColumn(
                name: "NgayThanhToan",
                table: "NoNhanVienGiaoHang");

            migrationBuilder.DropColumn(
                name: "ngayThanhToan",
                table: "NoKhachHang");

            migrationBuilder.DropColumn(
                name: "NgayThanhToan",
                table: "DoanhThuKhachHang");
        }
    }
}
