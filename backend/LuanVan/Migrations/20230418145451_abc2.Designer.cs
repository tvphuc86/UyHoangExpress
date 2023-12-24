﻿// <auto-generated />
using System;
using LuanVan.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LuanVan.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230418145451_abc2")]
    partial class abc2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LuanVan.Model.ChiTietCuocPhi", b =>
                {
                    b.Property<long?>("MaCuocPhi")
                        .HasColumnType("bigint");

                    b.Property<long?>("MaQuanHuyen")
                        .HasColumnType("bigint");

                    b.HasKey("MaCuocPhi", "MaQuanHuyen");

                    b.HasIndex("MaQuanHuyen");

                    b.ToTable("ChiTietCuocPhi");
                });

            modelBuilder.Entity("LuanVan.Model.ChiTietVaiTro", b =>
                {
                    b.Property<int>("MaQuyen")
                        .HasColumnType("int");

                    b.Property<int>("MaVaiTro")
                        .HasColumnType("int");

                    b.HasKey("MaQuyen", "MaVaiTro");

                    b.HasIndex("MaVaiTro");

                    b.ToTable("ChiTietVaiTro");
                });

            modelBuilder.Entity("LuanVan.Model.CoVaiTro", b =>
                {
                    b.Property<int>("MaVaiTro")
                        .HasColumnType("int");

                    b.Property<string>("MaTaiKhoan")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("MaVaiTro", "MaTaiKhoan");

                    b.HasIndex("MaTaiKhoan");

                    b.ToTable("CoVaiTro");
                });

            modelBuilder.Entity("LuanVan.Model.CuocPhi", b =>
                {
                    b.Property<long>("MaCuocPhi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MaCuocPhi"));

                    b.Property<float>("GiaCuoc")
                        .HasColumnType("real");

                    b.Property<int>("MaHinhThucVanChuyen")
                        .HasColumnType("int");

                    b.Property<int>("MaTrongLuong")
                        .HasColumnType("int");

                    b.Property<string>("ThoiGianGiao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaCuocPhi");

                    b.HasIndex("MaHinhThucVanChuyen");

                    b.HasIndex("MaTrongLuong");

                    b.ToTable("CuocPhi");
                });

            modelBuilder.Entity("LuanVan.Model.DuLieuTinhCuoc", b =>
                {
                    b.Property<int>("MaDuLieuTinhCuoc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDuLieuTinhCuoc"));

                    b.Property<float>("GiaCuocNac")
                        .HasColumnType("real");

                    b.Property<float>("GiaTriNac")
                        .HasColumnType("real");

                    b.Property<int>("MaHinhThucVanChuyen")
                        .HasColumnType("int");

                    b.Property<int>("MaTinhThanhPho")
                        .HasColumnType("int");

                    b.Property<float>("TrongLuongBatDau")
                        .HasColumnType("real");

                    b.HasKey("MaDuLieuTinhCuoc");

                    b.HasIndex("MaHinhThucVanChuyen");

                    b.HasIndex("MaTinhThanhPho")
                        .IsUnique();

                    b.ToTable("DuLieuTinhCuoc");
                });

            modelBuilder.Entity("LuanVan.Model.HinhThucVanChuyen", b =>
                {
                    b.Property<int>("HinhThucVanCHuyenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HinhThucVanCHuyenId"));

                    b.Property<string>("Anh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("HinhThucVanCHuyenId");

                    b.ToTable("HinhThucVanChuyen");
                });

            modelBuilder.Entity("LuanVan.Model.QuanHuyen", b =>
                {
                    b.Property<long>("MaQuanHuyen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MaQuanHuyen"));

                    b.Property<int?>("MaTinhThanhPho")
                        .HasColumnType("int");

                    b.Property<string>("TenQuanHuyen")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("MaQuanHuyen");

                    b.HasIndex("MaTinhThanhPho");

                    b.ToTable("QuanHuyen");
                });

            modelBuilder.Entity("LuanVan.Model.Quyen", b =>
                {
                    b.Property<int>("MaQuyen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaQuyen"));

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("TenQuyen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaQuyen");

                    b.ToTable("Quyen");
                });

            modelBuilder.Entity("LuanVan.Model.TaiKhoan", b =>
                {
                    b.Property<string>("MaTaiKhoan")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Anh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeXacNhan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("HoatDong")
                        .HasColumnType("bit");

                    b.Property<byte[]>("MaBam")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("MatKhau")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoTaiKhoan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaTaiKhoan");

                    b.ToTable("TaiKhoan");
                });

            modelBuilder.Entity("LuanVan.Model.TinhThanhPho", b =>
                {
                    b.Property<int>("MaTinhThanhPho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTinhThanhPho"));

                    b.Property<string>("TenTinhThanhPho")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("MaTinhThanhPho");

                    b.ToTable("TinhThanhPho");
                });

            modelBuilder.Entity("LuanVan.Model.TrongLuong", b =>
                {
                    b.Property<int>("MaTrongLuong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTrongLuong"));

                    b.Property<float>("TrongLuongBatDau")
                        .HasColumnType("real");

                    b.Property<float>("TrongLuongKetThuc")
                        .HasColumnType("real");

                    b.HasKey("MaTrongLuong");

                    b.ToTable("TrongLuong");
                });

            modelBuilder.Entity("LuanVan.Model.VaiTro", b =>
                {
                    b.Property<int>("MaVaiTro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaVaiTro"));

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenVaiTro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaVaiTro");

                    b.ToTable("VaiTro");
                });

            modelBuilder.Entity("LuanVan.Model.XaPhuong", b =>
                {
                    b.Property<long>("MaXaPhuong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MaXaPhuong"));

                    b.Property<long>("MaQuanHuyen")
                        .HasColumnType("bigint");

                    b.Property<string>("TenXaPhuong")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("MaXaPhuong");

                    b.HasIndex("MaQuanHuyen");

                    b.ToTable("XaPhuong");
                });

            modelBuilder.Entity("LuanVan.Model.ChiTietCuocPhi", b =>
                {
                    b.HasOne("LuanVan.Model.CuocPhi", "CuocPhi")
                        .WithMany("ChiTietCuocPhis")
                        .HasForeignKey("MaCuocPhi")
                        .IsRequired();

                    b.HasOne("LuanVan.Model.QuanHuyen", "QuanHuyen")
                        .WithMany("ChiTietCuocPhis")
                        .HasForeignKey("MaQuanHuyen")
                        .IsRequired();

                    b.Navigation("CuocPhi");

                    b.Navigation("QuanHuyen");
                });

            modelBuilder.Entity("LuanVan.Model.ChiTietVaiTro", b =>
                {
                    b.HasOne("LuanVan.Model.Quyen", "Quyen")
                        .WithMany("VaiTros")
                        .HasForeignKey("MaQuyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LuanVan.Model.VaiTro", "VaiTro")
                        .WithMany("Quyens")
                        .HasForeignKey("MaVaiTro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quyen");

                    b.Navigation("VaiTro");
                });

            modelBuilder.Entity("LuanVan.Model.CoVaiTro", b =>
                {
                    b.HasOne("LuanVan.Model.TaiKhoan", "TaiKhoan")
                        .WithMany("VaiTros")
                        .HasForeignKey("MaTaiKhoan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LuanVan.Model.VaiTro", "VaiTro")
                        .WithMany("TaiKhoans")
                        .HasForeignKey("MaVaiTro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaiKhoan");

                    b.Navigation("VaiTro");
                });

            modelBuilder.Entity("LuanVan.Model.CuocPhi", b =>
                {
                    b.HasOne("LuanVan.Model.HinhThucVanChuyen", "HinhThucVanChuyen")
                        .WithMany("CuocPhi")
                        .HasForeignKey("MaHinhThucVanChuyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LuanVan.Model.TrongLuong", "TrongLuong")
                        .WithMany("CuocPhiList")
                        .HasForeignKey("MaTrongLuong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HinhThucVanChuyen");

                    b.Navigation("TrongLuong");
                });

            modelBuilder.Entity("LuanVan.Model.DuLieuTinhCuoc", b =>
                {
                    b.HasOne("LuanVan.Model.HinhThucVanChuyen", "HinhThucVanChuyen")
                        .WithMany()
                        .HasForeignKey("MaHinhThucVanChuyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LuanVan.Model.TinhThanhPho", "TinhThanhPho")
                        .WithOne("DuLieuTinhCuoc")
                        .HasForeignKey("LuanVan.Model.DuLieuTinhCuoc", "MaTinhThanhPho")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HinhThucVanChuyen");

                    b.Navigation("TinhThanhPho");
                });

            modelBuilder.Entity("LuanVan.Model.QuanHuyen", b =>
                {
                    b.HasOne("LuanVan.Model.TinhThanhPho", "TinhThanhPho")
                        .WithMany("QuanHuyens")
                        .HasForeignKey("MaTinhThanhPho");

                    b.Navigation("TinhThanhPho");
                });

            modelBuilder.Entity("LuanVan.Model.XaPhuong", b =>
                {
                    b.HasOne("LuanVan.Model.QuanHuyen", "QuanHuyen")
                        .WithMany("XaPhuongs")
                        .HasForeignKey("MaQuanHuyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuanHuyen");
                });

            modelBuilder.Entity("LuanVan.Model.CuocPhi", b =>
                {
                    b.Navigation("ChiTietCuocPhis");
                });

            modelBuilder.Entity("LuanVan.Model.HinhThucVanChuyen", b =>
                {
                    b.Navigation("CuocPhi");
                });

            modelBuilder.Entity("LuanVan.Model.QuanHuyen", b =>
                {
                    b.Navigation("ChiTietCuocPhis");

                    b.Navigation("XaPhuongs");
                });

            modelBuilder.Entity("LuanVan.Model.Quyen", b =>
                {
                    b.Navigation("VaiTros");
                });

            modelBuilder.Entity("LuanVan.Model.TaiKhoan", b =>
                {
                    b.Navigation("VaiTros");
                });

            modelBuilder.Entity("LuanVan.Model.TinhThanhPho", b =>
                {
                    b.Navigation("DuLieuTinhCuoc");

                    b.Navigation("QuanHuyens");
                });

            modelBuilder.Entity("LuanVan.Model.TrongLuong", b =>
                {
                    b.Navigation("CuocPhiList");
                });

            modelBuilder.Entity("LuanVan.Model.VaiTro", b =>
                {
                    b.Navigation("Quyens");

                    b.Navigation("TaiKhoans");
                });
#pragma warning restore 612, 618
        }
    }
}
