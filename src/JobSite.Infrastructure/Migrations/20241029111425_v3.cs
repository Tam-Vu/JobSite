using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSite.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityRoleClaim<Guid>_IdentityRole<Guid>_RoleId",
                table: "IdentityRoleClaim<Guid>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole<Guid>_IdentityRole<Guid>_RoleId",
                table: "IdentityUserRole<Guid>");

            migrationBuilder.DropTable(
                name: "IdentityRole<Guid>");

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "UserRole",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<Guid>_UserRole_RoleId",
                table: "IdentityRoleClaim<Guid>",
                column: "RoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<Guid>_UserRole_RoleId",
                table: "IdentityUserRole<Guid>",
                column: "RoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityRoleClaim<Guid>_UserRole_RoleId",
                table: "IdentityRoleClaim<Guid>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole<Guid>_UserRole_RoleId",
                table: "IdentityUserRole<Guid>");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.CreateTable(
                name: "IdentityRole<Guid>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole<Guid>", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "IdentityRole<Guid>",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<Guid>_IdentityRole<Guid>_RoleId",
                table: "IdentityRoleClaim<Guid>",
                column: "RoleId",
                principalTable: "IdentityRole<Guid>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<Guid>_IdentityRole<Guid>_RoleId",
                table: "IdentityUserRole<Guid>",
                column: "RoleId",
                principalTable: "IdentityRole<Guid>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
