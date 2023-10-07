using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonCatalogue.Migrations
{
    /// <inheritdoc />
    public partial class AddMiniaturesTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Produit",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Produit");
        }
    }
}
