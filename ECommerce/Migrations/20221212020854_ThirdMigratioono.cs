using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class ThirdMigratioono : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerId1",
                table: "Customers",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Customers_CustomerId1",
                table: "Customers",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Customers_CustomerId1",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerId1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Customers");
        }
    }
}
