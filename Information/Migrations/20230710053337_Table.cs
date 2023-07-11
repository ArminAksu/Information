using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Information.Migrations
{
    /// <inheritdoc />
    public partial class Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Kilometr",
                table: "passengers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalAmount",
                table: "passengers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kilometr",
                table: "passengers");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "passengers");
        }
    }
}
