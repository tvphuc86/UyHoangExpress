using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class abcd4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoDiaChi_TaiKhoan_MaTaiKhoan",
                table: "SoDiaChi");

            migrationBuilder.DropForeignKey(
                name: "FK_SoDiaChi_XaPhuong_MaXaPhuong",
                table: "SoDiaChi");

            migrationBuilder.AlterColumn<long>(
                name: "MaXaPhuong",
                table: "SoDiaChi",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "MaTaiKhoan",
                table: "SoDiaChi",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AddForeignKey(
                name: "FK_SoDiaChi_TaiKhoan_MaTaiKhoan",
                table: "SoDiaChi",
                column: "MaTaiKhoan",
                principalTable: "TaiKhoan",
                principalColumn: "MaTaiKhoan");

            migrationBuilder.AddForeignKey(
                name: "FK_SoDiaChi_XaPhuong_MaXaPhuong",
                table: "SoDiaChi",
                column: "MaXaPhuong",
                principalTable: "XaPhuong",
                principalColumn: "MaXaPhuong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoDiaChi_TaiKhoan_MaTaiKhoan",
                table: "SoDiaChi");

            migrationBuilder.DropForeignKey(
                name: "FK_SoDiaChi_XaPhuong_MaXaPhuong",
                table: "SoDiaChi");

            migrationBuilder.AlterColumn<long>(
                name: "MaXaPhuong",
                table: "SoDiaChi",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaTaiKhoan",
                table: "SoDiaChi",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SoDiaChi_TaiKhoan_MaTaiKhoan",
                table: "SoDiaChi",
                column: "MaTaiKhoan",
                principalTable: "TaiKhoan",
                principalColumn: "MaTaiKhoan",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoDiaChi_XaPhuong_MaXaPhuong",
                table: "SoDiaChi",
                column: "MaXaPhuong",
                principalTable: "XaPhuong",
                principalColumn: "MaXaPhuong",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
