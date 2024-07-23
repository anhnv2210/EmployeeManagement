using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ems_backend.Migrations
{
    public partial class createdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CapPhatTaiSans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    TaiSanId = table.Column<int>(type: "int", nullable: false),
                    NgayCapPhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTraLai = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapPhatTaiSans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChiNhanhNganHangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChiNhanhNganHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NganHangId = table.Column<int>(type: "int", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoId = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatId = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiNhanhNganHangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChucDanhPhongBans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhongBanId = table.Column<int>(type: "int", nullable: false),
                    ChucDanhId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucDanhPhongBans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChucDanhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChucDanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoId = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatId = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucDanhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucKhacs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThamSo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaTri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoId = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatId = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucKhacs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HopDongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    LoaiHopDongId = table.Column<int>(type: "int", nullable: false),
                    QuyetDinhId = table.Column<int>(type: "int", nullable: false),
                    HoSoLuongId = table.Column<int>(type: "int", nullable: false),
                    ChiTietHopDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDongs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoSoLuong_PhuCaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoSoLuongId = table.Column<int>(type: "int", nullable: false),
                    PhuCapId = table.Column<int>(type: "int", nullable: false),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoLuong_PhuCaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoSoLuong_PhucLois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoSoLuongId = table.Column<int>(type: "int", nullable: false),
                    PhucLoiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoLuong_PhucLois", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoSoLuongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    PhongBanId = table.Column<int>(type: "int", nullable: false),
                    ChucDanhPhongBanId = table.Column<int>(type: "int", nullable: false),
                    ThangLuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BacLuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LuongMin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LuongMax = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoLuongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoLuongs_ChucDanhPhongBans_ChucDanhPhongBanId",
                        column: x => x.ChucDanhPhongBanId,
                        principalTable: "ChucDanhPhongBans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhenThuongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    LoaiKhenThuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayKhenThuong = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhenThuongs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KyLuats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    LoaiKyLuat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayKyLuat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KyLuats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiHopDongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiHopDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoId = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatId = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiHopDongs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NganHangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNganHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoId = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatId = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NganHangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NghiViecs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    NgayNghiViec = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LyDo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NghiViecs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NguoiThanNhanViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    TenNguoiThan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuanHe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GiamTruGiaCanh = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NgayBatDauGiaGiam = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiThanNhanViens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hoten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhongBanId = table.Column<int>(type: "int", nullable: true),
                    ChucDanhPhongBanId = table.Column<int>(type: "int", nullable: true),
                    XaPhuongId = table.Column<int>(type: "int", nullable: true),
                    QuanHuyenId = table.Column<int>(type: "int", nullable: true),
                    TinhThanhId = table.Column<int>(type: "int", nullable: true),
                    NganHangId = table.Column<int>(type: "int", nullable: true),
                    ChiNhanhNganHangId = table.Column<int>(type: "int", nullable: true),
                    NoiKhamBenhId = table.Column<int>(type: "int", nullable: true),
                    NguoiTaoId = table.Column<int>(type: "int", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatId = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanViens_ChiNhanhNganHangs_ChiNhanhNganHangId",
                        column: x => x.ChiNhanhNganHangId,
                        principalTable: "ChiNhanhNganHangs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NhanViens_ChucDanhPhongBans_ChucDanhPhongBanId",
                        column: x => x.ChucDanhPhongBanId,
                        principalTable: "ChucDanhPhongBans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NhanViens_NganHangs_NganHangId",
                        column: x => x.NganHangId,
                        principalTable: "NganHangs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NhanViens_NhanViens_NguoiCapNhatId",
                        column: x => x.NguoiCapNhatId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NhanViens_NhanViens_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NoiKhamBenhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNoiKhamBenh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoId = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatId = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoiKhamBenhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoiKhamBenhs_NhanViens_NguoiCapNhatId",
                        column: x => x.NguoiCapNhatId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NoiKhamBenhs_NhanViens_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhongBans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhongBan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoId = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatId = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhongBans_NhanViens_NguoiCapNhatId",
                        column: x => x.NguoiCapNhatId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhongBans_NhanViens_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhuCaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhuCap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoId = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatId = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuCaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhuCaps_NhanViens_NguoiCapNhatId",
                        column: x => x.NguoiCapNhatId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhuCaps_NhanViens_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PhucLois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhucLoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoId = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatId = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhucLois", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhucLois_NhanViens_NguoiCapNhatId",
                        column: x => x.NguoiCapNhatId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhucLois_NhanViens_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "QuyetDinhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayQuyetDinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HopDongId = table.Column<int>(type: "int", nullable: false),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    TongLuong = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HoSoLuongId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyetDinhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyetDinhs_HopDongs_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuyetDinhs_HoSoLuongs_HoSoLuongId",
                        column: x => x.HoSoLuongId,
                        principalTable: "HoSoLuongs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuyetDinhs_NhanViens_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaiSans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTaiSan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoId = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatId = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiSans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaiSans_NhanViens_NguoiCapNhatId",
                        column: x => x.NguoiCapNhatId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaiSans_NhanViens_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TapTinDinhKems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    TenTapTin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuongDan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TapTinDinhKems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TapTinDinhKems_NhanViens_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TinhThanhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTinhThanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoId = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatId = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhThanhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TinhThanhs_NhanViens_NguoiCapNhatId",
                        column: x => x.NguoiCapNhatId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TinhThanhs_NhanViens_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuanHuyens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuanHuyen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhThanhId = table.Column<int>(type: "int", nullable: false),
                    NguoiTaoId = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatId = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanHuyens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuanHuyens_NhanViens_NguoiCapNhatId",
                        column: x => x.NguoiCapNhatId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuanHuyens_NhanViens_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuanHuyens_TinhThanhs_TinhThanhId",
                        column: x => x.TinhThanhId,
                        principalTable: "TinhThanhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XaPhuongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenXaPhuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuanHuyenId = table.Column<int>(type: "int", nullable: false),
                    NguoiTaoId = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatId = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XaPhuongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XaPhuongs_NhanViens_NguoiCapNhatId",
                        column: x => x.NguoiCapNhatId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_XaPhuongs_NhanViens_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_XaPhuongs_QuanHuyens_QuanHuyenId",
                        column: x => x.QuanHuyenId,
                        principalTable: "QuanHuyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CapPhatTaiSans_NhanVienId",
                table: "CapPhatTaiSans",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_CapPhatTaiSans_TaiSanId",
                table: "CapPhatTaiSans",
                column: "TaiSanId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiNhanhNganHangs_NganHangId",
                table: "ChiNhanhNganHangs",
                column: "NganHangId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiNhanhNganHangs_NguoiCapNhatId",
                table: "ChiNhanhNganHangs",
                column: "NguoiCapNhatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiNhanhNganHangs_NguoiTaoId",
                table: "ChiNhanhNganHangs",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChucDanhPhongBans_ChucDanhId",
                table: "ChucDanhPhongBans",
                column: "ChucDanhId");

            migrationBuilder.CreateIndex(
                name: "IX_ChucDanhPhongBans_PhongBanId",
                table: "ChucDanhPhongBans",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_ChucDanhs_NguoiCapNhatId",
                table: "ChucDanhs",
                column: "NguoiCapNhatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChucDanhs_NguoiTaoId",
                table: "ChucDanhs",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhacs_NguoiCapNhatId",
                table: "DanhMucKhacs",
                column: "NguoiCapNhatId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhacs_NguoiTaoId",
                table: "DanhMucKhacs",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongs_HoSoLuongId",
                table: "HopDongs",
                column: "HoSoLuongId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongs_LoaiHopDongId",
                table: "HopDongs",
                column: "LoaiHopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongs_NhanVienId",
                table: "HopDongs",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoLuong_PhuCaps_HoSoLuongId",
                table: "HoSoLuong_PhuCaps",
                column: "HoSoLuongId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoLuong_PhuCaps_PhuCapId",
                table: "HoSoLuong_PhuCaps",
                column: "PhuCapId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoLuong_PhucLois_HoSoLuongId",
                table: "HoSoLuong_PhucLois",
                column: "HoSoLuongId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoLuong_PhucLois_PhucLoiId",
                table: "HoSoLuong_PhucLois",
                column: "PhucLoiId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoLuongs_ChucDanhPhongBanId",
                table: "HoSoLuongs",
                column: "ChucDanhPhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoLuongs_NhanVienId",
                table: "HoSoLuongs",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoLuongs_PhongBanId",
                table: "HoSoLuongs",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_KhenThuongs_NhanVienId",
                table: "KhenThuongs",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_KyLuats_NhanVienId",
                table: "KyLuats",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHopDongs_NguoiCapNhatId",
                table: "LoaiHopDongs",
                column: "NguoiCapNhatId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHopDongs_NguoiTaoId",
                table: "LoaiHopDongs",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_NganHangs_NguoiCapNhatId",
                table: "NganHangs",
                column: "NguoiCapNhatId");

            migrationBuilder.CreateIndex(
                name: "IX_NganHangs_NguoiTaoId",
                table: "NganHangs",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_NghiViecs_NhanVienId",
                table: "NghiViecs",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiThanNhanViens_NhanVienId",
                table: "NguoiThanNhanViens",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_ChiNhanhNganHangId",
                table: "NhanViens",
                column: "ChiNhanhNganHangId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_ChucDanhPhongBanId",
                table: "NhanViens",
                column: "ChucDanhPhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_NganHangId",
                table: "NhanViens",
                column: "NganHangId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_NguoiCapNhatId",
                table: "NhanViens",
                column: "NguoiCapNhatId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_NguoiTaoId",
                table: "NhanViens",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_NoiKhamBenhId",
                table: "NhanViens",
                column: "NoiKhamBenhId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_PhongBanId",
                table: "NhanViens",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_QuanHuyenId",
                table: "NhanViens",
                column: "QuanHuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_TinhThanhId",
                table: "NhanViens",
                column: "TinhThanhId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_XaPhuongId",
                table: "NhanViens",
                column: "XaPhuongId");

            migrationBuilder.CreateIndex(
                name: "IX_NoiKhamBenhs_NguoiCapNhatId",
                table: "NoiKhamBenhs",
                column: "NguoiCapNhatId");

            migrationBuilder.CreateIndex(
                name: "IX_NoiKhamBenhs_NguoiTaoId",
                table: "NoiKhamBenhs",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PhongBans_NguoiCapNhatId",
                table: "PhongBans",
                column: "NguoiCapNhatId");

            migrationBuilder.CreateIndex(
                name: "IX_PhongBans_NguoiTaoId",
                table: "PhongBans",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PhuCaps_NguoiCapNhatId",
                table: "PhuCaps",
                column: "NguoiCapNhatId");

            migrationBuilder.CreateIndex(
                name: "IX_PhuCaps_NguoiTaoId",
                table: "PhuCaps",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PhucLois_NguoiCapNhatId",
                table: "PhucLois",
                column: "NguoiCapNhatId");

            migrationBuilder.CreateIndex(
                name: "IX_PhucLois_NguoiTaoId",
                table: "PhucLois",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyens_NguoiCapNhatId",
                table: "QuanHuyens",
                column: "NguoiCapNhatId");

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyens_NguoiTaoId",
                table: "QuanHuyens",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyens_TinhThanhId",
                table: "QuanHuyens",
                column: "TinhThanhId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyetDinhs_HopDongId",
                table: "QuyetDinhs",
                column: "HopDongId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuyetDinhs_HoSoLuongId",
                table: "QuyetDinhs",
                column: "HoSoLuongId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyetDinhs_NhanVienId",
                table: "QuyetDinhs",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiSans_NguoiCapNhatId",
                table: "TaiSans",
                column: "NguoiCapNhatId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiSans_NguoiTaoId",
                table: "TaiSans",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TapTinDinhKems_NhanVienId",
                table: "TapTinDinhKems",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_TinhThanhs_NguoiCapNhatId",
                table: "TinhThanhs",
                column: "NguoiCapNhatId");

            migrationBuilder.CreateIndex(
                name: "IX_TinhThanhs_NguoiTaoId",
                table: "TinhThanhs",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_XaPhuongs_NguoiCapNhatId",
                table: "XaPhuongs",
                column: "NguoiCapNhatId");

            migrationBuilder.CreateIndex(
                name: "IX_XaPhuongs_NguoiTaoId",
                table: "XaPhuongs",
                column: "NguoiTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_XaPhuongs_QuanHuyenId",
                table: "XaPhuongs",
                column: "QuanHuyenId");

            migrationBuilder.AddForeignKey(
                name: "FK_CapPhatTaiSans_NhanViens_NhanVienId",
                table: "CapPhatTaiSans",
                column: "NhanVienId",
                principalTable: "NhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CapPhatTaiSans_TaiSans_TaiSanId",
                table: "CapPhatTaiSans",
                column: "TaiSanId",
                principalTable: "TaiSans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiNhanhNganHangs_NganHangs_NganHangId",
                table: "ChiNhanhNganHangs",
                column: "NganHangId",
                principalTable: "NganHangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiNhanhNganHangs_NhanViens_NguoiCapNhatId",
                table: "ChiNhanhNganHangs",
                column: "NguoiCapNhatId",
                principalTable: "NhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiNhanhNganHangs_NhanViens_NguoiTaoId",
                table: "ChiNhanhNganHangs",
                column: "NguoiTaoId",
                principalTable: "NhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChucDanhPhongBans_ChucDanhs_ChucDanhId",
                table: "ChucDanhPhongBans",
                column: "ChucDanhId",
                principalTable: "ChucDanhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChucDanhPhongBans_PhongBans_PhongBanId",
                table: "ChucDanhPhongBans",
                column: "PhongBanId",
                principalTable: "PhongBans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChucDanhs_NhanViens_NguoiCapNhatId",
                table: "ChucDanhs",
                column: "NguoiCapNhatId",
                principalTable: "NhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChucDanhs_NhanViens_NguoiTaoId",
                table: "ChucDanhs",
                column: "NguoiTaoId",
                principalTable: "NhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhacs_NhanViens_NguoiCapNhatId",
                table: "DanhMucKhacs",
                column: "NguoiCapNhatId",
                principalTable: "NhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhacs_NhanViens_NguoiTaoId",
                table: "DanhMucKhacs",
                column: "NguoiTaoId",
                principalTable: "NhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_HopDongs_HoSoLuongs_HoSoLuongId",
                table: "HopDongs",
                column: "HoSoLuongId",
                principalTable: "HoSoLuongs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HopDongs_LoaiHopDongs_LoaiHopDongId",
                table: "HopDongs",
                column: "LoaiHopDongId",
                principalTable: "LoaiHopDongs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HopDongs_NhanViens_NhanVienId",
                table: "HopDongs",
                column: "NhanVienId",
                principalTable: "NhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_HoSoLuong_PhuCaps_HoSoLuongs_HoSoLuongId",
                table: "HoSoLuong_PhuCaps",
                column: "HoSoLuongId",
                principalTable: "HoSoLuongs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoSoLuong_PhuCaps_PhuCaps_PhuCapId",
                table: "HoSoLuong_PhuCaps",
                column: "PhuCapId",
                principalTable: "PhuCaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoSoLuong_PhucLois_HoSoLuongs_HoSoLuongId",
                table: "HoSoLuong_PhucLois",
                column: "HoSoLuongId",
                principalTable: "HoSoLuongs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoSoLuong_PhucLois_PhucLois_PhucLoiId",
                table: "HoSoLuong_PhucLois",
                column: "PhucLoiId",
                principalTable: "PhucLois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoSoLuongs_NhanViens_NhanVienId",
                table: "HoSoLuongs",
                column: "NhanVienId",
                principalTable: "NhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_HoSoLuongs_PhongBans_PhongBanId",
                table: "HoSoLuongs",
                column: "PhongBanId",
                principalTable: "PhongBans",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_KhenThuongs_NhanViens_NhanVienId",
                table: "KhenThuongs",
                column: "NhanVienId",
                principalTable: "NhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KyLuats_NhanViens_NhanVienId",
                table: "KyLuats",
                column: "NhanVienId",
                principalTable: "NhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiHopDongs_NhanViens_NguoiCapNhatId",
                table: "LoaiHopDongs",
                column: "NguoiCapNhatId",
                principalTable: "NhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiHopDongs_NhanViens_NguoiTaoId",
                table: "LoaiHopDongs",
                column: "NguoiTaoId",
                principalTable: "NhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_NganHangs_NhanViens_NguoiCapNhatId",
                table: "NganHangs",
                column: "NguoiCapNhatId",
                principalTable: "NhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NganHangs_NhanViens_NguoiTaoId",
                table: "NganHangs",
                column: "NguoiTaoId",
                principalTable: "NhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NghiViecs_NhanViens_NhanVienId",
                table: "NghiViecs",
                column: "NhanVienId",
                principalTable: "NhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiThanNhanViens_NhanViens_NhanVienId",
                table: "NguoiThanNhanViens",
                column: "NhanVienId",
                principalTable: "NhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhanViens_NoiKhamBenhs_NoiKhamBenhId",
                table: "NhanViens",
                column: "NoiKhamBenhId",
                principalTable: "NoiKhamBenhs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NhanViens_PhongBans_PhongBanId",
                table: "NhanViens",
                column: "PhongBanId",
                principalTable: "PhongBans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NhanViens_QuanHuyens_QuanHuyenId",
                table: "NhanViens",
                column: "QuanHuyenId",
                principalTable: "QuanHuyens",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NhanViens_TinhThanhs_TinhThanhId",
                table: "NhanViens",
                column: "TinhThanhId",
                principalTable: "TinhThanhs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NhanViens_XaPhuongs_XaPhuongId",
                table: "NhanViens",
                column: "XaPhuongId",
                principalTable: "XaPhuongs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiNhanhNganHangs_NhanViens_NguoiCapNhatId",
                table: "ChiNhanhNganHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiNhanhNganHangs_NhanViens_NguoiTaoId",
                table: "ChiNhanhNganHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChucDanhs_NhanViens_NguoiCapNhatId",
                table: "ChucDanhs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChucDanhs_NhanViens_NguoiTaoId",
                table: "ChucDanhs");

            migrationBuilder.DropForeignKey(
                name: "FK_NganHangs_NhanViens_NguoiCapNhatId",
                table: "NganHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_NganHangs_NhanViens_NguoiTaoId",
                table: "NganHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_NoiKhamBenhs_NhanViens_NguoiCapNhatId",
                table: "NoiKhamBenhs");

            migrationBuilder.DropForeignKey(
                name: "FK_NoiKhamBenhs_NhanViens_NguoiTaoId",
                table: "NoiKhamBenhs");

            migrationBuilder.DropForeignKey(
                name: "FK_PhongBans_NhanViens_NguoiCapNhatId",
                table: "PhongBans");

            migrationBuilder.DropForeignKey(
                name: "FK_PhongBans_NhanViens_NguoiTaoId",
                table: "PhongBans");

            migrationBuilder.DropForeignKey(
                name: "FK_QuanHuyens_NhanViens_NguoiCapNhatId",
                table: "QuanHuyens");

            migrationBuilder.DropForeignKey(
                name: "FK_QuanHuyens_NhanViens_NguoiTaoId",
                table: "QuanHuyens");

            migrationBuilder.DropForeignKey(
                name: "FK_TinhThanhs_NhanViens_NguoiCapNhatId",
                table: "TinhThanhs");

            migrationBuilder.DropForeignKey(
                name: "FK_TinhThanhs_NhanViens_NguoiTaoId",
                table: "TinhThanhs");

            migrationBuilder.DropForeignKey(
                name: "FK_XaPhuongs_NhanViens_NguoiCapNhatId",
                table: "XaPhuongs");

            migrationBuilder.DropForeignKey(
                name: "FK_XaPhuongs_NhanViens_NguoiTaoId",
                table: "XaPhuongs");

            migrationBuilder.DropTable(
                name: "CapPhatTaiSans");

            migrationBuilder.DropTable(
                name: "DanhMucKhacs");

            migrationBuilder.DropTable(
                name: "HoSoLuong_PhuCaps");

            migrationBuilder.DropTable(
                name: "HoSoLuong_PhucLois");

            migrationBuilder.DropTable(
                name: "KhenThuongs");

            migrationBuilder.DropTable(
                name: "KyLuats");

            migrationBuilder.DropTable(
                name: "NghiViecs");

            migrationBuilder.DropTable(
                name: "NguoiThanNhanViens");

            migrationBuilder.DropTable(
                name: "QuyetDinhs");

            migrationBuilder.DropTable(
                name: "TapTinDinhKems");

            migrationBuilder.DropTable(
                name: "TaiSans");

            migrationBuilder.DropTable(
                name: "PhuCaps");

            migrationBuilder.DropTable(
                name: "PhucLois");

            migrationBuilder.DropTable(
                name: "HopDongs");

            migrationBuilder.DropTable(
                name: "HoSoLuongs");

            migrationBuilder.DropTable(
                name: "LoaiHopDongs");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "ChiNhanhNganHangs");

            migrationBuilder.DropTable(
                name: "ChucDanhPhongBans");

            migrationBuilder.DropTable(
                name: "NoiKhamBenhs");

            migrationBuilder.DropTable(
                name: "XaPhuongs");

            migrationBuilder.DropTable(
                name: "NganHangs");

            migrationBuilder.DropTable(
                name: "ChucDanhs");

            migrationBuilder.DropTable(
                name: "PhongBans");

            migrationBuilder.DropTable(
                name: "QuanHuyens");

            migrationBuilder.DropTable(
                name: "TinhThanhs");
        }
    }
}
