using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class addLoaiMathang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietCuocPhi",
                table: "ChiTietCuocPhi");

            migrationBuilder.AddColumn<int>(
                name: "MaLoaiMatHang",
                table: "MatHangCaNhan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaPhiBaoHiemDonVanChuyen",
                table: "DonVanChuyen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaLoaiMatHang",
                table: "ChiTietDonVanChuyen",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateTable(
                name: "BaoHiemDonVanChuyen",
                columns: table => new
                {
                    MaBaoHiemDonVanChuyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrongLuongBatDau = table.Column<float>(type: "real", nullable: false),
                    TrongLuongKetThuc = table.Column<float>(type: "real", nullable: false),
                    PhiBaoHiem = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoHiemDonVanChuyen", x => x.MaBaoHiemDonVanChuyen);
                });

            migrationBuilder.CreateTable(
                name: "LoaiMatHang",
                columns: table => new
                {
                    MaLoaiMatHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiMatHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTaLoaiMatHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhuPhiHangHoa = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiMatHang", x => x.MaLoaiMatHang);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatHangCaNhan_MaLoaiMatHang",
                table: "MatHangCaNhan",
                column: "MaLoaiMatHang");

            migrationBuilder.CreateIndex(
                name: "IX_DonVanChuyen_MaPhiBaoHiemDonVanChuyen",
                table: "DonVanChuyen",
                column: "MaPhiBaoHiemDonVanChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonVanChuyen_MaLoaiMatHang",
                table: "ChiTietDonVanChuyen",
                column: "MaLoaiMatHang");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonVanChuyen_LoaiMatHang_MaLoaiMatHang",
                table: "ChiTietDonVanChuyen",
                column: "MaLoaiMatHang",
                principalTable: "LoaiMatHang",
                principalColumn: "MaLoaiMatHang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DonVanChuyen_BaoHiemDonVanChuyen_MaPhiBaoHiemDonVanChuyen",
                table: "DonVanChuyen",
                column: "MaPhiBaoHiemDonVanChuyen",
                principalTable: "BaoHiemDonVanChuyen",
                principalColumn: "MaBaoHiemDonVanChuyen",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatHangCaNhan_LoaiMatHang_MaLoaiMatHang",
                table: "MatHangCaNhan",
                column: "MaLoaiMatHang",
                principalTable: "LoaiMatHang",
                principalColumn: "MaLoaiMatHang",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietCuocPhi_LoaiMatHang_MaLoaiMatHang",
                table: "ChiTietCuocPhi");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonVanChuyen_LoaiMatHang_MaLoaiMatHang",
                table: "ChiTietDonVanChuyen");

            migrationBuilder.DropForeignKey(
                name: "FK_DonVanChuyen_BaoHiemDonVanChuyen_MaPhiBaoHiemDonVanChuyen",
                table: "DonVanChuyen");

            migrationBuilder.DropForeignKey(
                name: "FK_MatHangCaNhan_LoaiMatHang_MaLoaiMatHang",
                table: "MatHangCaNhan");

            migrationBuilder.DropTable(
                name: "BaoHiemDonVanChuyen");

            migrationBuilder.DropTable(
                name: "LoaiMatHang");

            migrationBuilder.DropIndex(
                name: "IX_MatHangCaNhan_MaLoaiMatHang",
                table: "MatHangCaNhan");

            migrationBuilder.DropIndex(
                name: "IX_DonVanChuyen_MaPhiBaoHiemDonVanChuyen",
                table: "DonVanChuyen");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietDonVanChuyen_MaLoaiMatHang",
                table: "ChiTietDonVanChuyen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietCuocPhi",
                table: "ChiTietCuocPhi");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietCuocPhi_MaLoaiMatHang",
                table: "ChiTietCuocPhi");

            migrationBuilder.DropColumn(
                name: "MaLoaiMatHang",
                table: "MatHangCaNhan");

            migrationBuilder.DropColumn(
                name: "MaPhiBaoHiemDonVanChuyen",
                table: "DonVanChuyen");

            migrationBuilder.DropColumn(
                name: "MaLoaiMatHang",
                table: "ChiTietDonVanChuyen");

            migrationBuilder.DropColumn(
                name: "MaLoaiMatHang",
                table: "ChiTietCuocPhi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietCuocPhi",
                table: "ChiTietCuocPhi",
                columns: new[] { "MaCuocPhi", "MaQuanHuyen" });
        }
    }
}
