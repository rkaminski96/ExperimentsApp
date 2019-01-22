using Microsoft.EntityFrameworkCore.Migrations;

namespace ExperimentsApp.API.Migrations
{
    public partial class manageSensorRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachineSensors");

            migrationBuilder.CreateTable(
                name: "ExperimentSensors",
                columns: table => new
                {
                    ExperimentId = table.Column<int>(nullable: false),
                    SensorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperimentSensors", x => new { x.ExperimentId, x.SensorId });
                    table.ForeignKey(
                        name: "FK_ExperimentSensors_Experiments_ExperimentId",
                        column: x => x.ExperimentId,
                        principalTable: "Experiments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperimentSensors_Sensors_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExperimentSensors_SensorId",
                table: "ExperimentSensors",
                column: "SensorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperimentSensors");

            migrationBuilder.CreateTable(
                name: "MachineSensors",
                columns: table => new
                {
                    MachineId = table.Column<int>(nullable: false),
                    SensorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineSensors", x => new { x.MachineId, x.SensorId });
                    table.ForeignKey(
                        name: "FK_MachineSensors_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineSensors_Sensors_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MachineSensors_SensorId",
                table: "MachineSensors",
                column: "SensorId");
        }
    }
}
