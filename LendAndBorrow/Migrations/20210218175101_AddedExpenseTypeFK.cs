using Microsoft.EntityFrameworkCore.Migrations;

namespace LendAndBorrow.Migrations
{
    public partial class AddedExpenseTypeFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpenseCategoryId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpenseType",
                table: "Expenses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseType",
                table: "Expenses",
                column: "ExpenseType");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Categories_ExpenseType",
                table: "Expenses",
                column: "ExpenseType",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Categories_ExpenseType",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ExpenseType",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpenseCategoryId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpenseType",
                table: "Expenses");
        }
    }
}
