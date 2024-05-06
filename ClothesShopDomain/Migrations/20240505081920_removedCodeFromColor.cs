using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothesShopDomain.Migrations
{
    /// <inheritdoc />
    public partial class removedCodeFromColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Color");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Color",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
