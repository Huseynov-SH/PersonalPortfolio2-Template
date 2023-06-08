using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Net_Final_Project.Migrations
{
    public partial class CreateBlogItemAndBlogCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    SubTitle = table.Column<string>(maxLength: 500, nullable: false),
                    Image = table.Column<string>(maxLength: 255, nullable: true),
                    ShareDate = table.Column<string>(maxLength: 50, nullable: true),
                    Context = table.Column<string>(maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imahe = table.Column<string>(maxLength: 255, nullable: true),
                    ShareDate = table.Column<string>(maxLength: 50, nullable: true),
                    Comment = table.Column<string>(maxLength: 300, nullable: false),
                    BlogItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogComments_BlogItem_BlogItemId",
                        column: x => x.BlogItemId,
                        principalTable: "BlogItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_BlogItemId",
                table: "BlogComments",
                column: "BlogItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogComments");

            migrationBuilder.DropTable(
                name: "BlogItem");
        }
    }
}
