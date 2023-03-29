using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class UpdateDb5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 20, 33, 20, 448, DateTimeKind.Local).AddTicks(9570),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 11, 6, 7, 697, DateTimeKind.Local).AddTicks(5176));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Statuses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 20, 33, 20, 448, DateTimeKind.Local).AddTicks(9715),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 11, 6, 7, 697, DateTimeKind.Local).AddTicks(5323));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Priorities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 11, 6, 7, 697, DateTimeKind.Local).AddTicks(5176),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 20, 33, 20, 448, DateTimeKind.Local).AddTicks(9570));

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Statuses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 11, 6, 7, 697, DateTimeKind.Local).AddTicks(5323),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 20, 33, 20, 448, DateTimeKind.Local).AddTicks(9715));

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Priorities",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
