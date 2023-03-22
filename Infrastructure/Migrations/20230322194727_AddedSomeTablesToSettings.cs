using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedSomeTablesToSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "SensorSettings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfSensorId",
                table: "SensorSettings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    UrlToScreenshot = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfSensor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfSensor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensorSettings_RoomId",
                table: "SensorSettings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorSettings_TypeOfSensorId",
                table: "SensorSettings",
                column: "TypeOfSensorId");

            migrationBuilder.AddForeignKey(
                name: "FK_SensorSettings_Rooms_RoomId",
                table: "SensorSettings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SensorSettings_TypesOfSensor_TypeOfSensorId",
                table: "SensorSettings",
                column: "TypeOfSensorId",
                principalTable: "TypesOfSensor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SensorSettings_Rooms_RoomId",
                table: "SensorSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_SensorSettings_TypesOfSensor_TypeOfSensorId",
                table: "SensorSettings");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "TypesOfSensor");

            migrationBuilder.DropIndex(
                name: "IX_SensorSettings_RoomId",
                table: "SensorSettings");

            migrationBuilder.DropIndex(
                name: "IX_SensorSettings_TypeOfSensorId",
                table: "SensorSettings");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "SensorSettings");

            migrationBuilder.DropColumn(
                name: "TypeOfSensorId",
                table: "SensorSettings");
        }
    }
}
