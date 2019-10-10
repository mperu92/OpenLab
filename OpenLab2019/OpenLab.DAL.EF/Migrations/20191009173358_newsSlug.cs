using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace OpenLab.DAL.EF.Migrations
{
    public partial class newsSlug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                string msg = "migrationBuilder param is null";
                throw new ArgumentNullException(msg);
            }

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "OpenLab_News",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                string msg = "migrationBuilder param is null";
                throw new ArgumentNullException(msg);
            }

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "OpenLab_News");
        }
    }
}
