using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreManagementSystem.Infrastructure.Migrations
{
    public partial class ModifedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Sales",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "SellingPrice",
                table: "Sales",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SellingPrice",
                table: "Books",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellingPrice",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SellingPrice",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Sales",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
