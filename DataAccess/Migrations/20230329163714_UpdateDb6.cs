using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class UpdateDb6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 20, 37, 14, 485, DateTimeKind.Local).AddTicks(5230),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 20, 33, 20, 448, DateTimeKind.Local).AddTicks(9570));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Statuses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 20, 37, 14, 485, DateTimeKind.Local).AddTicks(5408),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 20, 33, 20, 448, DateTimeKind.Local).AddTicks(9715));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Priorities",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 20, 33, 20, 448, DateTimeKind.Local).AddTicks(9570),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 20, 37, 14, 485, DateTimeKind.Local).AddTicks(5230));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Statuses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 20, 33, 20, 448, DateTimeKind.Local).AddTicks(9715),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 20, 37, 14, 485, DateTimeKind.Local).AddTicks(5408));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Priorities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
