using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvoiceAPI.Migrations
{
    /// <inheritdoc />
    public partial class addChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AddColumn<string>(
                name: "CreatedAt",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "InvoiceNumber" },
                values: new object[] { "4/15/2025", "889a08bd-a252-47a3-b373-66097156823a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Item");

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "InvoiceNumber" },
                values: new object[] { "4/9/2025", "0c3f8548-5854-4f02-9f10-b66addf1e42e" });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedAt", "CustomerName", "InvoiceNumber", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { 2, "4/9/2025", "John Stones", "ad8f9622-2967-4131-8257-57abdb315edc", 2, 500m },
                    { 3, "4/9/2025", "Alice Brown", "ddeeb9c3-baf6-42e8-8471-4a5b255381a9", 1, 750m },
                    { 4, "4/9/2025", "Michael Smith", "4ec794b8-5d6f-49a5-8ca4-327029346239", 2, 650m },
                    { 5, "4/9/2025", "Sarah Wilson", "c567a759-eb63-49e9-b9e1-14729e3d13ad", 1, 200m },
                    { 6, "4/9/2025", "David Johnson", "e6377e82-c17f-4dd8-963a-376b5c9d12bb", 2, 1200m },
                    { 7, "4/9/2025", "Emma Green", "baee2e18-5e90-43ad-b285-83050c12976c", 1, 450m },
                    { 8, "4/9/2025", "Oliver Harris", "730bdf49-5c6a-4f4f-8981-7983e6adcea6", 2, 350m },
                    { 9, "4/9/2025", "Sophia Adams", "8596a078-e5b9-4712-9237-90303118518b", 1, 550m },
                    { 10, "4/9/2025", "Liam Clark", "3f4d654d-2b1a-45df-acc7-462f19cc559e", 2, 800m }
                });
        }
    }
}
