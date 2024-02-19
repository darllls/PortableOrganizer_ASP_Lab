using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortableOrganizer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Name", "OrderNumber", "Phone" },
                values: new object[,]
                {
                    { 1, "Customer1", 1001, "123456789" },
                    { 2, "Customer2", 1002, "987654321" },
                    { 3, "Customer3", 1003, "111223344" },
                    { 4, "Customer4", 1004, "555666777" },
                    { 5, "Customer5", 1005, "999888777" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "Date", "Number", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Local), 1001, 0 },
                    { 2, new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Local), 1002, 0 },
                    { 3, new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Local), 1003, 0 },
                    { 4, new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Local), 1004, 0 },
                    { 5, new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Local), 1005, 0 }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "supplier1@example.com", "Supplier1" },
                    { 2, "supplier2@example.com", "Supplier2" },
                    { 3, "supplier3@example.com", "Supplier3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
