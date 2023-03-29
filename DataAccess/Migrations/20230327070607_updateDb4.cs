using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class updateDb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 11, 6, 7, 697, DateTimeKind.Local).AddTicks(5176),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 10, 58, 26, 790, DateTimeKind.Local).AddTicks(4939));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 11, 6, 7, 697, DateTimeKind.Local).AddTicks(5323),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 10, 58, 26, 790, DateTimeKind.Local).AddTicks(5122));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 10, 58, 26, 790, DateTimeKind.Local).AddTicks(4939),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 11, 6, 7, 697, DateTimeKind.Local).AddTicks(5176));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 10, 58, 26, 790, DateTimeKind.Local).AddTicks(5122),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 11, 6, 7, 697, DateTimeKind.Local).AddTicks(5323));
        }
    }
}
