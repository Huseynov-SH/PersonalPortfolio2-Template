using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Net_Final_Project.Migrations
{
    public partial class CreateMyInterestsSectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SectionMyInterests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionMyInterests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyInterestsInterestsItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestsIcon = table.Column<string>(maxLength: 80, nullable: false),
                    InterestsName = table.Column<string>(maxLength: 20, nullable: false),
                    SectionMyInterestsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyInterestsInterestsItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyInterestsInterestsItem_SectionMyInterests_SectionMyInterestsId",
                        column: x => x.SectionMyInterestsId,
                        principalTable: "SectionMyInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyInterestsInterestsItem_SectionMyInterestsId",
                table: "MyInterestsInterestsItem",
                column: "SectionMyInterestsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyInterestsInterestsItem");

            migrationBuilder.DropTable(
                name: "SectionMyInterests");
        }
    }
}
