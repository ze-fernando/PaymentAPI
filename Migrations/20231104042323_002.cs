using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentAPI.Migrations
{
    /// <inheritdoc />
    public partial class _002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionID",
                table: "payble",
                newName: "TransactionId");

            migrationBuilder.AlterColumn<string>(
                name: "DatePayment",
                table: "payble",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_payble_TransactionId",
                table: "payble",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_payble_transactions_TransactionId",
                table: "payble",
                column: "TransactionId",
                principalTable: "transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_payble_transactions_TransactionId",
                table: "payble");

            migrationBuilder.DropIndex(
                name: "IX_payble_TransactionId",
                table: "payble");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "payble",
                newName: "TransactionID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePayment",
                table: "payble",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
