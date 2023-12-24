using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class abvc3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonVanChuyen_BaoHiemDonVanChuyen_MaPhiBaoHiemDonVanChuyen",
                table: "DonVanChuyen");

            migrationBuilder.RenameColumn(
                name: "MaPhiBaoHiemDonVanChuyen",
                table: "DonVanChuyen",
                newName: "MaBaoHiemDonVanChuyen");

            migrationBuilder.RenameIndex(
                name: "IX_DonVanChuyen_MaPhiBaoHiemDonVanChuyen",
                table: "DonVanChuyen",
                newName: "IX_DonVanChuyen_MaBaoHiemDonVanChuyen");

            migrationBuilder.AddForeignKey(
                name: "FK_DonVanChuyen_BaoHiemDonVanChuyen_MaBaoHiemDonVanChuyen",
                table: "DonVanChuyen",
                column: "MaBaoHiemDonVanChuyen",
                principalTable: "BaoHiemDonVanChuyen",
                principalColumn: "MaBaoHiemDonVanChuyen",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonVanChuyen_BaoHiemDonVanChuyen_MaBaoHiemDonVanChuyen",
                table: "DonVanChuyen");

            migrationBuilder.RenameColumn(
                name: "MaBaoHiemDonVanChuyen",
                table: "DonVanChuyen",
                newName: "MaPhiBaoHiemDonVanChuyen");

            migrationBuilder.RenameIndex(
                name: "IX_DonVanChuyen_MaBaoHiemDonVanChuyen",
                table: "DonVanChuyen",
                newName: "IX_DonVanChuyen_MaPhiBaoHiemDonVanChuyen");

            migrationBuilder.AddForeignKey(
                name: "FK_DonVanChuyen_BaoHiemDonVanChuyen_MaPhiBaoHiemDonVanChuyen",
                table: "DonVanChuyen",
                column: "MaPhiBaoHiemDonVanChuyen",
                principalTable: "BaoHiemDonVanChuyen",
                principalColumn: "MaBaoHiemDonVanChuyen",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
