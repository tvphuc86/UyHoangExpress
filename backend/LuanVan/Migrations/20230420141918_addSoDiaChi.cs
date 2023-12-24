using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class addSoDiaChi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "TaiKhoan");

            migrationBuilder.CreateTable(
                name: "SoDiaChi",
                columns: table => new
                {
                    MaSoDiaChi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MaXaPhuong = table.Column<long>(type: "bigint", nullable: false),
                    MaTaiKhoan = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoDiaChi", x => x.MaSoDiaChi);
                    table.ForeignKey(
                        name: "FK_SoDiaChi_TaiKhoan_MaTaiKhoan",
                        column: x => x.MaTaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "MaTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoDiaChi_XaPhuong_MaXaPhuong",
                        column: x => x.MaXaPhuong,
                        principalTable: "XaPhuong",
                        principalColumn: "MaXaPhuong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoDiaChi_MaTaiKhoan",
                table: "SoDiaChi",
                column: "MaTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_SoDiaChi_MaXaPhuong",
                table: "SoDiaChi",
                column: "MaXaPhuong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoDiaChi");

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "TaiKhoan",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
