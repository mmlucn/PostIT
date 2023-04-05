using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostIT_API.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PostItNote");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PostItNote",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
