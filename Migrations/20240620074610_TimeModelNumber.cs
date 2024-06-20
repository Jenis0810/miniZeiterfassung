using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace miniZeiterfassung.Migrations
{
    /// <inheritdoc />
    public partial class TimeModelNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeModelNumber",
                table: "TimeModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeModelNumber",
                table: "TimeModels");
        }
    }
}
