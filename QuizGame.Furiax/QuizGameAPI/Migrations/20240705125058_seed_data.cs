using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class seed_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "QuizId", "QuizName" },
                values: new object[,]
                {
                    { new Guid("0cd38b82-8078-4d71-912d-c224ce52d5e5"), "Football" },
                    { new Guid("409aa05a-de77-470b-929b-10b250cdffa4"), "General Knowledge" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "CorrectAnswer", "Option1", "Option2", "Option3", "Option4", "QuestionToAsk", "QuizId" },
                values: new object[,]
                {
                    { new Guid("5b2ce823-2c64-4532-a405-e92cf464fcae"), "Brussels", "Antwerp", "Ghent", "Brussels", "Brugge", "What is the capital of Belgium?", new Guid("409aa05a-de77-470b-929b-10b250cdffa4") },
                    { new Guid("c5ec747f-8034-4ea3-90ba-d39d6da20542"), "Argentina", "Argentina", "Croatia", "France", "Marocco", "Who won WK2022 in Qatar ?", new Guid("0cd38b82-8078-4d71-912d-c224ce52d5e5") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: new Guid("5b2ce823-2c64-4532-a405-e92cf464fcae"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: new Guid("c5ec747f-8034-4ea3-90ba-d39d6da20542"));

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "QuizId",
                keyValue: new Guid("0cd38b82-8078-4d71-912d-c224ce52d5e5"));

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "QuizId",
                keyValue: new Guid("409aa05a-de77-470b-929b-10b250cdffa4"));
        }
    }
}
