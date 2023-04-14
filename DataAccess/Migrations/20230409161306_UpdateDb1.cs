using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class UpdateDb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 9, 20, 13, 6, 57, DateTimeKind.Local).AddTicks(8847),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 7, 12, 33, 40, 258, DateTimeKind.Local).AddTicks(7426));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 9, 20, 13, 6, 57, DateTimeKind.Local).AddTicks(8966),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 7, 12, 33, 40, 258, DateTimeKind.Local).AddTicks(7599));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 7, 12, 33, 40, 258, DateTimeKind.Local).AddTicks(7426),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 9, 20, 13, 6, 57, DateTimeKind.Local).AddTicks(8847));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 7, 12, 33, 40, 258, DateTimeKind.Local).AddTicks(7599),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 9, 20, 13, 6, 57, DateTimeKind.Local).AddTicks(8966));
        }
    }
}
