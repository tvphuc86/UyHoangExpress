using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuanVan.Migrations
{
    /// <inheritdoc />
    public partial class initData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HinhThucVanChuyen",
                columns: table => new
                {
                    HinhThucVanCHuyenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhThucVanChuyen", x => x.HinhThucVanCHuyenId);
                });

            migrationBuilder.CreateTable(
                name: "Quyen",
                columns: table => new
                {
                    MaQuyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quyen", x => x.MaQuyen);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    MaTaiKhoan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoatDong = table.Column<bool>(type: "bit", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    MaBam = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SoTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeXacNhan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.MaTaiKhoan);
                });

            migrationBuilder.CreateTable(
                name: "TinhThanhPho",
                columns: table => new
                {
                    MaTinhThanhPho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTinhThanhPho = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhThanhPho", x => x.MaTinhThanhPho);
                });

            migrationBuilder.CreateTable(
                name: "TrongLuong",
                columns: table => new
                {
                    MaTrongLuong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrongLuongBatDau = table.Column<float>(type: "real", nullable: false),
                    TrongLuongKetThuc = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrongLuong", x => x.MaTrongLuong);
                });

            migrationBuilder.CreateTable(
                name: "VaiTro",
                columns: table => new
                {
                    MaVaiTro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenVaiTro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTro", x => x.MaVaiTro);
                });

            migrationBuilder.CreateTable(
                name: "QuanHuyen",
                columns: table => new
                {
                    MaQuanHuyen = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuanHuyen = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MaTinhThanhPho = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanHuyen", x => x.MaQuanHuyen);
                    table.ForeignKey(
                        name: "FK_QuanHuyen_TinhThanhPho_MaTinhThanhPho",
                        column: x => x.MaTinhThanhPho,
                        principalTable: "TinhThanhPho",
                        principalColumn: "MaTinhThanhPho");
                });

            migrationBuilder.CreateTable(
                name: "CuocPhi",
                columns: table => new
                {
                    MaCuocPhi = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiaCuoc = table.Column<float>(type: "real", nullable: false),
                    ThoiGianGiao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaTrongLuong = table.Column<int>(type: "int", nullable: false),
                    MaHinhThucVanChuyen = table.Column<int>(type: "int", nullable: false),
                    MaQuanHuyen = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuocPhi", x => x.MaCuocPhi);
                    table.ForeignKey(
                        name: "FK_CuocPhi_HinhThucVanChuyen_MaHinhThucVanChuyen",
                        column: x => x.MaHinhThucVanChuyen,
                        principalTable: "HinhThucVanChuyen",
                        principalColumn: "HinhThucVanCHuyenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuocPhi_TrongLuong_MaTrongLuong",
                        column: x => x.MaTrongLuong,
                        principalTable: "TrongLuong",
                        principalColumn: "MaTrongLuong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuTinhCuoc",
                columns: table => new
                {
                    MaDuLieuTinhCuoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiaTriNac = table.Column<float>(type: "real", nullable: false),
                    GiaCuocNac = table.Column<float>(type: "real", nullable: false),
                    MaTinhThanhPho = table.Column<int>(type: "int", nullable: false),
                    MaHinhThucVanChuyen = table.Column<int>(type: "int", nullable: false),
                    MaTrongLuong = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuTinhCuoc", x => x.MaDuLieuTinhCuoc);
                    table.ForeignKey(
                        name: "FK_DuLieuTinhCuoc_HinhThucVanChuyen_MaHinhThucVanChuyen",
                        column: x => x.MaHinhThucVanChuyen,
                        principalTable: "HinhThucVanChuyen",
                        principalColumn: "HinhThucVanCHuyenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DuLieuTinhCuoc_TrongLuong_MaTrongLuong",
                        column: x => x.MaTrongLuong,
                        principalTable: "TrongLuong",
                        principalColumn: "MaTrongLuong");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietVaiTro",
                columns: table => new
                {
                    MaQuyen = table.Column<int>(type: "int", nullable: false),
                    MaVaiTro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietVaiTro", x => new { x.MaQuyen, x.MaVaiTro });
                    table.ForeignKey(
                        name: "FK_ChiTietVaiTro_Quyen_MaQuyen",
                        column: x => x.MaQuyen,
                        principalTable: "Quyen",
                        principalColumn: "MaQuyen",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietVaiTro_VaiTro_MaVaiTro",
                        column: x => x.MaVaiTro,
                        principalTable: "VaiTro",
                        principalColumn: "MaVaiTro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoVaiTro",
                columns: table => new
                {
                    MaVaiTro = table.Column<int>(type: "int", nullable: false),
                    MaTaiKhoan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoVaiTro", x => new { x.MaVaiTro, x.MaTaiKhoan });
                    table.ForeignKey(
                        name: "FK_CoVaiTro_TaiKhoan_MaTaiKhoan",
                        column: x => x.MaTaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "MaTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoVaiTro_VaiTro_MaVaiTro",
                        column: x => x.MaVaiTro,
                        principalTable: "VaiTro",
                        principalColumn: "MaVaiTro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XaPhuong",
                columns: table => new
                {
                    MaXaPhuong = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenXaPhuong = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MaQuanHuyen = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XaPhuong", x => x.MaXaPhuong);
                    table.ForeignKey(
                        name: "FK_XaPhuong_QuanHuyen_MaQuanHuyen",
                        column: x => x.MaQuanHuyen,
                        principalTable: "QuanHuyen",
                        principalColumn: "MaQuanHuyen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietCuocPhi",
                columns: table => new
                {
                    MaCuocPhi = table.Column<long>(type: "bigint", nullable: false),
                    MaQuanHuyen = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietCuocPhi", x => new { x.MaCuocPhi, x.MaQuanHuyen });
                    table.ForeignKey(
                        name: "FK_ChiTietCuocPhi_CuocPhi_MaCuocPhi",
                        column: x => x.MaCuocPhi,
                        principalTable: "CuocPhi",
                        principalColumn: "MaCuocPhi");
                    table.ForeignKey(
                        name: "FK_ChiTietCuocPhi_QuanHuyen_MaQuanHuyen",
                        column: x => x.MaQuanHuyen,
                        principalTable: "QuanHuyen",
                        principalColumn: "MaQuanHuyen");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCuocPhi_MaQuanHuyen",
                table: "ChiTietCuocPhi",
                column: "MaQuanHuyen");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietVaiTro_MaVaiTro",
                table: "ChiTietVaiTro",
                column: "MaVaiTro");

            migrationBuilder.CreateIndex(
                name: "IX_CoVaiTro_MaTaiKhoan",
                table: "CoVaiTro",
                column: "MaTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_CuocPhi_MaHinhThucVanChuyen",
                table: "CuocPhi",
                column: "MaHinhThucVanChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_CuocPhi_MaTrongLuong",
                table: "CuocPhi",
                column: "MaTrongLuong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuTinhCuoc_MaHinhThucVanChuyen",
                table: "DuLieuTinhCuoc",
                column: "MaHinhThucVanChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuTinhCuoc_MaTrongLuong",
                table: "DuLieuTinhCuoc",
                column: "MaTrongLuong",
                unique: true,
                filter: "[MaTrongLuong] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyen_MaTinhThanhPho",
                table: "QuanHuyen",
                column: "MaTinhThanhPho");

            migrationBuilder.CreateIndex(
                name: "IX_XaPhuong_MaQuanHuyen",
                table: "XaPhuong",
                column: "MaQuanHuyen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietCuocPhi");

            migrationBuilder.DropTable(
                name: "ChiTietVaiTro");

            migrationBuilder.DropTable(
                name: "CoVaiTro");

            migrationBuilder.DropTable(
                name: "DuLieuTinhCuoc");

            migrationBuilder.DropTable(
                name: "XaPhuong");

            migrationBuilder.DropTable(
                name: "CuocPhi");

            migrationBuilder.DropTable(
                name: "Quyen");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "VaiTro");

            migrationBuilder.DropTable(
                name: "QuanHuyen");

            migrationBuilder.DropTable(
                name: "HinhThucVanChuyen");

            migrationBuilder.DropTable(
                name: "TrongLuong");

            migrationBuilder.DropTable(
                name: "TinhThanhPho");
        }
    }
}
