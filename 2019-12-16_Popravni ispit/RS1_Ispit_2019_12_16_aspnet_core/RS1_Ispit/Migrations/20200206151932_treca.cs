using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_Ispit_asp.net_core.Migrations
{
    public partial class treca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PopravniIspit_Predmet_PredmetId",
                table: "PopravniIspit");

            migrationBuilder.DropForeignKey(
                name: "FK_PopravniIspit_Skola_SkolaId",
                table: "PopravniIspit");

            migrationBuilder.DropForeignKey(
                name: "FK_PopravniIspit_SkolskaGodina_SkolskaGodinaId",
                table: "PopravniIspit");

            migrationBuilder.DropIndex(
                name: "IX_PopravniIspit_PredmetId",
                table: "PopravniIspit");

            migrationBuilder.DropIndex(
                name: "IX_PopravniIspit_SkolaId",
                table: "PopravniIspit");

            migrationBuilder.DropColumn(
                name: "PredmetId",
                table: "PopravniIspit");

            migrationBuilder.DropColumn(
                name: "SkolaId",
                table: "PopravniIspit");

            migrationBuilder.RenameColumn(
                name: "SkolskaGodinaId",
                table: "PopravniIspit",
                newName: "PopravniIspitOpstiPodaciId");

            migrationBuilder.RenameIndex(
                name: "IX_PopravniIspit_SkolskaGodinaId",
                table: "PopravniIspit",
                newName: "IX_PopravniIspit_PopravniIspitOpstiPodaciId");

            migrationBuilder.CreateTable(
                name: "PopravniIspitOpstiPodaci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PredmetId = table.Column<int>(nullable: false),
                    SkolaId = table.Column<int>(nullable: false),
                    SkolskaGodinaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopravniIspitOpstiPodaci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PopravniIspitOpstiPodaci_Predmet_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PopravniIspitOpstiPodaci_Skola_SkolaId",
                        column: x => x.SkolaId,
                        principalTable: "Skola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PopravniIspitOpstiPodaci_SkolskaGodina_SkolskaGodinaId",
                        column: x => x.SkolskaGodinaId,
                        principalTable: "SkolskaGodina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PopravniIspitOpstiPodaci_PredmetId",
                table: "PopravniIspitOpstiPodaci",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_PopravniIspitOpstiPodaci_SkolaId",
                table: "PopravniIspitOpstiPodaci",
                column: "SkolaId");

            migrationBuilder.CreateIndex(
                name: "IX_PopravniIspitOpstiPodaci_SkolskaGodinaId",
                table: "PopravniIspitOpstiPodaci",
                column: "SkolskaGodinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PopravniIspit_PopravniIspitOpstiPodaci_PopravniIspitOpstiPodaciId",
                table: "PopravniIspit",
                column: "PopravniIspitOpstiPodaciId",
                principalTable: "PopravniIspitOpstiPodaci",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PopravniIspit_PopravniIspitOpstiPodaci_PopravniIspitOpstiPodaciId",
                table: "PopravniIspit");

            migrationBuilder.DropTable(
                name: "PopravniIspitOpstiPodaci");

            migrationBuilder.RenameColumn(
                name: "PopravniIspitOpstiPodaciId",
                table: "PopravniIspit",
                newName: "SkolskaGodinaId");

            migrationBuilder.RenameIndex(
                name: "IX_PopravniIspit_PopravniIspitOpstiPodaciId",
                table: "PopravniIspit",
                newName: "IX_PopravniIspit_SkolskaGodinaId");

            migrationBuilder.AddColumn<int>(
                name: "PredmetId",
                table: "PopravniIspit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkolaId",
                table: "PopravniIspit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PopravniIspit_PredmetId",
                table: "PopravniIspit",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_PopravniIspit_SkolaId",
                table: "PopravniIspit",
                column: "SkolaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PopravniIspit_Predmet_PredmetId",
                table: "PopravniIspit",
                column: "PredmetId",
                principalTable: "Predmet",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PopravniIspit_Skola_SkolaId",
                table: "PopravniIspit",
                column: "SkolaId",
                principalTable: "Skola",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PopravniIspit_SkolskaGodina_SkolskaGodinaId",
                table: "PopravniIspit",
                column: "SkolskaGodinaId",
                principalTable: "SkolskaGodina",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
