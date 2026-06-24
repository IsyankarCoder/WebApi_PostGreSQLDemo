using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_PostGreSQLDemo.Migrations
{
    /// <inheritdoc />
    public partial class Identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity_New");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "Identity",
                newName: "Products",
                newSchema: "Identity_New");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "Identity",
                newName: "AspNetUsers",
                newSchema: "Identity_New");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "Identity",
                newName: "AspNetUserTokens",
                newSchema: "Identity_New");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "Identity",
                newName: "AspNetUserRoles",
                newSchema: "Identity_New");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "Identity",
                newName: "AspNetUserLogins",
                newSchema: "Identity_New");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "Identity",
                newName: "AspNetUserClaims",
                newSchema: "Identity_New");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "Identity",
                newName: "AspNetRoles",
                newSchema: "Identity_New");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "Identity",
                newName: "AspNetRoleClaims",
                newSchema: "Identity_New");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "Identity_New",
                newName: "Products",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "Identity_New",
                newName: "AspNetUsers",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "Identity_New",
                newName: "AspNetUserTokens",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "Identity_New",
                newName: "AspNetUserRoles",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "Identity_New",
                newName: "AspNetUserLogins",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "Identity_New",
                newName: "AspNetUserClaims",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "Identity_New",
                newName: "AspNetRoles",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "Identity_New",
                newName: "AspNetRoleClaims",
                newSchema: "Identity");
        }
    }
}
