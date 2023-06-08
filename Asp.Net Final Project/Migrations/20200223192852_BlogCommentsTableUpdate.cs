using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Net_Final_Project.Migrations
{
    public partial class BlogCommentsTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imahe",
                table: "BlogComments");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "BlogComments",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BlogComments",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "BlogComments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BlogComments");

            migrationBuilder.AddColumn<string>(
                name: "Imahe",
                table: "BlogComments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
