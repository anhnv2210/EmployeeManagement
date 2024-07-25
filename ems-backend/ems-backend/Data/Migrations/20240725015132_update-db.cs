using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ems_backend.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MoTa",
                table: "XaPhuongs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MoTa",
                table: "TinhThanhs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "QuocGiaId",
                table: "TinhThanhs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MoTa",
                table: "QuanHuyens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "QuocGiaId",
                table: "NhanViens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuocGias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuocGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoId = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatId = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuocGias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuocGias_NhanViens_NguoiCapNhatId",
                        column: x => x.NguoiCapNhatId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuocGias_NhanViens_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TinhThanhs_QuocGiaId",
                table: "TinhThanhs",
                column: "QuocGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_QuocGiaId",
                table: "NhanViens",
                column: "QuocGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_QuocGias_NguoiCapNhatId",
                table: "QuocGias",
                column: "NguoiCapNhatId");

            migrationBuilder.CreateIndex(
                name: "IX_QuocGias_NguoiTaoId",
                table: "QuocGias",
                column: "NguoiTaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_NhanViens_QuocGias_QuocGiaId",
                table: "NhanViens",
                column: "QuocGiaId",
                principalTable: "QuocGias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TinhThanhs_QuocGias_QuocGiaId",
                table: "TinhThanhs",
                column: "QuocGiaId",
                principalTable: "QuocGias",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhanViens_QuocGias_QuocGiaId",
                table: "NhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_TinhThanhs_QuocGias_QuocGiaId",
                table: "TinhThanhs");

            migrationBuilder.DropTable(
                name: "QuocGias");

            migrationBuilder.DropIndex(
                name: "IX_TinhThanhs_QuocGiaId",
                table: "TinhThanhs");

            migrationBuilder.DropIndex(
                name: "IX_NhanViens_QuocGiaId",
                table: "NhanViens");

            migrationBuilder.DropColumn(
                name: "MoTa",
                table: "XaPhuongs");

            migrationBuilder.DropColumn(
                name: "MoTa",
                table: "TinhThanhs");

            migrationBuilder.DropColumn(
                name: "QuocGiaId",
                table: "TinhThanhs");

            migrationBuilder.DropColumn(
                name: "MoTa",
                table: "QuanHuyens");

            migrationBuilder.DropColumn(
                name: "QuocGiaId",
                table: "NhanViens");
        }
    }
}
