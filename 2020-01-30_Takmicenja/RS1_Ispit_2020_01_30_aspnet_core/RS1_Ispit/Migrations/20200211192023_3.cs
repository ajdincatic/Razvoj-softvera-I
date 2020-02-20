using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Ispit_asp.net_core.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsZakljucano",
                table: "Takmicenje",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsZakljucano",
                table: "Takmicenje");
        }
    }
}
