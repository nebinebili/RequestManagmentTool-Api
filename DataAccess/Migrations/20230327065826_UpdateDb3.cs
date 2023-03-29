using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class UpdateDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfilPicture",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 10, 58, 26, 790, DateTimeKind.Local).AddTicks(4939),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 10, 47, 30, 738, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 10, 58, 26, 790, DateTimeKind.Local).AddTicks(5122),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 10, 47, 30, 738, DateTimeKind.Local).AddTicks(9572));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfilPicture",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 10, 47, 30, 738, DateTimeKind.Local).AddTicks(9421),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 10, 58, 26, 790, DateTimeKind.Local).AddTicks(4939));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 10, 47, 30, 738, DateTimeKind.Local).AddTicks(9572),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 10, 58, 26, 790, DateTimeKind.Local).AddTicks(5122));
        }
    }
}
