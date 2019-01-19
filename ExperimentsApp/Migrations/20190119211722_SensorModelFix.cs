using Microsoft.EntityFrameworkCore.Migrations;

namespace ExperimentsApp.API.Migrations
{
    public partial class SensorModelFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sensorProperties",
                table: "Sensors",
                newName: "SensorProperties");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SensorProperties",
                table: "Sensors",
                newName: "sensorProperties");
        }
    }
}
