using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreSession02Demo.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "Sales",
                table: "Departments");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EmployeesTable",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.InsertData(
                schema: "Sales",
                table: "Departments",
                columns: new[] { "DeptId", "DateOfCreation", "DeptManagerId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IT" },
                    { 2, new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sales" },
                    { 3, new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Sales",
                table: "Departments",
                keyColumn: "DeptId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Sales",
                table: "Departments",
                keyColumn: "DeptId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Sales",
                table: "Departments",
                keyColumn: "DeptId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EmployeesTable");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "Sales",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }
    }
}
