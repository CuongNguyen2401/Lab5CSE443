using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab5Cuong.Migrations
{
    /// <inheritdoc />
    public partial class fix2keyInMembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.AlterColumn<string>(
                name: "MovieRole",
                table: "Member",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                columns: new[] { "PersonId", "MovieId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.AlterColumn<string>(
                name: "MovieRole",
                table: "Member",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                columns: new[] { "PersonId", "MovieId", "MovieRole" });
        }
    }
}
