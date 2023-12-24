using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class abcd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DuLieuTinhCuoc_MaTinhThanhPho",
                table: "DuLieuTinhCuoc");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuTinhCuoc_MaTinhThanhPho",
                table: "DuLieuTinhCuoc",
                column: "MaTinhThanhPho");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DuLieuTinhCuoc_MaTinhThanhPho",
                table: "DuLieuTinhCuoc");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuTinhCuoc_MaTinhThanhPho",
                table: "DuLieuTinhCuoc",
                column: "MaTinhThanhPho",
                unique: true);
        }
    }
}
