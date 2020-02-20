using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Ispit_asp.net_core.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TakmicenjeUcesnik_Ucenik_UcesnikId",
                table: "TakmicenjeUcesnik");

            migrationBuilder.RenameColumn(
                name: "UcesnikId",
                table: "TakmicenjeUcesnik",
                newName: "OdjeljenjeStavkaId");

            migrationBuilder.RenameIndex(
                name: "IX_TakmicenjeUcesnik_UcesnikId",
                table: "TakmicenjeUcesnik",
                newName: "IX_TakmicenjeUcesnik_OdjeljenjeStavkaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TakmicenjeUcesnik_OdjeljenjeStavka_OdjeljenjeStavkaId",
                table: "TakmicenjeUcesnik",
                column: "OdjeljenjeStavkaId",
                principalTable: "OdjeljenjeStavka",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TakmicenjeUcesnik_OdjeljenjeStavka_OdjeljenjeStavkaId",
                table: "TakmicenjeUcesnik");

            migrationBuilder.RenameColumn(
                name: "OdjeljenjeStavkaId",
                table: "TakmicenjeUcesnik",
                newName: "UcesnikId");

            migrationBuilder.RenameIndex(
                name: "IX_TakmicenjeUcesnik_OdjeljenjeStavkaId",
                table: "TakmicenjeUcesnik",
                newName: "IX_TakmicenjeUcesnik_UcesnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_TakmicenjeUcesnik_Ucenik_UcesnikId",
                table: "TakmicenjeUcesnik",
                column: "UcesnikId",
                principalTable: "Ucenik",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
