using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class abc4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HinhThucVanCHuyenId",
                table: "HinhThucVanChuyen",
                newName: "MaHinhThucVanChuyen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaHinhThucVanChuyen",
                table: "HinhThucVanChuyen",
                newName: "HinhThucVanCHuyenId");
        }
    }
}
