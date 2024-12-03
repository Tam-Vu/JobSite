using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSite.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityRoleClaim<Guid>_UserRole_RoleId",
                table: "IdentityRoleClaim<Guid>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole<Guid>_UserRole_RoleId",
                table: "IdentityUserRole<Guid>");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "InterviewDate",
                table: "InterviewSchedule",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<Guid>_Role_RoleId",
                table: "IdentityRoleClaim<Guid>",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<Guid>_Role_RoleId",
                table: "IdentityUserRole<Guid>",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityRoleClaim<Guid>_Role_RoleId",
                table: "IdentityRoleClaim<Guid>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole<Guid>_Role_RoleId",
                table: "IdentityUserRole<Guid>");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InterviewDate",
                table: "InterviewSchedule",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
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
    }
}
