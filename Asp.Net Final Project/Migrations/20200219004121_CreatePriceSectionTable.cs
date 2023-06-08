using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Net_Final_Project.Migrations
{
    public partial class CreatePriceSectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SectionPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionPrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceBox",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceBoxIcon = table.Column<string>(maxLength: 80, nullable: false),
                    PriceBoxType = table.Column<string>(maxLength: 20, nullable: false),
                    Price = table.Column<int>(nullable: false),
                    SectionPriceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceBox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceBox_SectionPrice_SectionPriceId",
                        column: x => x.SectionPriceId,
                        principalTable: "SectionPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceBoxSkills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceBoxskills = table.Column<string>(maxLength: 80, nullable: false),
                    SectionPriceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceBoxSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceBoxSkills_SectionPrice_SectionPriceId",
                        column: x => x.SectionPriceId,
                        principalTable: "SectionPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceBox_SectionPriceId",
                table: "PriceBox",
                column: "SectionPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceBoxSkills_SectionPriceId",
                table: "PriceBoxSkills",
                column: "SectionPriceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceBox");

            migrationBuilder.DropTable(
                name: "PriceBoxSkills");

            migrationBuilder.DropTable(
                name: "SectionPrice");
        }
    }
}
