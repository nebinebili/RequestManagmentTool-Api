using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class UpdateDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 10, 47, 30, 738, DateTimeKind.Local).AddTicks(9421),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 10, 42, 44, 36, DateTimeKind.Local).AddTicks(6816));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 10, 47, 30, 738, DateTimeKind.Local).AddTicks(9572),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 10, 42, 44, 36, DateTimeKind.Local).AddTicks(6974));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 10, 42, 44, 36, DateTimeKind.Local).AddTicks(6816),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 10, 47, 30, 738, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 10, 42, 44, 36, DateTimeKind.Local).AddTicks(6974),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 10, 47, 30, 738, DateTimeKind.Local).AddTicks(9572));
        }
    }
}
