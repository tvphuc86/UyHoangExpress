using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class abcd123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonVanChuyen_XaPhuong_XaPhuongMaXaPhuong",
                table: "DonVanChuyen");

            migrationBuilder.AlterColumn<long>(
                name: "XaPhuongMaXaPhuong",
                table: "DonVanChuyen",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "MaQuanLy",
                table: "DonVanChuyen",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "MaNhanVienGiaoHang",
                table: "DonVanChuyen",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "DonVanChuyen",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "SoLuong",
                table: "ChiTietDonVanChuyen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DonVanChuyen_XaPhuong_XaPhuongMaXaPhuong",
                table: "DonVanChuyen",
                column: "XaPhuongMaXaPhuong",
                principalTable: "XaPhuong",
                principalColumn: "MaXaPhuong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonVanChuyen_XaPhuong_XaPhuongMaXaPhuong",
                table: "DonVanChuyen");

            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "ChiTietDonVanChuyen");

            migrationBuilder.AlterColumn<long>(
                name: "XaPhuongMaXaPhuong",
                table: "DonVanChuyen",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaQuanLy",
                table: "DonVanChuyen",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaNhanVienGiaoHang",
                table: "DonVanChuyen",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "DonVanChuyen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DonVanChuyen_XaPhuong_XaPhuongMaXaPhuong",
                table: "DonVanChuyen",
                column: "XaPhuongMaXaPhuong",
                principalTable: "XaPhuong",
                principalColumn: "MaXaPhuong",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
