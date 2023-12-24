using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class addCaNhan5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ChieuCao",
                table: "MatHangCaNhan",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ChieuDai",
                table: "MatHangCaNhan",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ChieuRong",
                table: "MatHangCaNhan",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MucChia",
                table: "HinhThucVanChuyen",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChieuCao",
                table: "MatHangCaNhan");

            migrationBuilder.DropColumn(
                name: "ChieuDai",
                table: "MatHangCaNhan");

            migrationBuilder.DropColumn(
                name: "ChieuRong",
                table: "MatHangCaNhan");

            migrationBuilder.DropColumn(
                name: "MucChia",
                table: "HinhThucVanChuyen");
        }
    }
}
