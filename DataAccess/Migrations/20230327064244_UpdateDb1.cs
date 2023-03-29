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
                defaultValue: new DateTime(2023, 3, 27, 10, 42, 44, 36, DateTimeKind.Local).AddTicks(6816),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 10, 32, 25, 147, DateTimeKind.Local).AddTicks(8948));

            migrationBuilder.AlterColumn<short>(
                name: "StatusId",
                table: "Requests",
                type: "smallint",
                nullable: false,
                defaultValue: (short)1,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 10, 42, 44, 36, DateTimeKind.Local).AddTicks(6974),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 10, 32, 25, 147, DateTimeKind.Local).AddTicks(9082));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 10, 32, 25, 147, DateTimeKind.Local).AddTicks(8948),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 10, 42, 44, 36, DateTimeKind.Local).AddTicks(6816));

            migrationBuilder.AlterColumn<short>(
                name: "StatusId",
                table: "Requests",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldDefaultValue: (short)1);

            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 10, 32, 25, 147, DateTimeKind.Local).AddTicks(9082),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 10, 42, 44, 36, DateTimeKind.Local).AddTicks(6974));
        }
    }
}
