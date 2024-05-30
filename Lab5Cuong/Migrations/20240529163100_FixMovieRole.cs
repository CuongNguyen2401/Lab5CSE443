using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab5Cuong.Migrations
{
    /// <inheritdoc />
    public partial class FixMovieRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Member");

            migrationBuilder.AddColumn<string>(
                name: "MovieRole",
                table: "Member",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                columns: new[] { "PersonId", "MovieId", "MovieRole" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "MovieRole",
                table: "Member");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Member",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                columns: new[] { "PersonId", "MovieId", "Role" });
        }
    }
}
