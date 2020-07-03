using Microsoft.EntityFrameworkCore.Migrations;

namespace EFSamurai.Data.Migrations
{
    public partial class AddHairstyle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QualityOfQuote",
                table: "Quotes");

            migrationBuilder.AddColumn<int>(
                name: "HairStyle",
                table: "Samurais",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuoteStyle",
                table: "Quotes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HairStyle",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "QuoteStyle",
                table: "Quotes");

            migrationBuilder.AddColumn<int>(
                name: "QualityOfQuote",
                table: "Quotes",
                type: "int",
                nullable: true);
        }
    }
}
