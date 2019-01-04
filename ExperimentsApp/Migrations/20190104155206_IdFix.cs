using Microsoft.EntityFrameworkCore.Migrations;

namespace ExperimentsApp.API.Migrations
{
    public partial class IdFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SensorId",
                table: "Sensors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MachineId",
                table: "Machines",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ExperimentTypeId",
                table: "ExperimentTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ExperimentId",
                table: "Experiments",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sensors",
                newName: "SensorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Machines",
                newName: "MachineId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ExperimentTypes",
                newName: "ExperimentTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Experiments",
                newName: "ExperimentId");
        }
    }
}
