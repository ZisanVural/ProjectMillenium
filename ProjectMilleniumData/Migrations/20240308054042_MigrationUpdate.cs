using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectMillenium.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserRoleName",
                table: "UserRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RoleClaims",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RoleClaimName",
                table: "RoleClaims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "UserRoleName",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "RoleClaimName",
                table: "RoleClaims");
        }
    }
}
