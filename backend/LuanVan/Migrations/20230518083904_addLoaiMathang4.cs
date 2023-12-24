using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class addLoaiMathang4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietCuocPhi_LoaiMatHang_MaLoaiMatHang",
                table: "ChiTietCuocPhi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietCuocPhi",
                table: "ChiTietCuocPhi");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietCuocPhi_MaLoaiMatHang",
                table: "ChiTietCuocPhi");

            migrationBuilder.DropColumn(
                name: "MaLoaiMatHang",
                table: "ChiTietCuocPhi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietCuocPhi",
                table: "ChiTietCuocPhi",
                columns: new[] { "MaCuocPhi", "MaQuanHuyen" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietCuocPhi",
                table: "ChiTietCuocPhi");

            migrationBuilder.AddColumn<int>(
                name: "MaLoaiMatHang",
                table: "ChiTietCuocPhi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietCuocPhi",
                table: "ChiTietCuocPhi",
                columns: new[] { "MaCuocPhi", "MaQuanHuyen", "MaLoaiMatHang" });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCuocPhi_MaLoaiMatHang",
                table: "ChiTietCuocPhi",
                column: "MaLoaiMatHang");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietCuocPhi_LoaiMatHang_MaLoaiMatHang",
                table: "ChiTietCuocPhi",
                column: "MaLoaiMatHang",
                principalTable: "LoaiMatHang",
                principalColumn: "MaLoaiMatHang");
        }
    }
}
