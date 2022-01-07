using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFSoft.Customers.Infrastructure.Migrations
{
    public partial class AddHasOpenOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasOpenOrder",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasOpenOrder",
                table: "Customers");
        }
    }
}
