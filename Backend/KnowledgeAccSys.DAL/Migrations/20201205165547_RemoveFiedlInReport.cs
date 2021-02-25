using Microsoft.EntityFrameworkCore.Migrations;

namespace KnowledgeAccSys.DAL.Migrations
{
    public partial class RemoveFiedlInReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvgWrongAnswers",
                table: "Reports");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AvgWrongAnswers",
                table: "Reports",
                type: "float",
                nullable: false,
                defaultValue: 0.0);        
        }
    }
}
