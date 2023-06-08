using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Net_Final_Project.Migrations
{
    public partial class CreateWorkProcessSectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SectionWorkProcess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(maxLength: 30, nullable: false),
                    Circle = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionWorkProcess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingProcessItemLeft",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Step = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 20, nullable: false),
                    Idea = table.Column<string>(maxLength: 20, nullable: false),
                    SectionWorkProcessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingProcessItemLeft", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingProcessItemLeft_SectionWorkProcess_SectionWorkProcessId",
                        column: x => x.SectionWorkProcessId,
                        principalTable: "SectionWorkProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkingProcessItemRight",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Step = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 20, nullable: false),
                    Idea = table.Column<string>(maxLength: 20, nullable: false),
                    SectionWorkProcessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingProcessItemRight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingProcessItemRight_SectionWorkProcess_SectionWorkProcessId",
                        column: x => x.SectionWorkProcessId,
                        principalTable: "SectionWorkProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkingProcessItemLeft_SectionWorkProcessId",
                table: "WorkingProcessItemLeft",
                column: "SectionWorkProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingProcessItemRight_SectionWorkProcessId",
                table: "WorkingProcessItemRight",
                column: "SectionWorkProcessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkingProcessItemLeft");

            migrationBuilder.DropTable(
                name: "WorkingProcessItemRight");

            migrationBuilder.DropTable(
                name: "SectionWorkProcess");
        }
    }
}
