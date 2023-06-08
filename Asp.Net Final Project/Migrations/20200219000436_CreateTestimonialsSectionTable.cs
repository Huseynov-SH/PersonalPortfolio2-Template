using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Net_Final_Project.Migrations
{
    public partial class CreateTestimonialsSectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SectionTestimonial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionTestimonial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestimonailItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(maxLength: 255, nullable: false),
                    FullName = table.Column<string>(maxLength: 40, nullable: false),
                    Job = table.Column<string>(maxLength: 30, nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 400, nullable: false),
                    SectionTestimonialId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestimonailItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestimonailItem_SectionTestimonial_SectionTestimonialId",
                        column: x => x.SectionTestimonialId,
                        principalTable: "SectionTestimonial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestimonailItem_SectionTestimonialId",
                table: "TestimonailItem",
                column: "SectionTestimonialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestimonailItem");

            migrationBuilder.DropTable(
                name: "SectionTestimonial");
        }
    }
}
