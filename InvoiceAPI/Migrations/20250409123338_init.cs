using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvoiceAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedAt", "CustomerName", "InvoiceNumber", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { 1, "4/9/2025", "James Stuart", "0c3f8548-5854-4f02-9f10-b66addf1e42e", 1, 300m },
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

            migrationBuilder.CreateIndex(
                name: "IX_Item_InvoiceId",
                table: "Item",
                column: "InvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
