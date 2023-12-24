using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class addCaNhan2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NguoiNhanCap3_NguoiNhanCaNhan_MaNguoiNhan",
                table: "NguoiNhanCap3");

            migrationBuilder.AddColumn<long>(
                name: "MaXaPhuong",
                table: "NguoiNhanCap3",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MaXaPhuong",
                table: "NguoiNhanCaNhan",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_NguoiNhanCap3_MaXaPhuong",
                table: "NguoiNhanCap3",
                column: "MaXaPhuong");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiNhanCaNhan_MaXaPhuong",
                table: "NguoiNhanCaNhan",
                column: "MaXaPhuong");

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiNhanCaNhan_XaPhuong_MaXaPhuong",
                table: "NguoiNhanCaNhan",
                column: "MaXaPhuong",
                principalTable: "XaPhuong",
                principalColumn: "MaXaPhuong",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiNhanCap3_NguoiNhanCaNhan_MaNguoiNhan",
                table: "NguoiNhanCap3",
                column: "MaNguoiNhan",
                principalTable: "NguoiNhanCaNhan",
                principalColumn: "MaNguoiNhanCaNhan");

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiNhanCap3_XaPhuong_MaXaPhuong",
                table: "NguoiNhanCap3",
                column: "MaXaPhuong",
                principalTable: "XaPhuong",
                principalColumn: "MaXaPhuong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NguoiNhanCaNhan_XaPhuong_MaXaPhuong",
                table: "NguoiNhanCaNhan");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiNhanCap3_NguoiNhanCaNhan_MaNguoiNhan",
                table: "NguoiNhanCap3");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiNhanCap3_XaPhuong_MaXaPhuong",
                table: "NguoiNhanCap3");

            migrationBuilder.DropIndex(
                name: "IX_NguoiNhanCap3_MaXaPhuong",
                table: "NguoiNhanCap3");

            migrationBuilder.DropIndex(
                name: "IX_NguoiNhanCaNhan_MaXaPhuong",
                table: "NguoiNhanCaNhan");

            migrationBuilder.DropColumn(
                name: "MaXaPhuong",
                table: "NguoiNhanCap3");

            migrationBuilder.DropColumn(
                name: "MaXaPhuong",
                table: "NguoiNhanCaNhan");

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiNhanCap3_NguoiNhanCaNhan_MaNguoiNhan",
                table: "NguoiNhanCap3",
                column: "MaNguoiNhan",
                principalTable: "NguoiNhanCaNhan",
                principalColumn: "MaNguoiNhanCaNhan",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
