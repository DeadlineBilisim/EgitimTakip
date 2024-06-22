using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EgitimTakip.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFilePathToTraining : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Trainings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Trainings");
        }
    }
}
