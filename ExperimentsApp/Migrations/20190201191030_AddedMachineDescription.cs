using Microsoft.EntityFrameworkCore.Migrations;

namespace ExperimentsApp.API.Migrations
{
    public partial class AddedMachineDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiments_Users_UserId",
                table: "Experiments");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Machines",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Experiments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiments_Users_UserId",
                table: "Experiments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiments_Users_UserId",
                table: "Experiments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Machines");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Experiments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Experiments_Users_UserId",
                table: "Experiments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
