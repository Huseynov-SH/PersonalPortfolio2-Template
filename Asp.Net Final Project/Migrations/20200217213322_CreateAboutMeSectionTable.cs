﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Net_Final_Project.Migrations
{
    public partial class CreateAboutMeSectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SectionAboutMes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(maxLength: 30, nullable: false),
                    Image = table.Column<string>(maxLength: 255, nullable: false),
                    FullName = table.Column<string>(maxLength: 80, nullable: false),
                    Location = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 700, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionAboutMes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IconInfoAboutMes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IconInfo = table.Column<string>(maxLength: 80, nullable: false),
                    TitInfo = table.Column<string>(maxLength: 20, nullable: false),
                    SubTitInfo = table.Column<string>(maxLength: 30, nullable: false),
                    SectionAboutMeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IconInfoAboutMes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IconInfoAboutMes_SectionAboutMes_SectionAboutMeId",
                        column: x => x.SectionAboutMeId,
                        principalTable: "SectionAboutMes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IconInfoAboutMes_SectionAboutMeId",
                table: "IconInfoAboutMes",
                column: "SectionAboutMeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IconInfoAboutMes");

            migrationBuilder.DropTable(
                name: "SectionAboutMes");
        }
    }
}
