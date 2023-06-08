using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Net_Final_Project.Migrations
{
    public partial class CreateServiceSectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SectionService",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiveServiceItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceIcon = table.Column<string>(maxLength: 80, nullable: false),
                    ServiceName = table.Column<string>(maxLength: 30, nullable: false),
                    ServiceDescription = table.Column<string>(maxLength: 300, nullable: false),
                    SectionServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiveServiceItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiveServiceItem_SectionService_SectionServiceId",
                        column: x => x.SectionServiceId,
                        principalTable: "SectionService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiveServiceItem_SectionServiceId",
                table: "ServiveServiceItem",
                column: "SectionServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiveServiceItem");

            migrationBuilder.DropTable(
                name: "SectionService");
        }
    }
}
