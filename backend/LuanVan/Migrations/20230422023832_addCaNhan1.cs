using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class addCaNhan1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NguoiNhanCap3",
                columns: table => new
                {
                    MaNguoiNhanCap3 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNguoiNhanCap3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChiNguoiNhanCap3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MaNguoiNhan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiNhanCap3", x => x.MaNguoiNhanCap3);
                    table.ForeignKey(
                        name: "FK_NguoiNhanCap3_NguoiNhanCaNhan_MaNguoiNhan",
                        column: x => x.MaNguoiNhan,
                        principalTable: "NguoiNhanCaNhan",
                        principalColumn: "MaNguoiNhanCaNhan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NguoiNhanCap3_MaNguoiNhan",
                table: "NguoiNhanCap3",
                column: "MaNguoiNhan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NguoiNhanCap3");
        }
    }
}
