using Microsoft.EntityFrameworkCore.Migrations;

namespace ExperimentsApp.API.Migrations
{
    public partial class dictionaryInsteadOfKeyValuePair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sensorProperties",
                table: "Sensors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sensorProperties",
                table: "Sensors");
        }
    }
}
