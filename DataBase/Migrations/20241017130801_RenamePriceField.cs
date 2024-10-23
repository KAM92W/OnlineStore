using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class RenamePriceField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceName",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Prices",
                newName: "Rub");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rub",
                table: "Prices",
                newName: "Name");

            migrationBuilder.AddColumn<decimal>(
                name: "PriceName",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
