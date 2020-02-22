using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenLab.DAL.EF.Migrations
{
    public partial class authors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OpenLab_Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CompleteName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    SiteUrl = table.Column<string>(nullable: true),
                    Online = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenLab_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenLab_NewsAuthors",
                columns: table => new
                {
                    NewsId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenLab_NewsAuthors", x => new { x.NewsId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_OpenLab_NewsAuthors_OpenLab_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "OpenLab_Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpenLab_NewsAuthors_OpenLab_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "OpenLab_News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpenLab_NewsAuthors_AuthorId",
                table: "OpenLab_NewsAuthors",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpenLab_NewsAuthors");

            migrationBuilder.DropTable(
                name: "OpenLab_Authors");
        }
    }
}
