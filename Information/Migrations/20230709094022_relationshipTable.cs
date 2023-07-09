using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Information.Migrations
{
    /// <inheritdoc />
    public partial class relationshipTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Factors_PassengerId",
                table: "Factors");

            migrationBuilder.DropIndex(
                name: "IX_Factors_TripId",
                table: "Factors");

            migrationBuilder.CreateIndex(
                name: "IX_Factors_PassengerId",
                table: "Factors",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Factors_TripId",
                table: "Factors",
                column: "TripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Factors_PassengerId",
                table: "Factors");

            migrationBuilder.DropIndex(
                name: "IX_Factors_TripId",
                table: "Factors");

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
        }
    }
}
