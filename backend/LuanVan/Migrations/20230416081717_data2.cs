using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class data2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuLieuTinhCuoc_TrongLuong_MaTrongLuong",
                table: "DuLieuTinhCuoc");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuTinhCuoc_MaTrongLuong",
                table: "DuLieuTinhCuoc");

            migrationBuilder.DropColumn(
                name: "MaTrongLuong",
                table: "DuLieuTinhCuoc");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuTinhCuoc_MaTinhThanhPho",
                table: "DuLieuTinhCuoc",
                column: "MaTinhThanhPho",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DuLieuTinhCuoc_TinhThanhPho_MaTinhThanhPho",
                table: "DuLieuTinhCuoc",
                column: "MaTinhThanhPho",
                principalTable: "TinhThanhPho",
                principalColumn: "MaTinhThanhPho",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuLieuTinhCuoc_TinhThanhPho_MaTinhThanhPho",
                table: "DuLieuTinhCuoc");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuTinhCuoc_MaTinhThanhPho",
                table: "DuLieuTinhCuoc");

            migrationBuilder.AddColumn<int>(
                name: "MaTrongLuong",
                table: "DuLieuTinhCuoc",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuTinhCuoc_MaTrongLuong",
                table: "DuLieuTinhCuoc",
                column: "MaTrongLuong",
                unique: true,
                filter: "[MaTrongLuong] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DuLieuTinhCuoc_TrongLuong_MaTrongLuong",
                table: "DuLieuTinhCuoc",
                column: "MaTrongLuong",
                principalTable: "TrongLuong",
                principalColumn: "MaTrongLuong");
        }
    }
}
