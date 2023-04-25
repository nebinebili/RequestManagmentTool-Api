using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class UpdateDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 25, 13, 27, 50, 628, DateTimeKind.Local).AddTicks(2013),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 14, 11, 38, 46, 522, DateTimeKind.Local).AddTicks(4574));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 25, 13, 27, 50, 628, DateTimeKind.Local).AddTicks(2169),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 14, 11, 38, 46, 522, DateTimeKind.Local).AddTicks(4714));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 25, 13, 27, 50, 628, DateTimeKind.Local).AddTicks(2647),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 14, 11, 38, 46, 522, DateTimeKind.Local).AddTicks(4574),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 25, 13, 27, 50, 628, DateTimeKind.Local).AddTicks(2013));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 14, 11, 38, 46, 522, DateTimeKind.Local).AddTicks(4714),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 25, 13, 27, 50, 628, DateTimeKind.Local).AddTicks(2169));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 25, 13, 27, 50, 628, DateTimeKind.Local).AddTicks(2647));
        }
    }
}
