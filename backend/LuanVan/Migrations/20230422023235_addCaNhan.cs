using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class addCaNhan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MatHangCaNhan",
                columns: table => new
                {
                    MaMatHangCaNhan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrongLuong = table.Column<float>(type: "real", nullable: false),
                    TenMatHangCaNhan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaTaiKhoan = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatHangCaNhan", x => x.MaMatHangCaNhan);
                    table.ForeignKey(
                        name: "FK_MatHangCaNhan_TaiKhoan_MaTaiKhoan",
                        column: x => x.MaTaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "MaTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NguoiNhanCaNhan",
                columns: table => new
                {
                    MaNguoiNhanCaNhan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNguoiNhanCaNhan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChiNguoiNhanCaNhan = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MaTaiKhoan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiNhanCaNhan", x => x.MaNguoiNhanCaNhan);
                    table.ForeignKey(
                        name: "FK_NguoiNhanCaNhan_TaiKhoan_MaTaiKhoan",
                        column: x => x.MaTaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "MaTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatHangCaNhan_MaTaiKhoan",
                table: "MatHangCaNhan",
                column: "MaTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiNhanCaNhan_MaTaiKhoan",
                table: "NguoiNhanCaNhan",
                column: "MaTaiKhoan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatHangCaNhan");

            migrationBuilder.DropTable(
                name: "NguoiNhanCaNhan");
        }
    }
}
