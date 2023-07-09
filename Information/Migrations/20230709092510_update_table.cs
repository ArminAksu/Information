using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Information.Migrations
{
    /// <inheritdoc />
    public partial class update_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountTrip",
                table: "Factors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PassengerId",
                table: "Factors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "Factors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Factors_PassengerId",
                table: "Factors",
                column: "PassengerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Factors_TripId",
                table: "Factors",
                column: "TripId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Factors_passengers_PassengerId",
                table: "Factors",
                column: "PassengerId",
                principalTable: "passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Factors_trips_TripId",
                table: "Factors",
                column: "TripId",
                principalTable: "trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factors_passengers_PassengerId",
                table: "Factors");

            migrationBuilder.DropForeignKey(
                name: "FK_Factors_trips_TripId",
                table: "Factors");

            migrationBuilder.DropIndex(
                name: "IX_Factors_PassengerId",
                table: "Factors");

            migrationBuilder.DropIndex(
                name: "IX_Factors_TripId",
                table: "Factors");

            migrationBuilder.DropColumn(
                name: "AmountTrip",
                table: "Factors");

            migrationBuilder.DropColumn(
                name: "PassengerId",
                table: "Factors");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "Factors");
        }
    }
}
