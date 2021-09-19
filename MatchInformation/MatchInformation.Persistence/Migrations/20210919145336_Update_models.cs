using Microsoft.EntityFrameworkCore.Migrations;

namespace MatchInformation.Persistence.Migrations
{
    public partial class Update_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "MatchOdds",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Match",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MatchOdds",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Match",
                newName: "ID");
        }
    }
}
