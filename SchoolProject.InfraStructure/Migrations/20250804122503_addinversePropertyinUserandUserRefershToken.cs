using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.InfraStructure.Migrations
{
    /// <inheritdoc />
    public partial class addinversePropertyinUserandUserRefershToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "userRefreshTokens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "userRefreshTokens");
        }
    }
}
