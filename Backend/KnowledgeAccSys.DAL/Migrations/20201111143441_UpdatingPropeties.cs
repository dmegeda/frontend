using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KnowledgeAccSys.DAL.Migrations
{
    public partial class UpdatingPropeties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Themes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Tests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tests",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaxRate",
                table: "Tests",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MinRatingForPass",
                table: "Tests",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Tests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ThemeId",
                table: "Tests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Theme_Id",
                table: "Tests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPassed",
                table: "Statistics",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Statistics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Statistics",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UserRating",
                table: "Statistics",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "AllTestingUser",
                table: "Reports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "AvgRate",
                table: "Reports",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AvgWrongAnswers",
                table: "Reports",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "PassedUserCount",
                table: "Reports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CorrectAnswer",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Questions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_ThemeId",
                table: "Tests",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_TestId",
                table: "Statistics",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_UserId",
                table: "Statistics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_TestId",
                table: "Reports",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Tests_TestId",
                table: "Questions",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Tests_TestId",
                table: "Reports",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Tests_TestId",
                table: "Statistics",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_AspNetUsers_UserId",
                table: "Statistics",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Themes_ThemeId",
                table: "Tests",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Tests_TestId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Tests_TestId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Tests_TestId",
                table: "Statistics");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_AspNetUsers_UserId",
                table: "Statistics");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Themes_ThemeId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_ThemeId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Statistics_TestId",
                table: "Statistics");

            migrationBuilder.DropIndex(
                name: "IX_Statistics_UserId",
                table: "Statistics");

            migrationBuilder.DropIndex(
                name: "IX_Reports_TestId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Questions_TestId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Themes");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "MaxRate",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "MinRatingForPass",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "ThemeId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Theme_Id",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "IsPassed",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "UserRating",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "AllTestingUser",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "AvgRate",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "AvgWrongAnswers",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "PassedUserCount",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Questions");
        }
    }
}
