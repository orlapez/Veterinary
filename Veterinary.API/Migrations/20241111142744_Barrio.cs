using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinary.API.Migrations
{
    /// <inheritdoc />
    public partial class Barrio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Barrio",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barrio",
                table: "Owners");
        }
    }
}
