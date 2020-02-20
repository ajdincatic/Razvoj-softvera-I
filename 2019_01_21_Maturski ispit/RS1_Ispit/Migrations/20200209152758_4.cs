using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_Ispit_asp.net_core.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NastavnikId",
                table: "MaturskiIspit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MaturskiIspit_NastavnikId",
                table: "MaturskiIspit",
                column: "NastavnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaturskiIspit_Nastavnik_NastavnikId",
                table: "MaturskiIspit",
                column: "NastavnikId",
                principalTable: "Nastavnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaturskiIspit_Nastavnik_NastavnikId",
                table: "MaturskiIspit");

            migrationBuilder.DropIndex(
                name: "IX_MaturskiIspit_NastavnikId",
                table: "MaturskiIspit");

            migrationBuilder.DropColumn(
                name: "NastavnikId",
                table: "MaturskiIspit");
        }
    }
}
