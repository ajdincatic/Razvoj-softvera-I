using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_Ispit_asp.net_core.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkolaId",
                table: "Nastavnik",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Nastavnik_SkolaId",
                table: "Nastavnik",
                column: "SkolaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nastavnik_Skola_SkolaId",
                table: "Nastavnik",
                column: "SkolaId",
                principalTable: "Skola",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nastavnik_Skola_SkolaId",
                table: "Nastavnik");

            migrationBuilder.DropIndex(
                name: "IX_Nastavnik_SkolaId",
                table: "Nastavnik");

            migrationBuilder.DropColumn(
                name: "SkolaId",
                table: "Nastavnik");
        }
    }
}
