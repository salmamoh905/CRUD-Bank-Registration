using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updatedTransactionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Transactions",
                newName: "TransactedAmount");

            migrationBuilder.AddColumn<int>(
                name: "Initialamount",
                table: "BankUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Initialamount",
                table: "BankUsers");

            migrationBuilder.RenameColumn(
                name: "TransactedAmount",
                table: "Transactions",
                newName: "amount");
        }
    }
}
