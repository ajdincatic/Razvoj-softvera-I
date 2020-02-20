using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_Ispit_asp.net_core.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OdrzaniCas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PredajePredmetId = table.Column<int>(nullable: false),
                    SadrzajaCasa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdrzaniCas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdrzaniCas_PredajePredmet_PredajePredmetId",
                        column: x => x.PredajePredmetId,
                        principalTable: "PredajePredmet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OdrzanCasDetalji",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bodovi = table.Column<int>(nullable: true),
                    IsPrisutan = table.Column<bool>(nullable: false),
                    Napomena = table.Column<string>(nullable: true),
                    OdrzanicasId = table.Column<int>(nullable: false),
                    OpravdanoOdsutan = table.Column<bool>(nullable: true),
                    UcenikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdrzanCasDetalji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdrzanCasDetalji_OdrzaniCas_OdrzanicasId",
                        column: x => x.OdrzanicasId,
                        principalTable: "OdrzaniCas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OdrzanCasDetalji_Ucenik_UcenikId",
                        column: x => x.UcenikId,
                        principalTable: "Ucenik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OdrzanCasDetalji_OdrzanicasId",
                table: "OdrzanCasDetalji",
                column: "OdrzanicasId");

            migrationBuilder.CreateIndex(
                name: "IX_OdrzanCasDetalji_UcenikId",
                table: "OdrzanCasDetalji",
                column: "UcenikId");

            migrationBuilder.CreateIndex(
                name: "IX_OdrzaniCas_PredajePredmetId",
                table: "OdrzaniCas",
                column: "PredajePredmetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OdrzanCasDetalji");

            migrationBuilder.DropTable(
                name: "OdrzaniCas");
        }
    }
}
