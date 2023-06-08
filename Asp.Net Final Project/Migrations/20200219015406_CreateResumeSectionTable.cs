using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Net_Final_Project.Migrations
{
    public partial class CreateResumeSectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SectionResume",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(maxLength: 30, nullable: false),
                    FirstSubSectionName = table.Column<string>(maxLength: 30, nullable: false),
                    SecondSubSectionName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionResume", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResumeEducationItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    Calendar = table.Column<string>(maxLength: 30, nullable: false),
                    Sec = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: false),
                    SectionResumeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeEducationItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeEducationItem_SectionResume_SectionResumeId",
                        column: x => x.SectionResumeId,
                        principalTable: "SectionResume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeExperienceItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    Calendar = table.Column<string>(maxLength: 30, nullable: false),
                    Sec = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: false),
                    SectionResumeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeExperienceItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeExperienceItem_SectionResume_SectionResumeId",
                        column: x => x.SectionResumeId,
                        principalTable: "SectionResume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResumeEducationItem_SectionResumeId",
                table: "ResumeEducationItem",
                column: "SectionResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeExperienceItem_SectionResumeId",
                table: "ResumeExperienceItem",
                column: "SectionResumeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResumeEducationItem");

            migrationBuilder.DropTable(
                name: "ResumeExperienceItem");

            migrationBuilder.DropTable(
                name: "SectionResume");
        }
    }
}
