using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenLab.DAL.EF.Migrations
{
    public partial class update20191221 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
                throw new ArgumentException($"{nameof(migrationBuilder)} not found".ToUpperInvariant());

            migrationBuilder.CreateTable(
                name: "OpenLab_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenLab_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenLab_Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    customTag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenLab_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenLab_RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenLab_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenLab_RoleClaims_OpenLab_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OpenLab_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenLab_News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "OpenLab_UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenLab_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenLab_UserClaims_OpenLab_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "OpenLab_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenLab_UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenLab_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_OpenLab_UserLogins_OpenLab_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "OpenLab_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenLab_UsersRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenLab_UsersRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_OpenLab_UsersRoles_OpenLab_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OpenLab_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpenLab_UsersRoles_OpenLab_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "OpenLab_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenLab_UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenLab_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_OpenLab_UserTokens_OpenLab_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "OpenLab_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpenLab_News_FKCreateUser",
                table: "OpenLab_News",
                column: "FKCreateUser");

            migrationBuilder.CreateIndex(
                name: "IX_OpenLab_News_FKUpdateUser",
                table: "OpenLab_News",
                column: "FKUpdateUser");

            migrationBuilder.CreateIndex(
                name: "IX_OpenLab_RoleClaims_RoleId",
                table: "OpenLab_RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "OpenLab_Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OpenLab_UserClaims_UserId",
                table: "OpenLab_UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenLab_UserLogins_UserId",
                table: "OpenLab_UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "OpenLab_Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "OpenLab_Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OpenLab_UsersRoles_RoleId",
                table: "OpenLab_UsersRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
                throw new ArgumentException($"{nameof(migrationBuilder)} not found".ToUpperInvariant());

            migrationBuilder.DropTable(
                name: "OpenLab_News");

            migrationBuilder.DropTable(
                name: "OpenLab_RoleClaims");

            migrationBuilder.DropTable(
                name: "OpenLab_UserClaims");

            migrationBuilder.DropTable(
                name: "OpenLab_UserLogins");

            migrationBuilder.DropTable(
                name: "OpenLab_UsersRoles");

            migrationBuilder.DropTable(
                name: "OpenLab_UserTokens");

            migrationBuilder.DropTable(
                name: "OpenLab_Roles");

            migrationBuilder.DropTable(
                name: "OpenLab_Users");
        }
    }
}
