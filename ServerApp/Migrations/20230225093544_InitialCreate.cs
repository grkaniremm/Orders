using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgirlikBirim",
                columns: table => new
                {
                    BirimKodu = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Aciklamasi = table.Column<string>(nullable: true),
                    StateCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgirlikBirim", x => x.BirimKodu);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    MalzemeKodu = table.Column<string>(nullable: false),
                    MalzemeAdi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.MalzemeKodu);
                });

            migrationBuilder.CreateTable(
                name: "MiktarBirim",
                columns: table => new
                {
                    BirimKodu = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Aciklamasi = table.Column<string>(nullable: true),
                    StateCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiktarBirim", x => x.BirimKodu);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    SistemSiparisNo = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MusteriNo = table.Column<string>(nullable: true),
                    MusteriSiparisNo = table.Column<string>(nullable: true),
                    CikisAdresi = table.Column<string>(nullable: true),
                    VarisAdresi = table.Column<string>(nullable: true),
                    Miktar = table.Column<decimal>(nullable: false),
                    MiktarBirim = table.Column<int>(nullable: false),
                    Agirlik = table.Column<decimal>(nullable: false),
                    AgirlikBirim = table.Column<int>(nullable: false),
                    MalzemeKodu = table.Column<string>(nullable: true),
                    MalzemeAdi = table.Column<string>(nullable: true),
                    Not = table.Column<string>(nullable: true),
                    Statu = table.Column<int>(nullable: false),
                    StateCode = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<string>(nullable: true),
                    ModifyOn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.SistemSiparisNo);
                });

            migrationBuilder.CreateTable(
                name: "Statu",
                columns: table => new
                {
                    StatuKodu = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Aciklamasi = table.Column<string>(nullable: true),
                    StateCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statu", x => x.StatuKodu);
                });

            migrationBuilder.CreateTable(
                name: "StatuLogs",
                columns: table => new
                {
                    StatuLogId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SistemSiparisNo = table.Column<long>(nullable: false),
                    MusteriNo = table.Column<string>(nullable: true),
                    MusteriSiparisNo = table.Column<string>(nullable: true),
                    Statu = table.Column<string>(nullable: true),
                    DegisimTarihi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatuLogs", x => x.StatuLogId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgirlikBirim");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "MiktarBirim");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Statu");

            migrationBuilder.DropTable(
                name: "StatuLogs");
        }
    }
}
