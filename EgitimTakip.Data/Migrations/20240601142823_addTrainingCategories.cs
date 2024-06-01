using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EgitimTakip.Data.Migrations
{
    /// <inheritdoc />
    public partial class addTrainingCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingsSubjectsMap_TrainingSubjects_TrainingSubjectId",
                table: "TrainingsSubjectsMap");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingsSubjectsMap_Trainings_TrainingId",
                table: "TrainingsSubjectsMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingsSubjectsMap",
                table: "TrainingsSubjectsMap");

            migrationBuilder.RenameTable(
                name: "TrainingsSubjectsMap",
                newName: "TrainingsSubjectsMaps");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingsSubjectsMap_TrainingSubjectId",
                table: "TrainingsSubjectsMaps",
                newName: "IX_TrainingsSubjectsMaps_TrainingSubjectId");

            migrationBuilder.AddColumn<int>(
                name: "TrainingCategoryId",
                table: "TrainingSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingsSubjectsMaps",
                table: "TrainingsSubjectsMaps",
                columns: new[] { "TrainingId", "TrainingSubjectId" });

            migrationBuilder.CreateTable(
                name: "TrainingCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSubjects_TrainingCategoryId",
                table: "TrainingSubjects",
                column: "TrainingCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingsSubjectsMaps_TrainingSubjects_TrainingSubjectId",
                table: "TrainingsSubjectsMaps",
                column: "TrainingSubjectId",
                principalTable: "TrainingSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingsSubjectsMaps_Trainings_TrainingId",
                table: "TrainingsSubjectsMaps",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingSubjects_TrainingCategories_TrainingCategoryId",
                table: "TrainingSubjects",
                column: "TrainingCategoryId",
                principalTable: "TrainingCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingsSubjectsMaps_TrainingSubjects_TrainingSubjectId",
                table: "TrainingsSubjectsMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingsSubjectsMaps_Trainings_TrainingId",
                table: "TrainingsSubjectsMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingSubjects_TrainingCategories_TrainingCategoryId",
                table: "TrainingSubjects");

            migrationBuilder.DropTable(
                name: "TrainingCategories");

            migrationBuilder.DropIndex(
                name: "IX_TrainingSubjects_TrainingCategoryId",
                table: "TrainingSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingsSubjectsMaps",
                table: "TrainingsSubjectsMaps");

            migrationBuilder.DropColumn(
                name: "TrainingCategoryId",
                table: "TrainingSubjects");

            migrationBuilder.RenameTable(
                name: "TrainingsSubjectsMaps",
                newName: "TrainingsSubjectsMap");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingsSubjectsMaps_TrainingSubjectId",
                table: "TrainingsSubjectsMap",
                newName: "IX_TrainingsSubjectsMap_TrainingSubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingsSubjectsMap",
                table: "TrainingsSubjectsMap",
                columns: new[] { "TrainingId", "TrainingSubjectId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingsSubjectsMap_TrainingSubjects_TrainingSubjectId",
                table: "TrainingsSubjectsMap",
                column: "TrainingSubjectId",
                principalTable: "TrainingSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingsSubjectsMap_Trainings_TrainingId",
                table: "TrainingsSubjectsMap",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
