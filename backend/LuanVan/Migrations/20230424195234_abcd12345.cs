using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class abcd12345 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonVanChuyen_DonVanChuyen_DonVanChuyenMaDonVanChuyen",
                table: "ChiTietDonVanChuyen");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietDonVanChuyen_DonVanChuyenMaDonVanChuyen",
                table: "ChiTietDonVanChuyen");

            migrationBuilder.DropColumn(
                name: "DonVanChuyenMaDonVanChuyen",
                table: "ChiTietDonVanChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonVanChuyen_MaDonVanChuyen",
                table: "ChiTietDonVanChuyen",
                column: "MaDonVanChuyen");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonVanChuyen_DonVanChuyen_MaDonVanChuyen",
                table: "ChiTietDonVanChuyen",
                column: "MaDonVanChuyen",
                principalTable: "DonVanChuyen",
                principalColumn: "MaDonVanChuyen",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonVanChuyen_DonVanChuyen_MaDonVanChuyen",
                table: "ChiTietDonVanChuyen");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietDonVanChuyen_MaDonVanChuyen",
                table: "ChiTietDonVanChuyen");

            migrationBuilder.AddColumn<int>(
                name: "DonVanChuyenMaDonVanChuyen",
                table: "ChiTietDonVanChuyen",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonVanChuyen_DonVanChuyenMaDonVanChuyen",
                table: "ChiTietDonVanChuyen",
                column: "DonVanChuyenMaDonVanChuyen");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonVanChuyen_DonVanChuyen_DonVanChuyenMaDonVanChuyen",
                table: "ChiTietDonVanChuyen",
                column: "DonVanChuyenMaDonVanChuyen",
                principalTable: "DonVanChuyen",
                principalColumn: "MaDonVanChuyen");
        }
    }
}
