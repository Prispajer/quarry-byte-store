using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Server.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$wSWrS72E7Yso99DjiojnP.Ef0oMU1r0pJPZ6fgYdXl3I9arTIj1u6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$k.tAwyyw.eqQ0BojHXQGE.uU0QIFnlYUvwjEWvx8PIhvUkJRMxl7G");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$Hml30vCIlc/o3Y7Gy.R7x.oN8aX1NNqPqm0ebk642Uydtkk8dxgdm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$2F9Jdrq1GBM8nQGq2ubM4uPxyENQZqKCWq3F9EG30hsS/9zVuf/CO");
        }
    }
}
