using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class abc2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CuocPhi_MaHinhThucVanChuyen",
                table: "CuocPhi");

            migrationBuilder.CreateIndex(
                name: "IX_CuocPhi_MaHinhThucVanChuyen",
                table: "CuocPhi",
                column: "MaHinhThucVanChuyen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CuocPhi_MaHinhThucVanChuyen",
                table: "CuocPhi");

            migrationBuilder.CreateIndex(
                name: "IX_CuocPhi_MaHinhThucVanChuyen",
                table: "CuocPhi",
                column: "MaHinhThucVanChuyen",
                unique: true);
        }
    }
}
