using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenLab.DAL.EF.Migrations
{
    public partial class news : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                string msg = "migrationBuilder param is null";
                throw new ArgumentNullException(msg);
            }

            migrationBuilder.CreateTable(
                name: "OpenLab_News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Abstract = table.Column<string>(nullable: true),
                    BodyHtml = table.Column<string>(nullable: true),
                    BodyText = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    NiceLink = table.Column<string>(nullable: true),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    FKCreateUser = table.Column<int>(nullable: false),
                    FKUpdateUser = table.Column<int>(nullable: true),
                    Online = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenLab_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenLab_News_OpenLab_Users_FKCreateUser",
                        column: x => x.FKCreateUser,
                        principalTable: "OpenLab_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpenLab_News_OpenLab_Users_FKUpdateUser",
                        column: x => x.FKUpdateUser,
                        principalTable: "OpenLab_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpenLab_News_FKCreateUser",
                table: "OpenLab_News",
                column: "FKCreateUser");

            migrationBuilder.CreateIndex(
                name: "IX_OpenLab_News_FKUpdateUser",
                table: "OpenLab_News",
                column: "FKUpdateUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                string msg = "migrationBuilder param is null";
                throw new ArgumentNullException(msg);
            }

            migrationBuilder.DropTable(
                name: "OpenLab_News");
        }
    }
}
