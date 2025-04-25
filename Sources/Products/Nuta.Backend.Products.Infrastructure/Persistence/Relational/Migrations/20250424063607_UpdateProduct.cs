using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nuta.Backend.Products.Infrastructure.Persistence.Relational.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nuta_score",
                schema: "products",
                table: "products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nuta_score",
                schema: "products",
                table: "products",
                type: "jsonb",
                nullable: true);
        }
    }
}
