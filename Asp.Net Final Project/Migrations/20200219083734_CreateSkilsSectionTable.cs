using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Net_Final_Project.Migrations
{
    public partial class CreateSkilsSectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SectionSkills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillsChart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgressTitle = table.Column<string>(maxLength: 40, nullable: false),
                    ProgressValue = table.Column<int>(nullable: false),
                    BarColor = table.Column<string>(maxLength: 40, nullable: false),
                    SectionSkillsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsChart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsChart_SectionSkills_SectionSkillsId",
                        column: x => x.SectionSkillsId,
                        principalTable: "SectionSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillsProgressBar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgressTitle = table.Column<string>(maxLength: 40, nullable: false),
                    ProgressValue = table.Column<int>(nullable: false),
                    SectionSkillsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsProgressBar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsProgressBar_SectionSkills_SectionSkillsId",
                        column: x => x.SectionSkillsId,
                        principalTable: "SectionSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillsChart_SectionSkillsId",
                table: "SkillsChart",
                column: "SectionSkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsProgressBar_SectionSkillsId",
                table: "SkillsProgressBar",
                column: "SectionSkillsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillsChart");

            migrationBuilder.DropTable(
                name: "SkillsProgressBar");

            migrationBuilder.DropTable(
                name: "SectionSkills");
        }
    }
}
